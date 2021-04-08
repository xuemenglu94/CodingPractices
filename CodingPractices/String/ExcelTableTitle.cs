using System.Collections.Generic;

namespace CodingPractices.String
{
    public class ExcelTableTitle
    {
        public string Get(int n)
        {
            if (n <= 0) return null;
            var res = new List<char>();
            while (n > 0)
            {
                res.Add((char) ('a' + n % 26 - 1));
                n /= 26;
            }
            res.Reverse();
            return new string(res.ToArray());
        }
    }
}
