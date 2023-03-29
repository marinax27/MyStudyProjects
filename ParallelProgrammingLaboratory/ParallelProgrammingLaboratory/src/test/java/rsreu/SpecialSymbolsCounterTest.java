package rsreu;

import static org.junit.Assert.assertTrue;

import org.junit.Assert;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.junit.runners.Parameterized;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.lang.annotation.Repeatable;
import java.util.Arrays;
import java.util.List;

@RunWith(Parameterized.class)
public class SpecialSymbolsCounterTest
{
    @Parameterized.Parameters
    public static List<Object[]> data() {
        return Arrays.asList(new Object[50][0]);
    }

    @Test
    public void checkCountingNumberSpecialSymbolsOne()
    {
        int countSpecialSymbols = SpecialSymbolsCounter.countNumberSpecialSymbols("Gra1!-Hg~~");
        Assert.assertEquals(4, countSpecialSymbols);
    }

    @Test
    public void checkCountingNumberSpecialSymbolsTwo()
    {
        int countSpecialSymbols = SpecialSymbolsCounter.countNumberSpecialSymbols("%%$_Aq4;");
        Assert.assertEquals(5, countSpecialSymbols);
    }

    @Test
    public void checkCountingNumberSpecialSymbolsThree()
    {
        int countSpecialSymbols = SpecialSymbolsCounter.countNumberSpecialSymbols("ABB");
        Assert.assertEquals(0, countSpecialSymbols);
    }

    @Test(expected = IllegalArgumentException.class)
    public void checkEmptyString() {
        SpecialSymbolsCounter.countNumberSpecialSymbols("");
    }
}
