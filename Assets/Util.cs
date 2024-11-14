using System.Numerics;

public class Util
{
    private static string[] numberUnitArr = new string[] { "", "K", "M", "B", "T" };
    public static string GetNumberText(BigInteger initialValue)
    {
        int placeN = 0;
        BigInteger value = initialValue;
        while (value >= 1000 && placeN < numberUnitArr.Length - 1)
        {
            value /= 1000;
            placeN++;
        }

        if (placeN > 4)
        {
            string initialValueToString = initialValue.ToString();
            string firstThreeDigit = initialValueToString.Substring(0, 3);
            string nextTwoDigit = initialValueToString.Substring(3, 2);

            return firstThreeDigit + "." + nextTwoDigit + "e" + $"{BigInteger.Log10(initialValue) - 2}";
        }
        return value.ToString() + numberUnitArr[placeN];
    }
}