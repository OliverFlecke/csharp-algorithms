// Leetcode: https://leetcode.com/problems/design-add-and-search-words-data-structure/

namespace Algorithms;

public class WordDictionary {
    // Idea is to build a Trie to add and search through

    public class Node {
        public char Value { get; }
        public IDictionary<char, Node> Children { get; } = new Dictionary<char, Node>();

        public Node(char value) {
            Value = value;
        }

        public bool Search(string word, int index) {
            if (index >= word.Length) {
                return Children.ContainsKey('$'); // If we just return true here, we will be checking for string **prefixes**
            }

            var c = word[index];
            if (c == '.') // Handle any case
            {
                foreach (var child in Children.Values) {
                    if (child.Search(word, index + 1)) {
                        return true;
                    }
                }
            }
            else if (Children.ContainsKey(c))
            {
                return Children[c].Search(word, index + 1);
            }

            return false;
        }

        public void Add(string word, int index) {
            if (index >= word.Length) {
                Children['$'] = new Node('$'); // Special node to check that a word ends here.
                return;
            }

            var c = word[index];
            if (!Children.ContainsKey(c)) {
                Children.Add(c, new Node(c));
            }

            Children[c].Add(word, index + 1);
        }
    }

    private Node root = new Node('^');

    public void AddWord(string word) {
        root.Add(word, 0);
    }

    public bool Search(string word) {
        return root.Search(word, 0);
    }
}
