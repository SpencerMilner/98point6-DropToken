using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DropToken
{
    enum COMMAND { PUT,GET,BOARD,INVALID,EXIT};

    static class CommandInterpreter
    {
        private const int COMMAND_PARAM = 0; // parameter that contains the command
        private const int COL_PARAM = 1;    // parameter that contains the column

        private const int PUT_PARAM_COUNT = 2; // Expected parameters for "PUT" command
        private const int GBE_COMMAND_PARAM_COUNT = 1; // Expected parameters for other commands

        private const int MIN_COLUMNS = 1; 
        private const int MAX_COLUMNS = 4;

        public static COMMAND parse(String input, ref int column)
        {
            string[] commands;
            if (input == null) return COMMAND.INVALID;
            else commands = input.Split(); // split command parameters
            if (!parametersAreValid(ref commands)) return COMMAND.INVALID;

            if (commands[COMMAND_PARAM].Equals("GET")) return COMMAND.GET;
            else if (commands[COMMAND_PARAM].Equals("BOARD")) return COMMAND.BOARD;
            else if (commands[COMMAND_PARAM].Equals("EXIT")) return COMMAND.EXIT;
            else
            {
                column = Int32.Parse(commands[COL_PARAM]);
                return COMMAND.PUT;
            }
        }

        private static bool parametersAreValid(ref string[] parameters)
        {
            if (!checkNumberOfParameters(parameters)) return false;

            parameters[COMMAND_PARAM] = parameters[COMMAND_PARAM].ToUpper();

            if (checkPutCommand(parameters)) return true;
            else if (checkOtherCommands(parameters)) return true;
            else return false;
        }

        private static bool checkNumberOfParameters(string[] parameters)
        {
            if (parameters == null || parameters.Length > PUT_PARAM_COUNT 
                || parameters.Length < GBE_COMMAND_PARAM_COUNT) return false;
            else return true;
        }

        private static bool checkPutCommand(string[] parameters)
        {
            if (parameters.Length != PUT_PARAM_COUNT) return false;
            if (parameters[COMMAND_PARAM].Equals("PUT"))
            {
                int i = 0;

                if (!Int32.TryParse(parameters[COL_PARAM], out i)) return false;
                else if (i < MIN_COLUMNS || i > MAX_COLUMNS) return false;  // valid column selection
                else return true;
            }
            else return false;
        }

        private static bool checkOtherCommands(string[] parameters)
        {
            if (parameters.Length != GBE_COMMAND_PARAM_COUNT) return false;
            else if (parameters[COMMAND_PARAM].Equals("GET") || parameters[COMMAND_PARAM].Equals("BOARD")
                || parameters[COMMAND_PARAM].Equals("EXIT")) return true;
            else return false;
        }
    }
}
