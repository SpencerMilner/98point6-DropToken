using System;
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
        // Test Variables
        string testVal;
        string expected;
        string result;

        [TestMethod]
        public void testWin()
        {
            testVal = CONST.WIN;
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
            string input = string.Format(CONST.PUT_COLUMN_ONE + "{0}", Environment.NewLine);
            for (short i = 0; i < 3; i++)
            {
                input += string.Format(CONST.PUT_COLUMN_TWO + "{0}" + CONST.PUT_COLUMN_ONE + "{0}", Environment.NewLine);
            }
            input += string.Format(CONST.EXIT + "{0}", Environment.NewLine);
            return input;
        }

        private string buildTestWinExpectedOutput(string testVal)
        {
            string expectedOutput = string.Format(
                        CONST.WELCOME_MESSAGE + "{0}" +
                        CONST.LINEBREAK + "{0}" + CONST.PROMPT_PLAYER1, Environment.NewLine);

            for (short i = 0; i < 3; i++)
            {
                expectedOutput += string.Format(CONST.OK + "{0}" + CONST.PROMPT_PLAYER2 + CONST.OK + "{0}"
                    + CONST.PROMPT_PLAYER1, Environment.NewLine);
            }

            expectedOutput += string.Format(testVal + "{0}" + CONST.PROMPT_PLAYER1, Environment.NewLine);
            return expectedOutput;
        }
    }
}
