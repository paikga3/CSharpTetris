using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tetris.Constants;
using Tetris.Models;
using Tetris.Service;

namespace Tetris
{
    public partial class TetrisForm : Form
    {
        SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);

        private int bwidth = BoardContrants.bwidth;
        private int bheight = BoardContrants.bheight;
        private int bpadding = BoardContrants.bpadding;
        private BoardService bService = new BoardService();
        private bool isStop = false;

        public TetrisForm()
        {
            InitializeComponent();

            // 초기블럭 10개를 생성하여 큐에 넣는다. 그리고 보드의 모든 블록을 빈 블록으로 초기화 한다.
            bService.Init();
        }

        private void TetrisForm_Load(object sender, EventArgs e)
        {
            

        }

        private void TetrisForm_Paint(object sender, PaintEventArgs e)
        {
            
        }

        public void DrawNextBlock()
        {
            Graphics g = nextBlockPanel.CreateGraphics();
            int[,] rMatrix = bService.nextBlock?.rMatrix;
            if (rMatrix == null)
            {
                return;
            }


            for (int x = 0; x < rMatrix.GetLength(1); x++)
            {
                for (int y = 0; y < rMatrix.GetLength(0); y++)
                {
                    Rectangle rect = new Rectangle();
                    // 블록을 그릴 좌표에서 패딩만큼 좌표이동한다.
                    rect.X = x * bwidth + bpadding;
                    rect.Y = y * bheight + bpadding;

                    // 이동한 좌표에서 패딩의 2배를 너비와 높이로 한다. 그러면 패딩이 적용된다.
                    rect.Width = bwidth - (bpadding * 2);
                    rect.Height = bheight - (bpadding * 2);
                    g.DrawRectangle(Pens.MediumPurple, rect);
                    if (rMatrix[y, x] == BlockContrants.BLOCK)
                    {
                        g.FillRectangle(Brushes.Gray, rect.X, rect.Y, rect.Width, rect.Height);
                    } else
                    {
                        g.FillRectangle(Brushes.White, rect.X, rect.Y, rect.Width, rect.Height);
                    }
                }
            }

        }

        public void DrawBoard()
        {
            Graphics g = boardPanel.CreateGraphics();
            int[,] board = bService.board;
            int[,] oldBoard = bService.oldBoard;


            int[,] rMatrix = bService.currBlock.rMatrix;
            int cx = bService.currBlock.x;
            int cy = bService.currBlock.y;

            for (int x=0; x<oldBoard.GetLength(0); x++)
            {
                for (int y=0; y<oldBoard.GetLength(1); y++)
                {
                    if (oldBoard[x,y] == BlockContrants.CURRENT_BLOCK)
                    {
                        board[x, y] = BlockContrants.REMOVE_BLOCK;
                        oldBoard[x, y] = BlockContrants.EMPTY;
                    }
                }
            }
            


            for (int x = 0; x < rMatrix.GetLength(1); x++)
            {
                for (int y = 0; y < rMatrix.GetLength(0); y++)
                {
                    if (x + cx >= 0 && x + cx < BoardContrants.bx && y + cy >= 0 && y + cy < BoardContrants.by)
                    {
                        if (rMatrix[y, x] == BlockContrants.BLOCK)
                        {
                            if (board[x + cx, y + cy] != BlockContrants.BLOCK)
                            {
                                board[x + cx, y + cy] = BlockContrants.CURRENT_BLOCK;
                                oldBoard[x + cx, y + cy] = BlockContrants.CURRENT_BLOCK;
                            }
                            
                        }
                    }
                }
            }

            for (int x = 0; x < board.GetLength(0); x++)
            {
                for (int y = 0; y < board.GetLength(1); y++)
                {
                    Rectangle rect = new Rectangle();
                    // 블록을 그릴 좌표에서 패딩만큼 좌표이동한다.
                    rect.X = x * bwidth + bpadding;
                    rect.Y = y * bheight + bpadding;

                    // 이동한 좌표에서 패딩의 2배를 너비와 높이로 한다. 그러면 패딩이 적용된다.
                    rect.Width = bwidth - (bpadding * 2);
                    rect.Height = bheight - (bpadding * 2);

                    int BlockStatus = board[x, y];
                    g.DrawRectangle(Pens.MediumPurple, rect);
                    if (BlockStatus == BlockContrants.EMPTY || BlockStatus == BlockContrants.REMOVE_BLOCK)
                    {
                        // 패딩이 적용된 사각형을 그린다.
                        g.FillRectangle(Brushes.White, rect.X, rect.Y, rect.Width, rect.Height);
                    } else if (BlockStatus == BlockContrants.BLOCK)
                    {
                        g.FillRectangle(Brushes.Gray, rect.X, rect.Y, rect.Width, rect.Height);
                    } else if (BlockStatus == BlockContrants.CURRENT_BLOCK)
                    {
                        g.FillRectangle(Brushes.Purple, rect.X, rect.Y, rect.Width, rect.Height);
                    }
                }
            }
        }


        private void exitGameBtn_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private async void TetrisForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }

            if (e.KeyCode == Keys.Left)
            {
                await semaphoreSlim.WaitAsync();
                bService.LeftMove();
                DrawBoard();
                semaphoreSlim.Release();
            } else if (e.KeyCode == Keys.Right)
            {
                await semaphoreSlim.WaitAsync();
                bService.RightMove();
                DrawBoard();
                semaphoreSlim.Release();
            } else if (e.KeyCode == Keys.Up)
            {
                await semaphoreSlim.WaitAsync();
                bService.Turn();
                DrawBoard();
                semaphoreSlim.Release();
            } else if (e.KeyCode == Keys.Down)
            {
                if (bService.IsDownable())
                {
                    await semaphoreSlim.WaitAsync();
                    bService.Down();
                    DrawBoard();
                    semaphoreSlim.Release();
                }
            } else if (e.KeyCode == Keys.Space)
            {
                await semaphoreSlim.WaitAsync();
                bService.StraightDown();
                DrawBoard();
                semaphoreSlim.Release();
            }
        }

        private async void boardPanel_Paint(object sender, PaintEventArgs e)
        {
            while (bService.Spawn())
            {
                await semaphoreSlim.WaitAsync();
                nextBlockPanel.Refresh(); // nextBlockPanel_Paint 호출
                DrawBoard();
                semaphoreSlim.Release();
                while (bService.IsDownable())
                {
                    await semaphoreSlim.WaitAsync();
                    bService.Down();
                    DrawBoard();
                    semaphoreSlim.Release();
                    await Task.Delay(400);
                }
                await semaphoreSlim.WaitAsync();
                bService.Solidify();
                DrawBoard();
                semaphoreSlim.Release();

                await semaphoreSlim.WaitAsync();
                bService.RemoveLine();
                DrawBoard();
                semaphoreSlim.Release();
            }

            MessageBox.Show("Game Over.");
        }

        private async void nextBlockPanel_Paint(object sender, PaintEventArgs e)
        {
            await semaphoreSlim.WaitAsync();
            DrawNextBlock();
            semaphoreSlim.Release();
        }
    }
}
