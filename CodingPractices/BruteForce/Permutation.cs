using System.Collections.Generic;
using System.Linq;

namespace CodingPractices.BruteForce
{
    public class Permutation
    {
        public List<List<int>> Permute(int[] nums)
        {
            List<List<int>> res = new List<List<int>>();
            var path = new LinkedList<int>();
            var depth = nums.Length;
            var used = new bool[depth];
            dfs(nums, path, res, used, depth);
            return res;
        }

        private void dfs(int[] nums, LinkedList<int> path, IList<List<int>> res, IList<bool> used, int depth)
        {
            if (path.Count == depth)
            {
                res.Add(new List<int>(path));
                return;
            }

            for (int i = 0; i < depth; i++)
            {
                if (used[i])
                {
                    continue;
                }

                path.AddLast(nums[i]);
                used[i] = true;

                dfs(nums, path, res, used, depth);

                path.RemoveLast();
                used[i] = false;
            }
        }

        public List<string> PermuteString(string input)
        {
            var charArray = input.ToCharArray();
            var depth = charArray.Length;
            var path = new Stack<char>();
            var used = new bool[depth];
            var res = new List<string>();
            DfsString(charArray, res, path, used, depth);
            return res;
        }

        private void DfsString(char[] charArray, List<string> res, Stack<char> path, bool[] used, in int depth)
        {
            if (path.Count == depth)
            {
                res.Add(new string(path.Aggregate(string.Empty, (a, b) => a+b)));
            }

            for (int i = 0; i < depth; i++)
            {
                if (used[i])
                {
                    continue;
                }

                path.Push(charArray[i]);
                used[i] = true;

                DfsString(charArray, res, path, used, depth);

                path.Pop();
                used[i] = false;
            }
        }
    }
}
