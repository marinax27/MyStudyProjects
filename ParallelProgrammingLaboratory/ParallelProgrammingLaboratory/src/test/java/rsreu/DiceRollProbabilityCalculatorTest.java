package rsreu;

import org.junit.Test;

public class DiceRollProbabilityCalculatorTest {

    //region Fields
    /*
    Количество граней кубика
     */
    private int numberFacet = 10;
    /*
    Количество бросков кубика
     */
    private int numberRolls = 20;
    /*
    Число, больше которого должна быть сумма бросков кубика
     */
    private int number = 100;
    /*
    Лучшие броски
     */
    private int bestNumberRolls = 10;
    /*
    Погрешность
     */
    private double eps = 0.00000003;
    //endregion

    @Test
    public void calculateProbability() {

        DiceRollProbabilityCalculator diceRollProbabilityCalculator =
                new DiceRollProbabilityCalculator(numberFacet, numberRolls, bestNumberRolls, eps, number);

        long time = System.currentTimeMillis();
        double probability = diceRollProbabilityCalculator.countProbabilityByMonteCarloEps();
        System.out.println("Время выполнения: " + (double) (System.currentTimeMillis() - time) / 1000 + " сек");

        System.out.println("Вероятность: " + probability);
    }
}
