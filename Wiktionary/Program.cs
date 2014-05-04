using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiktionary
{
    class Program
    {
        private static string validChars = "abcdefghijklmnopqrstuvwxyzèêéñ";
        private static string[] validTypes = new string[]
        {
            "Noun",
            "Verb",
            "Adjective",
            "Adverb",
            "Article",
            "Preposition",
            "Interjection",
            "Pronoun",
            "Particle",
            "Determiner"
        };

        private static Dictionary<string, Definition> words = new Dictionary<string, Definition>();

        static void Main(string[] args)
        {
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader("..\\..\\wiktionary.tsv", System.Text.Encoding.UTF8);
            while((line = file.ReadLine()) != null)
            {
                string[] sections = line.Split('\t');
                if(sections[0] == "English")
                {
                    bool valid = true;
                    string word = sections[1];
                    if(word.Length >= 3 && word.Length <= 7)
                    {
                        foreach (char c in word)
                        {
                            if (!validChars.Contains(c))
                            {
                                valid = false;
                                break;
                            }
                        }
                        if (valid)
                        {
                            string type = sections[2];
                            if (validTypes.Contains(type))
                            {
                                string definition = sections[3];
                                if (!words.ContainsKey(word))
                                {
                                    words.Add(word, new Definition());
                                }
                                words[word].Add(definition);
                            }
                        }
                    }
                }
            }
            System.IO.StreamWriter output = new System.IO.StreamWriter("..\\..\\dictionary.json", false, System.Text.Encoding.UTF8);
            output.WriteLine("\"words\": {\n");
            foreach(KeyValuePair<string, Definition> w in words)
            {
                output.WriteLine("\t\"{0}\": \"{1}\",\n", w.Key, w.Value.Get());
            }
            output.WriteLine("}\n");
            Console.ReadLine();
        }
    }
}
