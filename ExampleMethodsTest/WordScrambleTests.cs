using ExampleMethods;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AboveOrBelowTests
{
    [TestClass]
    public class StringRotationTests
    {
        [TestMethod]
        public void RotateString_ShouldReturnOriginalString_WhenRotationAmountIsZero()
        {
            string input = "MyString";
            int rotationAmount = 8;

            string result = WordScramble.RotateCharacters(input, rotationAmount);

            Assert.AreEqual(input, result);
        }

        [TestMethod]
        public void RotateString_ShouldRotateStringByRotationAmount()
        {

            string input = "MyString";
            int rotationAmount = 2;

            string result = WordScramble.RotateCharacters(input, rotationAmount);

            Assert.AreEqual("ngMyStri", result);
        }

        [TestMethod]
        public void RotateString_ShouldHandleRotationAmountGreaterThanStringLength()
        {
            string input = "MyString";
            int rotationAmount = 10;

            string result = WordScramble.RotateCharacters(input, rotationAmount);

            Assert.AreEqual("ngMyStri", result);
        }
    }
}
