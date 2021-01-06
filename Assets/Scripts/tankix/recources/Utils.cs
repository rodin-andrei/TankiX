

public class Utils
{
    public static string longToHex(long number)
    {
        long? a = number;
        string v = a.Value.ToString("X").ToLower();
        int count = 8 - v.Length;
        for (int j = 0; j < count; j++) v = "0" + v;
        return v;
    }
}