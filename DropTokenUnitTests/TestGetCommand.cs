using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DropToken;
using System.IO;
using System.Diagnostics;
using System.Text;

namespace DropTokenUnitTests
{
    [TestClass]
    public class TestGetCommand
    {
        // Expected Output
        const string WELCOME_MESSAGE = "You're Playing 98point6 Drop Token";
        const string LINEBREAK = "----------------------------------";
        const string PROMPT_PLAYER1 = "Player one, enter a command: ";
        const string PROMPT_PLAYER2 = "Player two, enter a command: ";
        const string ERROR = "ERROR";
        const string EXIT = "EXIT";
        const string OK = "OK";
        // Test Input
        const string INVALID_COMMAND = "-AbQ&# ";
        const string PUT_COLUMN_ONE = "PUt 1";
        const string PUT_COLUMN_TWO = "PuT 2";
        const string PUT_COLUMN_THREE = "pUT 3";
        const string PUT_COLUMN_FOUR = "PUT 4";
        const string GET = "GeT";
        const string GET_SPACES = " GET ";
        const string GET_WITH_EXTRA_PARAMETER = "GET 2";

        // Test Variables
        string testVal;
        string expected;
        string result;

        [TestMethod]
        public void testGet()
        {
            testVal = GET;
            expected = buildTestGetExpectedOutput();
            result = runTestGet(testVal);
            Assert.AreEqual<string>(expected, result);
        }

        private string runTestGet(string testVal)
        {
            string input = buildTestGetInput(testVal);

            using (var sw = new StringWriter())
            {
                using (var sr = new StringReader(input))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);
                    DropToken.Program.Main();
                    return sw.ToString();
                }
            }
        }

        private string buildTestGetInput(string testVal)
        {
            string input = string.Empty;
            for (short i = 0; i < 3; i++)
            {
                input += string.Format(PUT_COLUMN_ONE + "{0}" 
                    + PUT_COLUMN_TWO + "{0}"
                    + PUT_COLUMN_THREE + "{0}"
                    + INVALID_COMMAND + "{0}"
                    + PUT_COLUMN_FOUR + "{0}", Environment.NewLine);
            }
            input += string.Format(testVal + "{0}" + EXIT + "{0}", Environment.NewLine);
            return input;
        }

        private string buildTestGetExpectedOutput()
        {
            string expectedOutput = string.Format(
                        WELCOME_MESSAGE + "{0}" +
                        LINEBREAK + "{0}", Environment.NewLine);

            for (short i = 0; i < 3; i++)
            {
                expectedOutput += string.Format(
                    PROMPT_PLAYER1 + OK + "{0}" + PROMPT_PLAYER2 + OK + "{0}"
                    + PROMPT_PLAYER1 + OK + "{0}" + PROMPT_PLAYER2 + ERROR + "{0}"
                    + PROMPT_PLAYER2 + OK + "{0}", Environment.NewLine);
            }
            expectedOutput += PROMPT_PLAYER1;
            for(short i = 0; i < 3; i++)
            {
                expectedOutput += string.Format(
                    "1{0}2{0}3{0}4{0}", Environment.NewLine);
            }

            expectedOutput += PROMPT_PLAYER1;

            return expectedOutput;
        }
    }
}

