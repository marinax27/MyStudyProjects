package rsreu;

public class SymbolCounter {
    //region Fields
    /*
    Искомый символ
     */
    public char symbol;
    /*
    Максимальное количество символов, которые нужно найти
     */
    public int numberSymbol;
    /*
    Счетчик
     */
    public int count;
    //endregion

    public SymbolCounter(char symbol, int numberSymbol) {
        this.symbol = symbol;
        this.numberSymbol = numberSymbol;
        this.count = 0;
    }
}
