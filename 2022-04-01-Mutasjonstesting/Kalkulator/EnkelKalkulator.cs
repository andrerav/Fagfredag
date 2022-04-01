namespace Kalkulator.Implementasjon;

using System;

public class EnkelKalkulator
{
    public int Adder(int a, int b)
    {
        return a + b;
    }

    public int Subtraher(int a, int b)
    {
        return (a - b);
    }

    public int Multipliser(int a, int b)
    {
        return a * b;
    }

    public (int svar, int rest) Divider(int teller, int nevner)
    {
        if (nevner == 0)
        {
            throw new DivideByZeroException();
        }

        var svar = teller / nevner;
        var rest = teller % nevner;
        return (svar, rest);
    }
}
