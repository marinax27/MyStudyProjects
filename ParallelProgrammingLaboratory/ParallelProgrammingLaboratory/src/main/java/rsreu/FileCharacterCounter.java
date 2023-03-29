package rsreu;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;

public class FileCharacterCounter implements Runnable {
    //region Fields
    /*
    Название файла
     */
    private final String fileName;
    /*
    Счетчик символов
     */
    private final SymbolCounter symbolCounter;
    /*
    Маскимальное количество символов
     */
    private static final int MAX_NUMBER_SYMBOL = 10;
    //endregion

    public FileCharacterCounter(String fileName, SymbolCounter symbolCounter) {
        this.fileName = fileName;
        this.symbolCounter = symbolCounter;
    }

    @Override
    public void run() {
        System.out.println("Поток " + Thread.currentThread().getName() + " запущен.");

        try (BufferedReader bufferedReader = new BufferedReader(new FileReader(fileName))) {
            int symbol;
            while ((symbol = bufferedReader.read()) != -1) {
                if (countSymbol((char) symbol)) {
                    return;
                }
            }
        } catch (IOException e) {
            System.out.println(e.getMessage());
        } finally {
            System.out.println("Поток " + Thread.currentThread().getName() + " завершен.");
        }
    }

    /*
    Поиск 10 символов а
     */
    private boolean countSymbol(char symbol) {
        synchronized (symbolCounter) {
            if (symbolCounter.count >= symbolCounter.numberSymbol) {
                return true;
            } else {
                if (symbol == symbolCounter.symbol) {

                    symbolCounter.count += 1;
                    if (symbolCounter.count >= symbolCounter.numberSymbol){
                        return true;
                    }
                    System.out.println("Счетчик: " + symbolCounter.count);
                    if (symbolCounter.count == symbolCounter.numberSymbol) {
                        System.out.println("Достигнуто " + symbolCounter.numberSymbol + " символов '" + symbolCounter.symbol + "'.");
                        return true;
                    }
                }
            }
        }
        return false;
    }




}
