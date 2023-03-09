using NLog;
using System;

namespace ExampleMethods
{
    public static class WordScramble
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public static string RotateCharacters(string input, int rotationAmount)
        {
            try
            {
                rotationAmount = rotationAmount % input.Length;

                if (rotationAmount == 0)
                {
                    return input;
                }

                string rotatedSubstring = input.Substring(input.Length - rotationAmount);
                string unrotatedSubstring = input.Substring(0, input.Length - rotationAmount);

                return rotatedSubstring + unrotatedSubstring;
            }
            catch (Exception ex)
            {
                _logger.Error("RotateCharacters Error", ex);
                return "";
            }
        }
    }
}
