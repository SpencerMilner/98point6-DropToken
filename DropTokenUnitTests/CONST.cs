using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DropTokenUnitTests
{
    static class CONST // Constants for use during tests
    {
        // Expected Output

        public const string WELCOME_MESSAGE = "You're Playing 98point6 Drop Token";
        public const string LINEBREAK = "----------------------------------";
        public const string PROMPT_PLAYER1 = "Player one, enter a command: ";
        public const string PROMPT_PLAYER2 = "Player two, enter a command: ";
        public const string ERROR = "ERROR";
        public const string EXIT = "EXIT";
        public const string OK = "OK";
        public const string WIN = "WIN";
        public const string DRAW = "DRAW";
        public const string BOARD = "BOARD";
        

        // Test Input

        public const string INVALID_COMMAND = "-AbQ&# ";
        public const string INVALID_COMMAND_LARGEVALUE = "99999999999999999999";
        public const string INVALID_COMMAND_EMPTY = "";

        public const string PUT_COLUMN_ONE = "PUT 1";
        public const string PUT_COLUMN_TWO = "PUT 2";
        public const string PUT_COLUMN_THREE = "PUT 3";
        public const string PUT_COLUMN_FOUR = "PUT 4";

        public const int ARRAY_MAX = 3; // 0-3 for 4x4 board

        public const string GET = "GeT";
        public const string GET_SPACES = " GET ";
        public const string GET_WITH_EXTRA_PARAMETER = "GET 2";

        public const string INVALID_SECOND_PARAM = "GET GET";
        public const string INVALID_COMMAND_EXTRALETTER = "GETT";
        public const string INVALID_COMMAND_SPACES = " GET ";

        public const string PUT_COLUMN_EDGECASE_LOW = "PUT 0";
        public const string PUT_COLUMN_EDGECASE_HIGH = "PUT 5";
        public const string PUT_COLUMN_NEGATIVE = "PUT -1";
        public const string PUT_COLUMN_INVALID = "PUT GET";
        public const string PUT_COLUMN_EMPTY = "PUT ";
        public const string PUT_COLUMN_EXTRA_PARAMETER = "PUT 1 1";
        public const string PUT_COLUMN_DECIMAL = "PUT 1.8";
    }
}
