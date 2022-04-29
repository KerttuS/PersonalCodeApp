

namespace PersonalCodeApi.Services
{
    public class PersonalCodeValidationService
    {

        public static String ValidationResultMessage(string inputCode)
        {
            string? message = "";

            if (string.IsNullOrEmpty(inputCode))
            {
                return message = "Kood on puudu";
            }
            else
            {
                if (inputCode.Length == 11)
                {
                    char[]? codeToCheck = inputCode.ToCharArray();
                    int sex = Convert.ToInt32(inputCode.Substring(0, 1));
                    int month = Convert.ToInt32(inputCode.Substring(3, 2));
                    int day = Convert.ToInt32(inputCode.Substring(5, 2));
                    int lastNum = Convert.ToInt32(inputCode.Substring(10, 1));

                    int checkSum = getCheckSum(codeToCheck);

                    if (sex >= 3 && sex <= 6 && month >= 1 && month <= 12 && day >= 1 && day <= 31 && lastNum == checkSum)
                    {
                        message = "Sisestatud isikukood on õige";

                    }
                    else
                    {
                        message = "Sisestatud isikukood on vigane!";

                    }
                    return message;
                }
                else
                {
                    return "Sisestatud isikukoodi pikkus on vale";
                }

            }

        }

        private static int getCheckSum(char[] code)
        {
            List<int> weight = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 1 };
            List<int> weight2 = new List<int>() { 3, 4, 5, 6, 7, 8, 9, 1, 2, 3 };
            int[] codeSequence = code.Select(c => Convert.ToInt32(c.ToString())).ToArray();

            IEnumerable<int>? calculatedWeight1 = (weight.Select((x, index) => x * codeSequence[index]));
            int controlSum1 = calculatedWeight1.Sum();
            int sum1 = controlSum1 % 11;

            if (sum1 == 10)
            {
                IEnumerable<int>? calculatedWeight2 = (weight2.Select((x, index) => x * codeSequence[index]));
                int controlSum2 = calculatedWeight2.Sum();
                int sum2 = controlSum2 % 11;


                if (sum2 == 10)
                {
                    sum2 = 0;
                }
                return sum2;
            }
            else
            {
                return sum1;
            }


        }

    }
}
