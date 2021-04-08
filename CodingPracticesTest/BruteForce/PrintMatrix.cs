using System;
using System.Collections.Generic;

namespace CodingPracticesTest.BruteForce
{
    public class PrintMatrix
    {
        public IList<int> Clockwise(int[,] matrix)
        {
            if (matrix == null) return null;
            var maxRow = matrix.GetLength(0);
            var maxCol = matrix.GetLength(1);
            if (maxRow == 0 || maxCol == 0) return null;

            var res = new List<int>();
            var left = 0;
            var right = maxCol - 1;
            var top = 0;
            var bottom = maxRow - 1;
            while (true)
            {
                if (left > right) break;
                for (int col = left; col <= right; col++) res.Add(matrix[top, col]);
                top++;

                if (bottom < top) break;
                for (int row = top; row <= bottom; row++) res.Add(matrix[row, right]);
                right--;

                if (left > right) break;
                for (int col = right; col >= left; col--) res.Add(matrix[bottom, col]);
                bottom--;

                if (bottom < top) break;
                for (int row = bottom; row >= top; row--) res.Add(matrix[row, left]);
                left++;
            }

            return res;
        }

        public int[] ClockWiseV0(int[,] matrix)
        {
            if (matrix == null) return null;

            var maxRow = matrix.GetLength(0);
            var maxCol = matrix.GetLength(1);
            if (maxRow == 0 || maxCol == 0) return null;

            var res = new List<int>();
            var round = Math.Min(maxRow, maxCol) >> 1;
            for (int i = 0; i <= round; i++)
            {
                Print(matrix, res, i, maxRow - 1, maxCol - 1);
            }

            return res.ToArray();
        }

        public void Print(int[,] matrix, List<int> res, int round, int maxRow, int maxColumn)
        {
            if (maxColumn - round < round) return;
            for (int column = round; column <= maxColumn - round; column++)
            {
                res.Add(matrix[round, column]);
            }

            if (maxRow - round < round + 1) return;
            for (int row = round + 1; row <= maxRow - round; row++)
            {
                res.Add(matrix[row, maxColumn - round]);
            }

            if (maxColumn - round - 1 < round) return;
            for (int column = maxColumn - round - 1; column >= round; column--)
            {
                res.Add(matrix[maxRow - round, column]);
            }

            if (maxRow - round - 1 < round + 1) return;
            for (int row = maxRow - round - 1; row >= round + 1; row--)
            {
                res.Add(matrix[row, round]);
            }
        }
    }
}
