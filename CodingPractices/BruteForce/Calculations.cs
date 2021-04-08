using System.Collections.Generic;

namespace CodingPractices.BruteForce
{
    public class Calculations
    {
        public double MyPow(double x, int n)
        {
            if (n == 0) return 1;
            if (x.Equals(0)) return 0;
            if (x.Equals(1)) return 1;

            long exp = n; // avoid overflow
            if (n < 0)
            {
                return 1/PowerWithAbsExp(x, -exp);
            }

            return PowerWithAbsExp(x, exp);
        }

        private static double PowerWithAbsExp(double baseNum, long exponent)
        {
            if (exponent == 1)
            {
                return baseNum;
            }

            
            var res = PowerWithAbsExp(baseNum, exponent >> 1);
            res *= res;

            if ((exponent & 1) == 1) res *= baseNum;

            return res;
        }

        public double MyPow_Ref(double x, int n)
        {
            if (n == 0) return 1;
            if (x.Equals(0)) return 0;
            if (x.Equals(1)) return 1;

            long b = n;
            double res = 1.0;
            if (b < 0)
            {
                x = 1 / x;
                b = -b;
            }
            while (b > 0)
            {
                if ((b & 1) == 1) res *= x;
                x *= x;
                b >>= 1;
            }
            return res;
        }

        public int[] PrintNumbers(int n)
        {
            var ret = new List<int>();
            var path = new char[n];
            Dfs(ret, path, n);
            return ret.ToArray();
        }

        public void Dfs(IList<int> ret, char[] path, int n, int index = 0)
        {
            if (index == n)
            {
                AddValidResult(ret, path);
                return;
            }

            for (int i = 0; i < 10; i++)
            {
                path[index] = char.Parse(i.ToString());
                Dfs(ret, path, n, index + 1);
            }
        }

        private void AddValidResult(IList<int> ret, char[] path)
        {
            var result = new string(path).TrimStart('0');
            if (string.IsNullOrEmpty(result)) return;
            ret.Add(int.Parse(result));
        }

        public int[] Exchange(int[] nums)
        {
            if (nums == null || nums.Length == 0) return new int[0];

            var p1 = 0;
            var p2 = nums.Length - 1;

            while (p1 < p2)
            {
                while (p1 < p2 && IsOdd(nums[p1]))
                {
                    p1++;
                }

                while (p1 < p2 && !IsOdd(nums[p2]))
                {
                    p2--;
                }

                Swap(nums, p1, p2);
            }

            return nums;
        }

        private static void Swap(int[] nums, in int p1, in int p2)
        {
            var temp = nums[p1];
            nums[p1] = nums[p2];
            nums[p2] = temp;
        }

        private static bool IsOdd(int num)
        {
            return (num & 1) == 1;
        }
    }
}
