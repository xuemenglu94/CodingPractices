using System.Collections.Generic;
using System.Linq;

namespace CodingPractices.Tree
{
    public class DictionaryTree
    {
        public IList<string> FindRepeatedWords(IList<string> input)
        {
            var repeated = new List<string>();
            if (input == null || input.Count == 0) return repeated;

            var root = new DictionaryTreeNode();
            foreach (var word in input)
            {
                var node = root;
                foreach (var character in word)
                {
                    var existed = node.Children.FirstOrDefault(c => c?.Value == character);
                    if (existed == null)
                    {
                        var newChild = new DictionaryTreeNode(character);
                        node.Children.Add(newChild);
                        node = newChild;
                    }
                    else
                    {
                        node = existed;
                    }
                }

                if (node.WordEnd && !repeated.Contains(word)) repeated.Add(word);

                node.WordEnd = true;
            }

            return repeated;
        }
    }

    public class DictionaryTreeNode
    {
        public DictionaryTreeNode()
        {
            Children = new List<DictionaryTreeNode>();
        }

        public DictionaryTreeNode(char value)
        {
            Value = value;
            Children = new List<DictionaryTreeNode>();
        }

        public char Value { get; set; }
        public IList<DictionaryTreeNode> Children { get; set; }
        public bool WordEnd { get; set; } = false; // C# 6 or higher
    }
}
