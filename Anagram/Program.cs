using System;
using System.Collections.Generic;

namespace Anagram
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Please enter arguments in format {sentence} {word}");
            }
            else
            {
                var output = FindAnagrams(args[0], args[1].Trim());

                Console.WriteLine(output);
            }
        }

        public static string FindAnagrams(string targetSentence, string word)
        {
            CharacterMap baseCharMap = new CharacterMap(word);

            var sentenceList = targetSentence.Split(" ");
            var outputList = new List<string>();
            foreach (var w in sentenceList)
            {
                if (IsAnagram(w, baseCharMap))
                    outputList.Add(w);
            }
            return string.Join(",", outputList);
        }

        public static bool IsAnagram(string targetWord, CharacterMap baseCharMap)
        {
            bool extraCharacter = false;
            foreach (var c in targetWord)
            {
                if (baseCharMap.ContainsKey(c))
                {
                    baseCharMap.IncrementCheckCount(c);
                }
                else
                {
                    extraCharacter = true;
                }
            }

            bool isAnagram = baseCharMap.IsInAnagramState && !extraCharacter;
            baseCharMap.ClearCheckCounts();
            return isAnagram;
        }
    }
}
