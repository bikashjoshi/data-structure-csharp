using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public class Trie
    {
        private class TrieNode
        {
            public TrieNode()
            {
                NestedDictionary = new Dictionary<char, TrieNode>();
            }

            public Dictionary<char, TrieNode> NestedDictionary { get; private set; }
        }

        private readonly TrieNode _node = new TrieNode();

        public void AddTexts(IEnumerable<string> texts)
        {
            foreach(var text in texts)
            {
                AddText(text);
            }
        }

        public void AddText(string text)
        {
            var node = _node;
            foreach (var c in text)
            {
                if (!node.NestedDictionary.ContainsKey(c))
                {
                    node.NestedDictionary[c] = new TrieNode();
                }

                node = node.NestedDictionary[c];
            }
        }

        public IEnumerable<string> Match(string prefix)
        {
            var matchedNode = Find(prefix);
            if (matchedNode == null)
            {
                return Enumerable.Empty<string>();
            }

            var matches = MatchInternal(matchedNode);
            return matches.Select(x => prefix + x);
        }

        private static IEnumerable<string> MatchInternal(TrieNode matchedNode)
        {
            var matches = new List<string>();
            foreach (var kvp in matchedNode.NestedDictionary)
            {
                var currentNode = kvp.Value;
                var currentKey = kvp.Key.ToString();
                var result = MatchInternal(kvp.Value);
                matches.AddRange(result.Select(x => currentKey + x));
            }

            if (matches.Count() == 0)
            {
                matches.Add(string.Empty); // End of word
            }

            return matches;
        }

        private TrieNode Find(string prefix)
        {
            var node = _node;
            foreach (char c in prefix)
            {
                if (node.NestedDictionary.ContainsKey(c))
                {
                    node = node.NestedDictionary[c];
                }
                else
                {
                    return null;
                }
            }

            return node;
        }       
    }
}
