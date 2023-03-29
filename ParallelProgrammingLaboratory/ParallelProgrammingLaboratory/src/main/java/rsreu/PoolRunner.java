package rsreu;

import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.*;
import java.util.concurrent.locks.ReentrantLock;

public class PoolRunner {
    /*
    Количество потоков в пуле
     */
    private static final int THREAD_NUMBER = 10;
    /*
    Количество повторений
     */
    private static final int REPETITIONS_NUMBER = 10000000;
    /*
    Количество задач
     */
    private static final int TASK_NUMBER = 10;

    private PoolRunner() {}

    public static void main(String[] args) {
        CountDownLatch countDownLatch = new CountDownLatch(TASK_NUMBER);
        MySemaphore semaphore = new MySemaphore(2);
        ReentrantLock reentrantLock = new ReentrantLock();

        ExecutorService executorService = Executors.newFixedThreadPool(THREAD_NUMBER);
        Callable<Double> callable = new RollsProbability(REPETITIONS_NUMBER/TASK_NUMBER,
                REPETITIONS_NUMBER, countDownLatch, semaphore, reentrantLock);

        List<Future<Double>> futures = new ArrayList<>();
        for (int i = 0; i < TASK_NUMBER; i++) {
            futures.add(executorService.submit(callable));
        }

        double sum = 0;
        for (Future<Double> future : futures) {
            try {
                sum += future.get();
            } catch (InterruptedException | ExecutionException e) {
                System.out.println(e.getMessage());
            }
        }

        executorService.shutdown();

        System.out.println("Вероятность: " + sum / TASK_NUMBER);
    }
}
