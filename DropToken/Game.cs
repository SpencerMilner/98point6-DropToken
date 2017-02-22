using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DropToken
{
    public class Game
    {
        GameBoard board;
        const int size = 4;
        const int players = 2;
 
        public Game()
        {
            Console.WriteLine("You're Playing 98point6 Drop Token");
            Console.WriteLine("----------------------------------");
            board = new GameBoard(size);
            play();
        }

        public void play()
        {
            CHIP chip = CHIP.one;
            COMMAND command;
            int column = 0;
            bool gameOver = false; // Prevent drop command from executing once game is over

            // Game Play
            while (true)
            {
                Console.Write("Player " + chip.ToString() + ", enter a command: ");

                command = CommandInterpreter.parse(Console.ReadLine(), ref column);
                if (!CommandExecutor.execute(board, command, chip, column,gameOver)) {
                    continue;
                }
                else if (board.getStatus() == STATUS.WIN)
                {
                    gameOver = true;
                    Console.WriteLine("WIN");
                    continue;
                }
                else if (board.getStatus() == STATUS.DRAW)
                {
                    gameOver = true;
                    Console.WriteLine("DRAW");
                    continue;
                }
                else if (board.getStatus() == STATUS.EXIT) { 
                    break;
                }
                else { // next player's turn
                    Console.WriteLine("OK");
                    if (chip == CHIP.one) chip = CHIP.two;
                    else chip = CHIP.one;
                } 
            }

            Console.ReadLine(); // Keep console open
        } 
    }
}
