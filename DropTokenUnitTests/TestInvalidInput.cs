using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DropToken;
using System.IO;
using System.Diagnostics;
using System.Text;

namespace DropTokenUnitTests
{
    [TestClass]
    public class DropTokenUnitTests
    {
        // Test Variables
        string testVal;
        string expected;
        string result;

        [TestMethod]
        public void testInvalidCommand()
        {
            testVal = CONST.INVALID_COMMAND;
            expected = buildErrorTestExpectedOutputString();
            result = runErrorTestWithValue(testVal);
            Assert.AreEqual<string>(expected, result);

            testVal = CONST.INVALID_COMMAND_SPACES;
            expected = buildErrorTestExpectedOutputString();
            result = runErrorTestWithValue(testVal);
            Assert.AreEqual<string>(expected, result);

            testVal = CONST.INVALID_COMMAND_EXTRALETTER;
            expected = buildErrorTestExpectedOutputString();
            result = runErrorTestWithValue(testVal);
            Assert.AreEqual<string>(expected, result);

            testVal = CONST.INVALID_SECOND_PARAM;
            expected = buildErrorTestExpectedOutputString();
            result = runErrorTestWithValue(testVal);
            Assert.AreEqual<string>(expected, result);

            testVal = CONST.INVALID_COMMAND_EMPTY;
            expected = buildErrorTestExpectedOutputString();
            result = runErrorTestWithValue(testVal);
            Assert.AreEqual<string>(expected, result);

            testVal = CONST.INVALID_COMMAND_LARGEVALUE;
            expected = buildErrorTestExpectedOutputString();
            result = runErrorTestWithValue(testVal);
            Assert.AreEqual<string>(expected, result);
        }

        [TestMethod]
        public void testPutInvalidColumnValues()
        {
            testVal = CONST.PUT_COLUMN_EDGECASE_LOW;
            expected = buildErrorTestExpectedOutputString();
            result = runErrorTestWithValue(testVal);
            Assert.AreEqual<string>(expected, result);

            testVal = CONST.PUT_COLUMN_EDGECASE_HIGH;
            expected = buildErrorTestExpectedOutputString();
            result = runErrorTestWithValue(testVal);
            Assert.AreEqual<string>(expected, result);

            testVal = CONST.PUT_COLUMN_NEGATIVE;
            expected = buildErrorTestExpectedOutputString();
            result = runErrorTestWithValue(testVal);
            Assert.AreEqual<string>(expected, result);

            testVal = CONST.PUT_COLUMN_INVALID;
            expected = buildErrorTestExpectedOutputString();
            result = runErrorTestWithValue(testVal);
            Assert.AreEqual<string>(expected, result);

            testVal = CONST.PUT_COLUMN_EMPTY;
            expected = buildErrorTestExpectedOutputString();
            result = runErrorTestWithValue(testVal);
            Assert.AreEqual<string>(expected, result);

            testVal = CONST.PUT_COLUMN_EXTRA_PARAMETER;
            expected = buildErrorTestExpectedOutputString();
            result = runErrorTestWithValue(testVal);
            Assert.AreEqual<string>(expected, result);

            testVal = CONST.PUT_COLUMN_DECIMAL;
            expected = buildErrorTestExpectedOutputString();
            result = runErrorTestWithValue(testVal);
            Assert.AreEqual<string>(expected, result);
        }

        private string buildErrorTestExpectedOutputString()
        {
            return string.Format(
                        CONST.WELCOME_MESSAGE + "{0}" +
                        CONST.LINEBREAK + "{0}" +
                        CONST.PROMPT_PLAYER1 +
                        CONST.ERROR + "{0}" +
                        CONST.PROMPT_PLAYER1, Environment.NewLine);
        }

        private string runErrorTestWithValue(string testVal)
        {
            using (var sw = new StringWriter())
            {
                using (var sr = new StringReader(String.Format(testVal + "{0}EXIT{0}"
                , Environment.NewLine)))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);
                    DropToken.Program.Main();
                    return sw.ToString();
                }
            }
        }
    }
}
