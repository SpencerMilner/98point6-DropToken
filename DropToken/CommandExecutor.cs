using System;

namespace DropToken
{
    static class CommandExecutor
    {
        public static bool execute(GameBoard gameBoard, COMMAND command, CHIP chip, int col, bool gameOver)
        {
                switch (command)
                {
                    case COMMAND.GET:
                        get(gameBoard);
                        return false;
                    case COMMAND.BOARD:
                        board(gameBoard);
                        return false;
                    case COMMAND.PUT:
                    if (gameOver) goto default;
                        return put(gameBoard, chip, col);
                    case COMMAND.EXIT:
                        exit(gameBoard);
                        return true;
                    default:
                        invalid();
                        return false;
                }
        }

        private static void get(GameBoard board)
        {
            board.printList();
        }

        private static void board(GameBoard board)
        {
            board.printBoard();
        }

        private static bool put(GameBoard board,CHIP chip, int col)
        {
            return board.dropChip(chip, col);
        }

        private static void invalid()
        {
            Console.WriteLine("ERROR");
        }

        private static void exit(GameBoard board)
        {
            board.exit();
        }
    }
}
