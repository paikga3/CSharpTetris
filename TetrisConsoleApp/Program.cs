using System;
using Tetris.Models;
using Tetris.Service;
using Tetris.Constants;

namespace TetrisConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BoardService boardService = new BoardService();
            int[,] board = new int[,]
            {
                { 0,0,0,0,0,3,0,0,0,0,0,0 },
                { 0,0,0,0,3,3,3,1,0,0,0,0 },
                { 0,0,0,0,0,0,0,1,0,0,0,0 },
                { 0,0,1,1,0,0,0,1,1,1,1,1 },
                { 0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,1,1,0,0,0,1,1,1,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,1,1,0,0,0,1,1,1,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,1,1,0,0,0,1,1,1,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,1,1,0,0,0,1,1,1,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0 },
                { 1,1,1,1,1,1,1,1,1,1,1,1 },
                { 0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,1,1,0,0,0,1,1,1,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0 },
                { 1,1,1,1,1,1,1,1,1,1,1,1 },
                { 0,0,1,1,0,0,0,1,1,1,0,0 },
                { 1,1,1,1,0,0,0,1,1,1,1,0 },
            };
            boardService.board = board;
            print(board);
            Console.WriteLine("=======================================");

            boardService.RemoveLine();
            print(board);
            

            //boardService.board = board;
            //boardService.currBlock = new BlockModel("T", 0);
            //boardService.currBlock.y = -1;

            //currBlockPrint(boardService.currBlock);
            //Console.WriteLine(boardService.isDownable());
            
            //Console.WriteLine(boardService.isSpawnable());
        }

        static void currBlockPrint(BlockModel bm)
        {
            int[,] matrix = bm.rMatrix;

            for (int y = 0; y < matrix.GetLength(0); y++)
            {
                for (int x = 0; x < matrix.GetLength(1); x++)
                {
                    Console.Write(matrix[y, x] + " ");
                }
                Console.WriteLine();
            }


        }


        static void print(int[,] board)
        {
            for (int y=0; y<board.GetLength(0); y++)
            {
                for (int x=0; x<board.GetLength(1); x++)
                {
                    Console.Write(board[y, x] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
