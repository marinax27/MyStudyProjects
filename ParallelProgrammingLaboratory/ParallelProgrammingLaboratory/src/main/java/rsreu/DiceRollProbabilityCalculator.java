package rsreu;

import java.util.Arrays;
import java.util.concurrent.ThreadLocalRandom;

/**
 * Вычислить вероятность того, что броски кубика 20 раз с 10 гранями будут больше 100 методом Монте-Карло.
 */
public class DiceRollProbabilityCalculator {

    //region Fields
    /*
    Количество граней кубика
     */
    private int numberFacet;
    /*
    Количество бросков кубика
     */
    private int numberRolls;
    /*
    Лучшие броски
     */
    private int bestNumberRolls;
    /*
    Число, больше которого должна быть сумма бросков кубика
     */
    private int number;
    /*
    Погрешность
     */
    private double eps;
    //endregion

    public DiceRollProbabilityCalculator(int numberFacet, int numberRolls, int bestNumberRolls, double eps, int number) {
        this.numberFacet = numberFacet;
        this.numberRolls = numberRolls;
        this.bestNumberRolls = bestNumberRolls;
        this.eps = eps;
        this.number = number;
    }

    /**
     * Бросание одного кубика
     * @return число грани
     */
    public int rollDice() {
        return ThreadLocalRandom.current().nextInt(1, numberFacet + 1);
    }

    /**
     * Подсчет количества выпавших чисел кубика
     * @return сумма выпавших чисел
     */
    public int countSumNumberDrawn() {
        int[] rolls = new int[numberRolls];
        int bestRolls = 0;
        int rollResult;

        for (int i = 0; i < numberRolls; i++) {
            do {
              rollResult = rollDice();
              rolls[i] += rollResult;
            } while (rollResult == numberFacet);
        }

        Arrays.sort(rolls);

        for (int i = rolls.length - 1; i >= rolls.length - bestNumberRolls; i--) {
            bestRolls += rolls[i];
        }

        return bestRolls;
    }

    /**
     * Подсчет вероятности методом Монте Карло с погрешностью
     * @return вероятность того, что броски кубика будут больше number
     */
    public double countProbabilityByMonteCarloEps() {
        int favorableOutcome = 0;
        double newProbability = 0;
        double oldProbability;
        int minRepetitions = 500;
        int repetitions = 0;

        do {
            if (countSumNumberDrawn() > number) {
                favorableOutcome++;
            }
            repetitions++;
            oldProbability = newProbability;
            newProbability = (double) favorableOutcome / repetitions;
        }
        while ((Math.abs(newProbability - oldProbability) > eps) || (repetitions < minRepetitions));

        return newProbability;
    }


    /**
     * Вывод прогресса и изменение флага
     * @param repetitionsNumber количество итераций
     * @param flag
     * @param i
     * @return
     */
    private static boolean isProgress(int repetitionsNumber, boolean flag, int i) {
        int percent = (int) ((double) (i + 1) / repetitionsNumber * 100);
        if (percent % 10 == 0) {
            if (flag) {
             //   System.out.println("Прогресс: " + percent + "%");
                flag = false;
            }
        } else {
            flag = true;
        }
        return flag;
    }

    //region Getters and Setters
    public int getNumberFacet() {
        return numberFacet;
    }

    public void setNumberFacet(int numberFacet) {
        this.numberFacet = numberFacet;
    }

    public int getNumberRolls() {
        return numberRolls;
    }

    public void setNumberRolls(int numberRolls) {
        this.numberRolls = numberRolls;
    }

    public double getEps() {
        return eps;
    }

    public void setEps(double eps) {
        this.eps = eps;
    }

    public int getNumber() {
        return number;
    }

    public void setNumber(int number) {
        this.number = number;
    }
    //endregion
}
