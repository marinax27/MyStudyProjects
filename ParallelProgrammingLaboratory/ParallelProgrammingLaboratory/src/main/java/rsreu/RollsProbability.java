package rsreu;

import java.util.concurrent.Callable;
import java.util.concurrent.CountDownLatch;
import java.util.concurrent.Semaphore;
import java.util.concurrent.locks.ReentrantLock;

public class RollsProbability implements Runnable, Callable<Double> {

    //region Fields
    /*
    Количество граней кубика
     */
    private static final int NUMBER_FACET = 10;
    /*
    Количество бросков кубика
     */
    private static final int NUMBER_ROLLS = 20;
    /*
    Число, больше которого должна быть сумма бросков кубика
     */
    private static final int NUMBER = 100;
    /*
    Лучшие броски
     */
    private static final int BEST_NUMBER_ROLLS = 10;
    /*
    Погрешность
     */
    private static final double EPS = 0.000000014;
    /*
    Количество повторений
     */
    private final int repetitionsNumber;
    /*
     Всего повторений
     */
    private int repetitionsAll;
    private int progress;

    /*
    Защелка
     */
    private final CountDownLatch countDownLatch;
    /*
    Семафор
     */
    private final MySemaphore semaphore;
    /*
    Блокировка
     */
    private final ReentrantLock reentrantLock;


    //endregion

    public RollsProbability(int repetitionsNumber, int repetitionsAll, CountDownLatch countDownLatch,
                            MySemaphore semaphore, ReentrantLock reentrantLock) {
        this.repetitionsNumber = repetitionsNumber;
        this.repetitionsAll = repetitionsAll;
        this.countDownLatch = countDownLatch;
        this.semaphore = semaphore;
        this.reentrantLock = reentrantLock;
    }

    public void run() {
        double probability = getProbability();
        System.out.println("Поток: " + Thread.currentThread().getName() + ", Вероятность : " + probability);
    }

    private double getProbability() {
        double probability = 0;
        try {
            try {
                semaphore.acquire();
                System.out.println("Поток " + Thread.currentThread().getName() + " начинает считать");
                probability = countProbabilityByMonteCarlo(repetitionsNumber);
                System.out.println("Поток " + Thread.currentThread().getName() + " закончил считать");
            } catch (Exception e) {
                System.out.println(e.getMessage());
            } finally {
                semaphore.release();
                countDownLatch.countDown();
            }

            double startTime = System.currentTimeMillis();
            countDownLatch.await();
            double endTime = System.currentTimeMillis();

            System.out.println("Время от завершения потока " + Thread.currentThread().getName()
                    + " до завершения остальных потоков: "+ (endTime - startTime) / 1000 + "сек.");
        } catch (InterruptedException e) {
            System.out.println(e.getMessage());
        }
        return probability;
    }

    @Override
    public Double call() throws Exception {
        return getProbability();
    }

    /**
     * Подсчет вероятности методом Монте Карло
     * @param repetitionsNumber количество повторений
     * @return вероятность того, что броски кубика будут больше number
     */
    public double countProbabilityByMonteCarlo(int repetitionsNumber) throws InterruptedException {
        int favorableOutcome = 0;
        DiceRollProbabilityCalculator diceRollProbabilityCalculator =
                new DiceRollProbabilityCalculator(NUMBER_FACET, NUMBER_ROLLS, BEST_NUMBER_ROLLS, EPS, NUMBER);
        for (int i = 0; i < repetitionsNumber; i++) {
            if (Thread.currentThread().isInterrupted()) {
                throw new InterruptedException("Поток " + Thread.currentThread().getName() + " был прерван");
            }
            if (diceRollProbabilityCalculator.countSumNumberDrawn() > diceRollProbabilityCalculator.getNumber()) {
                favorableOutcome++;
            }

            reentrantLock.lock();
            try {
                if ((i + 1)  % (repetitionsAll / 10) == 0) {
                    progress++;
                    System.out.println("Прогресс - " + progress * 10 + "%");
                }
            } finally {
                reentrantLock.unlock();
            }
        }
        return (double) favorableOutcome / repetitionsNumber;
    }
}
