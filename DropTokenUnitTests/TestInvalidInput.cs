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
        // Expected Output
        const string WELCOME_MESSAGE = "You're Playing 98point6 Drop Token";
        const string LINEBREAK = "----------------------------------";
        const string PROMPT_PLAYER1 = "Player one, enter a command: ";
        const string PROMPT_PLAYER2 = "Player two, enter a command: ";
        const string ERROR = "ERROR";
        const string EXIT = "EXIT";
        const string OK = "OK";
        const string WIN = "WIN";
        const string DRAW = "DRAW";
        // Test Input
        const string INVALID_COMMAND = "-AbQ&# ";
        const string INVALID_SECOND_PARAM = "GET GET";
        const string INVALID_COMMAND_EXTRALETTER = "GETT";
        const string INVALID_COMMAND_LARGEVALUE = "99999999999999999999";
        const string INVALID_COMMAND_EMPTY = "";
        const string PUT_COLUMN_EDGECASE_LOW = "PUT 0";
        const string PUT_COLUMN_EDGECASE_HIGH = "PUT 5";
        const string PUT_COLUMN_NEGATIVE = "PUT -1";
        const string PUT_COLUMN_INVALID = "PUT GET";
        const string PUT_COLUMN_EMPTY = "PUT ";
        const string PUT_COLUMN_EXTRA_PARAMETER = "PUT 1 1";
        const string PUT_COLUMN_DECIMAL = "PUT 1.8";
        const string PUT_COLUMN_ONE = "PUT 1";
        const string PUT_COLUMN_TWO = "PUT 2";
        const string PUT_COLUMN_THREE = "PUT 3";
        const string PUT_COLUMN_FOUR = "PUT 4";
        const string GET = "GET";
        const string INVALID_COMMAND_SPACES = " GET ";

        // Test Variables
        string testVal;
        string expected;
        string result;

        [TestMethod]
        public void testInvalidCommand()
        {
            testVal = INVALID_COMMAND;
            expected = buildErrorTestExpectedOutputString();
            result = runErrorTestWithValue(testVal);
            Assert.AreEqual<string>(expected, result);

            testVal = INVALID_COMMAND_SPACES;
            expected = buildErrorTestExpectedOutputString();
            result = runErrorTestWithValue(testVal);
            Assert.AreEqual<string>(expected, result);

            testVal = INVALID_COMMAND_EXTRALETTER;
            expected = buildErrorTestExpectedOutputString();
            result = runErrorTestWithValue(testVal);
            Assert.AreEqual<string>(expected, result);

            testVal = INVALID_SECOND_PARAM;
            expected = buildErrorTestExpectedOutputString();
            result = runErrorTestWithValue(testVal);
            Assert.AreEqual<string>(expected, result);

            testVal = INVALID_COMMAND_EMPTY;
            expected = buildErrorTestExpectedOutputString();
            result = runErrorTestWithValue(testVal);
            Assert.AreEqual<string>(expected, result);

            testVal = INVALID_COMMAND_LARGEVALUE;
            expected = buildErrorTestExpectedOutputString();
            result = runErrorTestWithValue(testVal);
            Assert.AreEqual<string>(expected, result);
        }

        [TestMethod]
        public void testPutInvalidColumnValues()
        {
            testVal = PUT_COLUMN_EDGECASE_LOW;
            expected = buildErrorTestExpectedOutputString();
            result = runErrorTestWithValue(testVal);
            Assert.AreEqual<string>(expected, result);

            testVal = PUT_COLUMN_EDGECASE_HIGH;
            expected = buildErrorTestExpectedOutputString();
            result = runErrorTestWithValue(testVal);
            Assert.AreEqual<string>(expected, result);

            testVal = PUT_COLUMN_NEGATIVE;
            expected = buildErrorTestExpectedOutputString();
            result = runErrorTestWithValue(testVal);
            Assert.AreEqual<string>(expected, result);

            testVal = PUT_COLUMN_INVALID;
            expected = buildErrorTestExpectedOutputString();
            result = runErrorTestWithValue(testVal);
            Assert.AreEqual<string>(expected, result);

            testVal = PUT_COLUMN_EMPTY;
            expected = buildErrorTestExpectedOutputString();
            result = runErrorTestWithValue(testVal);
            Assert.AreEqual<string>(expected, result);

            testVal = PUT_COLUMN_EXTRA_PARAMETER;
            expected = buildErrorTestExpectedOutputString();
            result = runErrorTestWithValue(testVal);
            Assert.AreEqual<string>(expected, result);

            testVal = PUT_COLUMN_DECIMAL;
            expected = buildErrorTestExpectedOutputString();
            result = runErrorTestWithValue(testVal);
            Assert.AreEqual<string>(expected, result);
        }

        private string buildErrorTestExpectedOutputString()
        {
            return string.Format(
                        WELCOME_MESSAGE + "{0}" +
                        LINEBREAK + "{0}" +
                        PROMPT_PLAYER1 +
                        ERROR + "{0}" +
                        PROMPT_PLAYER1, Environment.NewLine);
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
