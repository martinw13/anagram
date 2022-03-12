using Moq;
using NUnit.Framework;
using System.Linq;

namespace Anagram.test
{
    public class Tests
    {

        private CharacterMap testCharacterMap;

        [SetUp]
        public void Setup()
        {
            testCharacterMap = new CharacterMap("test");
        }

        [Test]
        [TestCase("the dog is cute", "dog", "dog")]
        [TestCase("dog ogd god", "dog", "dog,ogd,god")]
        [TestCase("dog2 ogd2 god", "dog", "god")]
        [TestCase("!@# #@! @#!", "!@#", "!@#,#@!,@#!")]
        [TestCase("this is a dogg and a ggod odgg", "dogg", "dogg,ggod,odgg")]
        public void TestAnagram(string sentence, string word, string expectedValue)
        {
            // arrange

            // act 
            var output = Program.FindAnagrams(sentence, word);
            //assert
            Assert.AreEqual(output, expectedValue);
        }

        [Test]
        [TestCase("the dog is cute", "cat")]
        public void TestAnagramNoMatches(string sentence, string word)
        {
            // arrange

            // act
            var output = Program.FindAnagrams(sentence, word);

            // assert
            Assert.AreEqual(output, string.Empty);
        }

        [Test]
        [TestCase("test", true)]
        [TestCase("test2", false)]
        [TestCase("te st", false)]
        [TestCase("test ", false)]
        [TestCase("testtest", false)]
        [TestCase("@test@", false)]
        [TestCase("Test", false)]
        public void TestAnagramSingular_and_CheckCountResets(string testWord, bool expectedValue)
        {
            // arrange

            // act
            var output = Program.IsAnagram(testWord, testCharacterMap);

            // assert
            Assert.AreEqual(output, expectedValue);
            Assert.That(testCharacterMap.Map.Values.Select(x => x.checkCount), Is.All.EqualTo(0)) ;
        }
    }
}