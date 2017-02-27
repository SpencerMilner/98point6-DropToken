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
        // Test Variables
        string testVal;
        string expected;
        string result;

        [TestMethod]
        public void testGet()
        {
            testVal = CONST.GET;
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
                input += string.Format(CONST.PUT_COLUMN_ONE + "{0}" 
                    + CONST.PUT_COLUMN_TWO + "{0}"
                    + CONST.PUT_COLUMN_THREE + "{0}"
                    + CONST.INVALID_COMMAND + "{0}"
                    + CONST.PUT_COLUMN_FOUR + "{0}", Environment.NewLine);
            }
            input += string.Format(testVal + "{0}" + CONST.EXIT + "{0}", Environment.NewLine);
            return input;
        }

        private string buildTestGetExpectedOutput()
        {
            string expectedOutput = string.Format(
                        CONST.WELCOME_MESSAGE + "{0}" +
                        CONST.LINEBREAK + "{0}", Environment.NewLine);

            for (short i = 0; i < 3; i++)
            {
                expectedOutput += string.Format(
                    CONST.PROMPT_PLAYER1 + CONST.OK + "{0}" + CONST.PROMPT_PLAYER2 + CONST.OK + "{0}"
                    + CONST.PROMPT_PLAYER1 + CONST.OK + "{0}" + CONST.PROMPT_PLAYER2 + CONST.ERROR + "{0}"
                    + CONST.PROMPT_PLAYER2 + CONST.OK + "{0}", Environment.NewLine);
            }
            expectedOutput += CONST.PROMPT_PLAYER1;
            for(short i = 0; i < 3; i++)
            {
                expectedOutput += string.Format(
                    "1{0}2{0}3{0}4{0}", Environment.NewLine);
            }

            expectedOutput += CONST.PROMPT_PLAYER1;

            return expectedOutput;
        }
    }
}

