using System;

namespace ConsoleTestApp.specs
{
    internal class TrieSpecs
    {
        public static void RunSample()
        {
            Console.WriteLine(Environment.NewLine + "******************** RUNNING TRIE SAMPLE ********************");
            var trieNode = new Common.Trie();
            trieNode.AddTexts(new[] { "dog", "deer", "deal", "deamon", "dent" });
            var matches = trieNode.Match("dea");
            Console.WriteLine("Printing tries matching dea ...");
            foreach (var match in matches)
            {
                Console.WriteLine(match);
            }
            Console.WriteLine("******************** COMPLETED ********************");
        }
    }
}
