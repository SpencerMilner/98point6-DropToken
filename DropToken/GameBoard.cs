using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DropToken
{
    enum CHIP { empty, one, two }; // Represents unoccupied board locations and the chips for Players 1 and 2
    enum STATUS {OK,ERROR,WIN,DRAW,EXIT}; // The status of the game/board in relation to the last command

    class GameBoard
    {
        private const int FULL_COLUMN = 3;
        private const int EMPTY_COLUMN = 0;

        int boardSize;
        CHIP[,] board;
        int[] columnTracker;
        List<int> columnList;
        private STATUS status;

        public GameBoard(int inBoardSize)
        {
            status = STATUS.OK;
            columnList = new List<int>();
            boardSize = inBoardSize;
            board = new CHIP[boardSize, boardSize];
            columnTracker = new int[boardSize]; // tracks number of chips in each column

            for (short i = 0; i < boardSize; i++) { // Initialize board and column tracker
                columnTracker[i] = EMPTY_COLUMN;
                for (short j = 0; j < boardSize; j++)
                {
                    board[i, j] = CHIP.empty;
                }
            }
        }
        // Player adds a chip to the board
        public bool dropChip(CHIP drop, int colNumber)
        {
            if (columnTracker[--colNumber] >= boardSize)
            {
                Console.WriteLine("ERROR");
                status = STATUS.ERROR;
                return false;
            }
            else
            {
                board[columnTracker[colNumber], colNumber] = drop;
                updateStatus(drop, colNumber);
                columnList.Add(++colNumber); 

                return true;
            }
        }
        // Update status of the board (WIN DRAW OK)
        public void updateStatus(CHIP chip, int col)
        {
            int row = columnTracker[col]; 
            ++columnTracker[col];

            if (checkWin(chip, row, col)) status = STATUS.WIN;
            else if (checkDraw()) status = STATUS.DRAW;
            else status = STATUS.OK;
        }

        // Evaluate Draw Condition
        private bool checkDraw()
        {
            for(short i = 0; i < boardSize; i++)
            {
                if (columnTracker[i] != boardSize) return false;
            }
            
            return true;
        }

        // Evaluate Win Conditions
        private bool checkWin(CHIP curChip, int row, int col)
        {
            if (checkVertical(curChip, col) || checkHorizontal(curChip, row) 
                || CheckDiagonals(curChip, row, col)) return true;
            else return false;
        }
        private bool checkVertical(CHIP curChip, int colNumber)
        {
            for(short i = 0; i < boardSize; i++)
            {
                if (board[i, colNumber] != curChip) return false;
            }
            return true;
        }
        private bool checkHorizontal(CHIP curChip, int rowNumber)
        {
            for(short i = 0; i < boardSize; i++)
            {
                if (board[rowNumber, i] != curChip) return false;
            }
            return true;
        }
        private bool CheckDiagonals(CHIP curChip, int row, int col)
        {
            if (checkDiagonalBottomTop(curChip,row,col) || checkDiagonalTopBottom(curChip,row,col)) return true;
            else return false;
        }
        private bool checkDiagonalBottomTop(CHIP curChip,int row, int col)
        {
            if ((row + col) % 2 != 0) return false; // row and col should be even for bottom-top diagonal

            for (short i = 0; i < boardSize; i++)
            {
                if (board[i, i] != curChip) return false;
            }
            return true;
        }
        private bool checkDiagonalTopBottom(CHIP curChip,int row, int col)
        {
            if ((row + col) % 2 != 1) return false; // row and col should be odd for bottom-top diagonal

            int j = boardSize - 1;
            for (short i = 0; i < boardSize; i++)
            {
                if (board[i, j] != curChip) return false;
                --j;
            }
            return true;
        }

        public void printBoard()
        {
            for(int i = boardSize - 1; i >= 0; i--) 
            {
                Console.Write("\n|");
                for (short j = 0; j < boardSize; j++)
                {
                    Console.Write(" ");
                    switch (board[i, j])
                    {
                        case CHIP.empty:
                            Console.Write(Convert.ToInt32(CHIP.empty));
                            break;
                        case CHIP.one:
                            Console.Write(Convert.ToInt32(CHIP.one));
                            break;
                        case CHIP.two:
                            Console.Write(Convert.ToInt32(CHIP.two));
                            break;
                    }
                }
                Console.WriteLine("");
            }
            Console.WriteLine("\n+--------\n\n  1 2 3 4\n");
        }

        public void printList() // Print the list of plays
        {
            foreach (int a in columnList) Console.WriteLine(a);
        }

        public STATUS getStatus() { return status; }
        public void exit() { status = STATUS.EXIT; }
    }
}
