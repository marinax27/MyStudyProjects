package rsreu;

public class MonitorRunner {
    /*
    Искомый символ
     */
    private static final char SYMBOL = 'а';
    /*
    Максимальное количество символов, которые нужно найти
     */
    private static final int MAX_NUMBER_SYMBOL = 10;
    /*
    Первый файл
     */
    private static final String FIRST_FILE_NAME = "firstFile.txt";
    /*
    Второй файл
     */
    private static final String SECOND_FILE_NAME = "secondFile.txt";

    public MonitorRunner() {}

    public static void main(String[] args){
        SymbolCounter symbolCounter = new SymbolCounter(SYMBOL, MAX_NUMBER_SYMBOL);
        Runnable firstCounter = new FileCharacterCounter(FIRST_FILE_NAME, symbolCounter);
        Runnable secondCounter = new FileCharacterCounter(SECOND_FILE_NAME, symbolCounter);
        new Thread(firstCounter).start();
        new Thread(secondCounter).start();
    }
}
