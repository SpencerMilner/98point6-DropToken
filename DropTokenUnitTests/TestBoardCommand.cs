using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DropToken;
using System.IO;
using System.Diagnostics;
using System.Text;

namespace DropTokenUnitTests
{
    [TestClass]
    public class TestBoardCommand
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
        const string BOARD = "BOARD";
        // Test Input
        const string INVALID_COMMAND = "-AbQ&# ";
        const string INVALID_COMMAND_LARGEVALUE = "99999999999999999999";
        const string INVALID_COMMAND_EMPTY = "";
        const string PUT_COLUMN_ONE = "PUT 1";
        const string PUT_COLUMN_TWO = "PUT 2";
        const string PUT_COLUMN_THREE = "PUT 3";
        const string PUT_COLUMN_FOUR = "PUT 4";

        const int ARRAY_MAX = 3; // 0-3 for 4x4 board

        // Test Variables
        string testVal;
        string expected;
        string result;

        [TestMethod]
        public void testBoard()
        {
            testVal = BOARD;
            expected = buildTestBoardExpectedOutput(testVal);
            result = runTestBoard();
            Assert.AreEqual<string>(expected, result);
        }

        private string buildTestBoardExpectedOutput(string testVal)
        {
            string expectedOutput = string.Format(
                        WELCOME_MESSAGE + "{0}" +
                        LINEBREAK + "{0}", Environment.NewLine);

            for (short i = 0; i < 7; i++)
            {
                expectedOutput += string.Format(PROMPT_PLAYER1 + OK + "{0}"
                    + PROMPT_PLAYER2 + OK + "{0}", Environment.NewLine);
            }

            expectedOutput += string.Format(PROMPT_PLAYER1 + OK + "{0}"
                + PROMPT_PLAYER2 + DRAW + "{0}" + PROMPT_PLAYER2 + drawBoard() + PROMPT_PLAYER2, Environment.NewLine);


            return expectedOutput;
        }

        private string drawBoard()
        {
            string output = string.Empty;
            output += string.Format("\n| 2 1 2 1{0}",Environment.NewLine);

            for (int i = 0; i < 3; i++)
            {
                output += string.Format("\n| 1 2 1 2");

                output += Environment.NewLine;
            }
            return output += string.Format("\n+--------\n\n  1 2 3 4\n{0}", Environment.NewLine);
        }

        private string runTestBoard()
        {
            string input = buildTestBoardInput();
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

        private string buildTestBoardInput()
        {
            string input = string.Empty;

            for (short i = 0; i < 3; i++)
            {
                input += string.Format(PUT_COLUMN_ONE + "{0}" + PUT_COLUMN_TWO
                    + "{0}" + PUT_COLUMN_THREE + "{0}"
                    + PUT_COLUMN_FOUR + "{0}", Environment.NewLine);
            }

            input += string.Format(PUT_COLUMN_FOUR + "{0}" + PUT_COLUMN_THREE
                + "{0}" + PUT_COLUMN_TWO + "{0}"
                + PUT_COLUMN_ONE + "{0}", Environment.NewLine);

            input += string.Format(BOARD + "{0}" + EXIT + "{0}", Environment.NewLine);

            return input;
        }
    }
}
