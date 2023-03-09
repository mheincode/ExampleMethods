using NLog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExampleMethods
{
    public static class AboveOrBelow
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public static Dictionary<string, int> CountAboveOrBelow(List<int> list, int comparisonValue)
        {
            try
            {
                int aboveCount = 0;
                int belowCount = 0;

                foreach (int num in list)
                {
                    if (num > comparisonValue)
                    {
                        aboveCount++;
                    }
                    else if (num < comparisonValue)
                    {
                        belowCount++;
                    }
                }

                Dictionary<string, int> result = new Dictionary<string, int>
                {
                    {"above", aboveCount},
                    {"below", belowCount}
                };

                return result;
            }
            catch (Exception ex)
            {
                _logger.Error("CountAboveOrBelow Error", ex);
                return new Dictionary<string, int>();
            }
        }

        public static Dictionary<string, int> CountAboveOrBelow2(List<int> integers, int comparisonValue)
        {
            try
            {
                Dictionary<string, int> result = new Dictionary<string, int>
            {
                { "above", 0 },
                { "below", 0 }
            };

                foreach (int integer in integers)
                {
                    if (integer > comparisonValue)
                    {
                        result["above"]++;
                    }
                    else if (integer < comparisonValue)
                    {
                        result["below"]++;
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.Error("CountAboveOrBelow2 Error", ex);
                return new Dictionary<string, int>();
            }
        }

        public static Dictionary<string, int> CountAboveOrBelow3(List<int> list, int comparisonValue)
        {
            try
            {
                AboveBelowComparer comparer = new AboveBelowComparer(comparisonValue);
                int aboveCount = list.Count(num => comparer.Compare(num, comparisonValue) > 0);
                int belowCount = list.Count(num => comparer.Compare(num, comparisonValue) < 0);

                Dictionary<string, int> result = new Dictionary<string, int>
            {
                {"above", aboveCount},
                {"below", belowCount}
            };

                return result;
            }
            catch (Exception ex)
            {
                _logger.Error("CountAboveOrBelow3 Error", ex);
                return new Dictionary<string, int>();
            }
        }

        public class AboveBelowComparer : IComparer<int>
        {
            private readonly int comparisonValue;

            public AboveBelowComparer(int comparisonValue)
            {
                this.comparisonValue = comparisonValue;
            }

            public int Compare(int x, int y)
            {
                try
                {
                    if (x > comparisonValue && y > comparisonValue)
                    {
                        return x.CompareTo(y);
                    }
                    else if (x < comparisonValue && y < comparisonValue)
                    {
                        return x.CompareTo(y);
                    }
                    else
                    {
                        return x > y ? 1 : -1;
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error("Compare Error", ex);
                    return 0;
                }
            }
        }
    }
}
