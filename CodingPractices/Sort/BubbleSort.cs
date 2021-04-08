namespace CodingPractices.Sort
{
    public class BubbleSort
    {
        public int[] Sort(int[] array)
        {
            for (var i = 0; i < array.Length; i++)
            {
                for (var j = 0; j < array.Length - i - 1; j++)
                {
                    var bigger = array[j] > array[j + 1] ? array[j] : array[j + 1];
                    if (bigger == array[j + 1]) continue;
                    array[j] = array[j + 1];
                    array[j + 1] = bigger;
                }
            }
            return array;
        }
    }
}
