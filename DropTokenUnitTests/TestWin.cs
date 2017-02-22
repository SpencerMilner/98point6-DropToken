﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DropToken;
using System.IO;
using System.Diagnostics;
using System.Text;

namespace DropTokenUnitTests
{
    [TestClass]
    public class TestWin
    {
        // Expected Output
        const string WELCOME_MESSAGE = "You're Playing 98point6 Drop Token";
        const string LINEBREAK = "----------------------------------";
        const string PROMPT_PLAYER1 = "Player one, enter a command: ";
        const string PROMPT_PLAYER2 = "Player two, enter a command: ";

        const string EXIT = "EXIT";
        const string OK = "OK";
        const string WIN = "WIN";

        // Test Input
        const string PUT_COLUMN_ONE = "PUT 1";
        const string PUT_COLUMN_TWO = "PUT 2";
        const string PUT_COLUMN_THREE = "PUT 3";
        const string PUT_COLUMN_FOUR = "PUT 4";

        // Test Variables
        string testVal;
        string expected;
        string result;

        [TestMethod]
        public void testWin()
        {
            testVal = WIN;
            expected = buildTestWinExpectedOutput(testVal);
            result = runTestWin();
            Assert.AreEqual<string>(expected, result);
        }

        private string runTestWin()
        {
            string input = buildTestWinInput();
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

        private string buildTestWinInput()
        {
            string input = string.Format(PUT_COLUMN_ONE + "{0}", Environment.NewLine);
            for (short i = 0; i < 3; i++)
            {
                input += string.Format(PUT_COLUMN_TWO + "{0}" + PUT_COLUMN_ONE + "{0}", Environment.NewLine);
            }
            input += string.Format(EXIT + "{0}", Environment.NewLine);
            return input;
        }

        private string buildTestWinExpectedOutput(string testVal)
        {
            string expectedOutput = string.Format(
                        WELCOME_MESSAGE + "{0}" +
                        LINEBREAK + "{0}" + PROMPT_PLAYER1, Environment.NewLine);

            for (short i = 0; i < 3; i++)
            {

                expectedOutput += string.Format(OK + "{0}" + PROMPT_PLAYER2 + OK + "{0}"
                    + PROMPT_PLAYER1, Environment.NewLine);
            }

            expectedOutput += string.Format(testVal + "{0}" + PROMPT_PLAYER1, Environment.NewLine);
            return expectedOutput;
        }
    }
}