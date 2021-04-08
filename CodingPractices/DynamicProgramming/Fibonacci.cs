using System;

namespace CodingPractices.DynamicProgramming
{
    public class Fibonacci
    {
        public int FibonacciOfIndex(int N)
        {
            if (N < 1) throw new Exception("Please enter a valid index of fibonacci sequence");
            if (N == 1 || N == 2) return 1;
            var prev = 1;
            var cur = 1;
            for (int i = 3; i <= N; i++)
            {
                var sum = prev + cur;
                prev = cur;
                cur = sum;
            }

            return (int) (cur % (1e9 + 7));
        }

        public int Fib_dp(int N)
        {
            if (N < 1) throw new Exception("Please enter a valid index of fibonacci sequence");
            if (N == 1 || N == 2) return 1;
            int[] dp = new int[N + 1];
            dp[1] = dp[2] = 1;
            for (int i = 3; i <= N; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }

            return dp[N];
        }
    }
}
