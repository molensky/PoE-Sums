using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PoeSums.Test
{
    public class PoeSumsTest
    {
        private PoeSums _poeSums;

        [SetUp]
        public void TestSetUp()
        {
            _poeSums = new PoeSums();
        }

        [Test]
        public void TestEmptyInput_ExpectEmptyOutput()
        {
            _poeSums.GetMatches(new int[] {});
            Assert.Multiple(() =>
            {
                Assert.AreEqual(0, _poeSums.BestMatch[0].Count);
                Assert.AreEqual(0, _poeSums.Total);
            });
        }

        [Test]
        public void TestZeroInput_ExpectEmptyOutput()
        {
            _poeSums.GetMatches(new int[] { 0 });
            Assert.AreEqual(0, _poeSums.BestMatch[0].Count);
            Assert.AreEqual(0, _poeSums.Total);
        }

        [Test]
        public void TestInputThatDoesNotAddUpToForty_ExpectEmptyOutput()
        {
            _poeSums.GetMatches(new int[] { 1 });
            Assert.AreEqual(0, _poeSums.BestMatch[0].Count);
            Assert.AreEqual(1, _poeSums.Total);
        }

        [Test]
        public void TestInputThatDoesNotAddUpToFortyContainsTwenty_ExpectListOfSingleTwenty()
        {
            _poeSums.GetMatches(new int[] { 1, 20 });
            Assert.AreEqual(new int[] { 20 }, _poeSums.BestMatch[0].ToArray());
            Assert.AreEqual(21, _poeSums.Total);
        }

        [Test]
        public void TestInputThatAddsUpToForty_ExpectFourEntries()
        {
            _poeSums.GetMatches(new int[] { 10, 10, 10, 10 });
            Assert.AreEqual(4, _poeSums.BestMatch[0].Count);
            Assert.AreEqual(40, _poeSums.Total);
        }

        [Test]
        public void TestInputThatAddsUpToFortyOne_ExpectFourEntries()
        {
            _poeSums.GetMatches(new int[] { 1, 10, 10, 10, 10 });
            Assert.AreEqual(41, _poeSums.Total);
            Assert.AreEqual(4, _poeSums.BestMatch[0].Count);
            Assert.AreEqual(new int[] { 10, 10, 10, 10 }, _poeSums.BestMatch[0].ToArray());
        }

        [Test]
        public void TestFiveInputsWithMultipleFortySums_ExpectThreeEntryList()
        {
            _poeSums.GetMatches(new int[] { 19, 18, 3, 2, 1 });
            Assert.AreEqual(43, _poeSums.Total);
            Assert.AreEqual(3, _poeSums.BestMatch[0].Count);
            Assert.AreEqual(new int[] { 19, 18, 3 }, _poeSums.BestMatch[0].ToArray());
            Assert.AreEqual(1, _poeSums.BestMatch.Count);
        }

        [Test]
        public void TestSixInputsWithMultipleFortySums_ExpectTwoThreeEntryLists()
        {
            _poeSums.GetMatches(new int[] { 19, 18, 3, 15, 15, 10 });
            Assert.AreEqual(80, _poeSums.Total);
            Assert.AreEqual(2, _poeSums.BestMatch.Count);
            Assert.AreEqual(3, _poeSums.BestMatch[0].Count);
            Assert.AreEqual(3, _poeSums.BestMatch[1].Count);

            var match1 = new List<int> { 19, 18, 3 };
            var match2 = new List<int> { 15, 15, 10 };

            Assert.IsTrue(_poeSums.BestMatch.Any(c => c.SequenceEqual(match1)));
            Assert.IsTrue(_poeSums.BestMatch.Any(c => c.SequenceEqual(match2)));
        }

        [Test]
        public void TestEightTensWithTwoFortySums_ExpectTwoFourEntryLists()
        {
            _poeSums.GetMatches(new int[] { 10, 10, 10, 10, 10, 10, 10, 10 });
            Assert.AreEqual(80, _poeSums.Total);
            Assert.AreEqual(2, _poeSums.BestMatch.Count);
            Assert.AreEqual(4, _poeSums.BestMatch[0].Count);
            Assert.AreEqual(4, _poeSums.BestMatch[1].Count);

            var match = new int[] { 10, 10, 10, 10 };

            Assert.AreEqual(match, _poeSums.BestMatch[0].ToArray());
            Assert.AreEqual(match, _poeSums.BestMatch[1].ToArray());
        }

        [Test]
        public void TestBestMatchesExpectOneList()
        {
            _poeSums.GetMatches(new int[] { 15, 15, 15, 10 ,10, 11, 9 });
            Assert.AreEqual(85, _poeSums.Total);
            Assert.AreEqual(1, _poeSums.BestMatch.Count);
            Assert.AreEqual(3, _poeSums.BestMatch[0].Count);
            
            var match = new List<int> { 15, 15, 10 };
            Assert.IsTrue(_poeSums.BestMatch.Any(c => c.SequenceEqual(match)));
        }

    }
}
