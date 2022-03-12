using System.Collections.Generic;
using System.Linq;

namespace Anagram
{
    public class CharacterMap 
    {
        public Dictionary<char, ItemCount> Map { get; set; }

        public bool IsInAnagramState => !Map.Values.Any(x => x.itemCount != x.checkCount);

        public CharacterMap(string word)
        {
            var characterMap = new Dictionary<char, ItemCount>();
            foreach (var c in word)
            {
                if (characterMap.ContainsKey(c))
                {
                    characterMap[c].itemCount++;
                }
                else
                {
                    characterMap.Add(c, new ItemCount { itemCount = 1, checkCount = 0 });
                }
            }

            this.Map = characterMap;
        }

        public bool ContainsKey(char key)
        {
            return Map.ContainsKey(key);
        }

        public void IncrementCheckCount(char key)
        {
            Map[key].checkCount++;
        }

        public void ClearCheckCounts()
        {
            foreach(var record in Map)
            {
                record.Value.checkCount = 0;
            }
        }
    }

}
