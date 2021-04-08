namespace CodingPractices.BruteForce
{
    public class FindNumberIn2DArray
    {
        public bool Find(int[][] matrix, int target)
        {
            var n = matrix.Length - 1;
            var m = 0;

            while (n >= 0 && m < matrix[0].Length)
            {
                var corner = matrix[n][m];
                if (target == corner) return true;
                if (target > corner) m++;
                if (target < corner) n--;
            }

            return false;
        }

        public bool FindNumIn2DArray(int[,] matrix, int target)
        {
            var row = matrix.GetLength(0) - 1;
            var col = matrix.GetLength(1) - 1;
            int m = 0;
            int n = col;
            while (m <= row && n >= 0)
            {
                {
                    if (matrix[m, n] == target) return true;
                    if (target > matrix[m, n]) m++;
                    else
                    {
                        n--;
                    }
                }
            }

            return false;
        }
    }
}
