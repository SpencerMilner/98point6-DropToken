using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DropToken;
using System.IO;
using System.Diagnostics;
using System.Text;

namespace DropTokenUnitTests
{
    [TestClass]
    public class TestDraw
    {
        // Test Variables
        string testVal;
        string expected;
        string result;

        [TestMethod]
        public void testDraw()
        {
            testVal = CONST.DRAW;
            expected = buildTestDrawExpectedOutput(testVal);
            result = runTestDraw();
            Assert.AreEqual<string>(expected, result);
        }

        private string buildTestDrawExpectedOutput(string testVal)
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
                + CONST.PROMPT_PLAYER2 + testVal + "{0}" + CONST.PROMPT_PLAYER2, Environment.NewLine);
            return expectedOutput;
        }

        private string runTestDraw()
        {
            string input = buildTestDrawInput();
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

        private string buildTestDrawInput()
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

            input += string.Format(CONST.EXIT + "{0}", Environment.NewLine);

            return input;
        }
    }
}
