package rsreu;

/**
 * Определение количества спецсимволов в строке.
 */
public class SpecialSymbolsCounter
{
    private SpecialSymbolsCounter() {

    }

    public static int countNumberSpecialSymbols(String str) {
        if (!str.equals("")){
            String specialCharacters="!#$%&'()*+,-./:;<=>?@[]^_`{|}~ ";
            String[] newStr = str.split("");

            int count = 0;
            for(int i = 0; i < newStr.length; i++){
                if (specialCharacters.contains(newStr[i])) {
                    count++;
                }
            }
            return count;
        } else {
            throw new IllegalArgumentException("Введена пустая строка!");
        }
    }
}
