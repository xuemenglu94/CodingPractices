using System;

namespace CodingPractices.DynamicProgramming
{
    public class FindLongest
    {
        public string Palindrome(string input)
        {
            string ans = "";
            if (string.IsNullOrEmpty(input)) return ans;
            
            int n = input.Length;
            int start = 0;
            int length = 0;
            for (int i = 0; i < n; i++)
            {
                int oddPalindromeLength = ExpandFromCenter(input, n, i, i);
                int evenPalindromeLength = ExpandFromCenter(input, n, i, i + 1);
                int palindromeLength = Math.Max(oddPalindromeLength, evenPalindromeLength);

                if (palindromeLength <= length) continue;

                start = i - (palindromeLength - 1) / 2;
                length = palindromeLength;
            }

            return input.Substring(start, length);
        }

        private int ExpandFromCenter(string input, int length, int start, int end)
        {
            while (start >= 0 && end < length && input[start] == input[end])
            {
                start--;
                end++;
            }

            return end - start - 1;
        }

        public string Palindrome_dp(string s)
        {
            string ans = "";
            if (string.IsNullOrEmpty(s)) return ans;

            int n = s.Length;
            bool[,] dp = new bool[n, n];

            for (int length = 0; length < n; ++length)
            {
                for (int leftIndex = 0; leftIndex + length < n; ++leftIndex)
                {
                    int rightIndex = leftIndex + length;
                    if (length == 0)
                    {
                        dp[leftIndex,rightIndex] = true;
                    }
                    else if (length == 1)
                    {
                        dp[leftIndex,rightIndex] = (s[leftIndex] == s[rightIndex]);
                    }
                    else
                    {
                        dp[leftIndex,rightIndex] = (s[leftIndex] == s[rightIndex] && dp[leftIndex + 1,rightIndex - 1]);
                    }
                    if (dp[leftIndex,rightIndex] && length+1 > ans.Length)
                    {
                        ans = s.Substring(leftIndex, leftIndex + length+1);
                    }
                }
            }

            return ans;
        }

        public int CommonSubSequence(string a, string b)
        {
            int m = a.Length;
            int n = b.Length;
            if (m == 0 || n == 0) return 0;

            int[,] dp = new int[m + 1, n + 1];
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (a[i - 1] == b[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }

            return dp[m, n];
        }

        public int CommonSubString(string a, string b)
        {
            int m = a.Length;
            int n = b.Length;
            if (m == 0 || n == 0) return 0;

            int[,] dp = new int[m+1, n+1];
            int longest = 0;
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if(a[i - 1] == b[j - 1]) 
                        dp[i, j] = dp[i - 1, j - 1] + 1;

                    longest = dp[i, j] > longest
                        ? dp[i, j]
                        : longest;
                }
            }

            return longest;
        }
    }
}
