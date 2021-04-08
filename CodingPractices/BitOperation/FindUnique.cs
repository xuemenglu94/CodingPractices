using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingPractices.BitOperation
{
    public class FindUnique
    {
        public int SingleValue(IList<int> input)
        {
            if (input == null || input.Count == 0) throw new Exception("Please enter input with at least one number");

            //int res = 0;
            //foreach (var value in input)
            //{
            //    res ^= value;
            //}

            //return res;
            return input.Aggregate(0, (current, value) => current ^ value);
        }

        public (int, int) TwoValues(IList<int> input)
        {
            if (input == null || input.Count == 0) throw new Exception("Please enter input with at least one number");

            var res = SingleValue(input);
            var partitionRef = PartitionRef(res);

            var group1 = new List<int>();
            var group2 = new List<int>();

            foreach (var value in input)
            {
                if (BelongToGroup(partitionRef, value))
                {
                    group1.Add(value);
                }
                else
                {
                    group2.Add(value);
                }
            }

            return (SingleValue(group1), SingleValue(group2));
        }

        private static bool BelongToGroup(int partitionRef, int value)
        {
            var res = partitionRef & value;
            return res == 0;
        }

        private static int PartitionRef(int res)
        {
            var reference = 1;
            while ((res & 1) == 0)
            {
                res >>= 1;
                reference <<= 1;
            }

            return reference;
        }
    }
}
