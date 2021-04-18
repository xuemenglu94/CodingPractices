using System.Collections.Generic;

namespace ProblemCollections.Offer
{
    public partial class Solution
    {
        public int[] SpiralOrder(int[][] matrix)
        {
            if (matrix == null) return null;
            var maxRow = matrix.GetLength(0) - 1;
            if (maxRow < 0) return new int[0];
            var maxCol = matrix[0].GetLength(0) - 1;
            if (maxCol < 0) return new int[0];

            var res = new List<int>();
            var minCol = 0;
            var minRow = 0;
            while (true)
            {
                if (maxCol < minCol) break;
                for (int c = minCol; c <= maxCol; c++)
                {
                    res.Add(matrix[minRow][c]);
                }
                minRow++;
                
                if (maxRow < minRow) break;
                for (int r = minRow; r <= maxRow; r++)
                {
                    res.Add(matrix[r][maxCol]);
                }
                maxCol--;

                if (maxCol < minCol) break;
                for (int c = maxCol; c >= minCol; c--)
                {
                    res.Add(matrix[maxRow][c]);
                }
                maxRow--;

                if (maxRow < minRow) break;
                for (int r = maxRow; r >= minRow; r--)
                {
                    res.Add(matrix[r][minCol]);
                }
                minCol++;
            }

            return res.ToArray();
        }
    }
}
