namespace Business.Models.Validations.Documents
{
    public class NifValidation{

        public const int nifLenght = 9;
        public static bool IsValidNIF(string Contrib)
    {
        if (string.IsNullOrEmpty(Contrib)) return false;
        if (Contrib.Length < nifLenght) return false;
        var functionReturnValue = false;
        var s = new string[9];

        s[0] = Convert.ToString(Contrib[0]);
        s[1] = Convert.ToString(Contrib[1]);
        s[2] = Convert.ToString(Contrib[2]);
        s[3] = Convert.ToString(Contrib[3]);
        s[4] = Convert.ToString(Contrib[4]);
        s[5] = Convert.ToString(Contrib[5]);
        s[6] = Convert.ToString(Contrib[6]);
        s[7] = Convert.ToString(Contrib[7]);
        s[8] = Convert.ToString(Contrib[8]);

        if (Contrib.Length == 9)
        {
            var C = s[0];
            if (s[0] == "1" || s[0] == "2" || s[0] == "3" || s[0] == "5" || s[0] == "6" || s[0] == "7" || s[0] == "8" || s[0] == "9")
            {
                long checkDigit = Convert.ToInt32(C) * 9;
                int i;
                for (i = 2; i <= 8; i++)
                {
                    checkDigit = checkDigit + (Convert.ToInt32(s[i - 1]) * (10 - i));
                }
                checkDigit = 11 - (checkDigit % 11);
                if (checkDigit >= 10)
                    checkDigit = 0;
                if (checkDigit == Convert.ToInt32(s[8]))
                    functionReturnValue = true;
            }
        }
        return functionReturnValue;
    }
}
}
