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
        // Test Variables
        string testVal;
        string expected;
        string result;

        [TestMethod]
        public void testBoard()
        {
            testVal = CONST.BOARD;
            expected = buildTestBoardExpectedOutput(testVal);
            result = runTestBoard();
            Assert.AreEqual<string>(expected, result);
        }

        private string buildTestBoardExpectedOutput(string testVal)
        {
            string expectedOutput = string.Format(
                        CONST.WELCOME_MESSAGE + "{0}" +
                        CONST.LINEBREAK + "{0}", Environment.NewLine);

            for (short i = 0; i < 7; i++)
            {
                expectedOutput += string.Format(CONST.PROMPT_PLAYER1 + CONST.OK + "{0}"
                    + CONST.PROMPT_PLAYER2 + CONST.OK + "{0}", Environment.NewLine);
            }

            expectedOutput += string.Format(CONST.PROMPT_PLAYER1 + CONST.OK + "{0}"
                + CONST.PROMPT_PLAYER2 + CONST.DRAW + "{0}" + CONST.PROMPT_PLAYER2 + drawBoard() + CONST.PROMPT_PLAYER2, Environment.NewLine);


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
                input += string.Format(CONST.PUT_COLUMN_ONE + "{0}" + CONST.PUT_COLUMN_TWO
                    + "{0}" + CONST.PUT_COLUMN_THREE + "{0}"
                    + CONST.PUT_COLUMN_FOUR + "{0}", Environment.NewLine);
            }

            input += string.Format(CONST.PUT_COLUMN_FOUR + "{0}" + CONST.PUT_COLUMN_THREE
                + "{0}" + CONST.PUT_COLUMN_TWO + "{0}"
                + CONST.PUT_COLUMN_ONE + "{0}", Environment.NewLine);

            input += string.Format(CONST.BOARD + "{0}" + CONST.EXIT + "{0}", Environment.NewLine);

            return input;
        }
    }
}
