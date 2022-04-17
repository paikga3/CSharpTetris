using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Tetris.Constants;
using Tetris.Models;

namespace Tetris.Service
{
    public class BoardService
    {
        public BoardService()
        {
            
        }

        public void Init()
        {
            blockQueue = new Queue<BlockModel>();
            // 초기에 블록 10개를 생성하여 큐에 넣는다.
            for (int i = 0; i < 10; i++)
            {
                BlockModel block = CreateBlock();
                blockQueue.Enqueue(block);
            }

            int bx = BoardContrants.bx;
            int by = BoardContrants.by;

            this.board = new int[bx, by];
            this.oldBoard = new int[bx, by];

            for (int x = 0; x < bx; x++)
            {
                for (int y = 0; y < by; y++)
                {
                    this.board[x, y] = BlockContrants.EMPTY; ; // 빈 공간으로 초기화
                    this.oldBoard[x, y] = BlockContrants.EMPTY; // 빈 공간으로 초기화
                }
            }
        }
        
        // 블록 큐
        public Queue<BlockModel> blockQueue
        {
            get; set;
        }

        // 보드
        public int[,] board
        {
            get; set;
        }

        public int[,] oldBoard
        {
            get; set;
        }

        // 현재 블록
        public BlockModel currBlock
        {
            get; set;
        }

        // 다음 블록
        public BlockModel nextBlock
        {
            get; set;
        }

        // 7가지 블록 타입
        public string[] blockTypes = new string[]
        {
            "I","L","J","T","Z","S","D"
        };

        // 레벨
        public int level
        {
            get; set;
        }
        // 점수
        public int score
        {
            get; set;
        }

        // 라인 제거 수
        public int removeLineCount
        {
            get; set;
        }

        public bool isStop
        {
            get; set;
        }

        // 블록 생성
        public BlockModel CreateBlock()
        {
            // min <= value < max
            Random rnd = new Random();
            string type = blockTypes[rnd.Next(0, 7)];
            int rotationIdx = rnd.Next(0, 4);

            BlockModel block = new BlockModel(type, rotationIdx);
            return block;
        }

        // 소환 가능 여부
        public bool Spawn()
        {
            bool isSpawnable = true;
            if (this.nextBlock == null)
            {
                this.currBlock = this.blockQueue.Dequeue();
                this.blockQueue.Enqueue(CreateBlock());
                this.nextBlock = this.blockQueue.Dequeue();
                this.blockQueue.Enqueue(CreateBlock());
            } else
            {
                this.currBlock = this.nextBlock;
                this.nextBlock = this.blockQueue.Dequeue();
                this.blockQueue.Enqueue(CreateBlock());
            }

            //int[,] rMatrix = this.currBlock.rMatrix;
            //int cx = this.currBlock.x;
            //int cy = this.currBlock.y;

            //for (int x=0; x< rMatrix.GetLength(1); x++)
            //{
            //    for (int y=0; y< rMatrix.GetLength(0); y++)
            //    {
            //        if (y+cy >= 0)
            //        {
            //            if (rMatrix[y, x] == BlockContrants.BLOCK)
            //            {
            //                if (board[x + cx, y + cy] == BlockContrants.BLOCK)
            //                {
            //                    isSpawnable = false;
            //                }
            //            }
            //        }
            //    }
            //    if (!isSpawnable)
            //    {
            //        break;
            //    }
            //}

            // 보드 최상단에 블록이 있으면 블록소환을 하지 않고 게임오버 처리
            for (int x = 0; x < board.GetLength(0); x++)
            {
                if (board[x, 0] == BlockContrants.BLOCK)
                {
                    isSpawnable = false;
                    break;
                }
            }


            return isSpawnable;
        }

        // 블록이 하강 가능한지 여부
        public bool IsDownable()
        {
            int[,] rMatrix = this.currBlock.rMatrix;
            int cx = this.currBlock.x;
            int cy = this.currBlock.y;

            for (int x = 0; x < rMatrix.GetLength(1); x++)
            {
                for (int y = 0; y < rMatrix.GetLength(0); y++)
                {
                    if (cy+y+1 > 0)
                    {
                        if (rMatrix[y, x] == BlockContrants.BLOCK)
                        {
                            if (y + cy + 1 >= BoardContrants.by)
                            {
                                return false;
                            }
                            else if (board[cx + x, cy + y + 1] == BlockContrants.BLOCK)
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }

        // 블록을 보드에 흡수시킨다.
        public void Solidify()
        {
            for (int x=0; x<board.GetLength(0); x++)
            {
                for (int y=0; y<board.GetLength(1); y++)
                {
                    if (board[x, y] == BlockContrants.CURRENT_BLOCK)
                    {
                        board[x, y] = BlockContrants.BLOCK;
                        oldBoard[x, y] = BlockContrants.BLOCK;
                    }
                }
            }
        }

        // 라인마다 검사해서 라인에 블록이 다 차 있으면 제거
        public void RemoveLine()
        {
            for (int y=0; y<board.GetLength(1); y++)
            {
                int blockCount = 0;
                for (int x=0; x<board.GetLength(0); x++)
                {
                    if (board[x,y] == BlockContrants.BLOCK)
                    {
                        blockCount++;
                    }
                }

                if (blockCount == 0 || blockCount == board.GetLength(0)) // 해당라인이 비어있거나? 꽉 찼을 경우
                {
                    if (blockCount == board.GetLength(0)) // 해당라인이 꽉 찼을 경우
                    {
                        for (int x = 0; x < board.GetLength(0); x++) // 해당라인 블락 제거 처리
                        {
                            board[x, y] = BlockContrants.EMPTY;
                        }
                    }
                    for (int i=y-1; i>=0; i--) // 해당라인은 빈상태이므로 해당라인 위의 라인들을 아래로 한라인씩 내린다.
                    {
                        for (int x=0; x<board.GetLength(0); x++)
                        {
                            board[x, i + 1] = board[x, i];
                            board[x, i] = BlockContrants.EMPTY;
                        }
                    }
                }
            }

            for (int x=0; x<board.GetLength(0); x++)
            {
                for (int y=0; y<board.GetLength(1); y++)
                {
                    oldBoard[x, y] = board[x, y];
                }
            }
        }

        // 블록이 턴 가능한지 여부
        public bool IsTurnable()
        {
            bool turnable = true;
            int[,] rMatrix = this.currBlock.rMatrix;
            int cx = this.currBlock.x;
            int cy = this.currBlock.y;

            for (int x = 0; x < rMatrix.GetLength(1); x++)
            {
                for (int y = 0; y < rMatrix.GetLength(0); y++)
                {
                    if (rMatrix[y, x] == BlockContrants.TURNING_RADIUS)
                    {
                        // 블럭의 회전반경 좌표가 x좌표 범위를 벗어나면 턴 불가
                        if (!(x+cx >= 0 && x + cx < BoardContrants.bx))
                        {
                            turnable = false;
                            break;
                        }

                        // 블럭의 회전반경 좌표가 y좌표 범위를 벗어나면 턴 불가
                        if (!(y + cy >= 0 && y + cy < BoardContrants.by))
                        {
                            turnable = false;
                            break;
                        }

                        // 블럭의 회전반경 좌표가 블록이라면 턴 불가
                        if (board[x+cx, y + cy] == BlockContrants.BLOCK)
                        {
                            turnable = false;
                            break;
                        }
                    }
                }

                if (!turnable)
                {
                    break;
                }
            }
            return turnable;
        }

        public void Turn()
        {
            if (!IsTurnable())
            {
                return;
            }

            int rotationIdx = this.currBlock.rotationIdx;
            rotationIdx++;

            if (rotationIdx == 4)
            {
                rotationIdx = 0;
            }

            this.currBlock.rotationIdx = rotationIdx;
        }

        public void Down()
        {
            this.currBlock.y++;
        }

        public void StraightDown()
        {
            while (IsDownable())
            {
                this.currBlock.y++;
            }
        }

        public void LeftMove()
        {
            int[,] rMatrix = this.currBlock.rMatrix;
            int cx = this.currBlock.x;
            int cy = this.currBlock.y;

            bool isMove = true;
            for (int y=0; y<rMatrix.GetLength(1); y++)
            {
                for (int x = 0; x < rMatrix.GetLength(0); x++)
                {
                    if (rMatrix[y, x] == BlockContrants.BLOCK && cy + y >= 0)
                    {
                        if (cx + x - 1 < 0)
                        {
                            isMove = false;
                            break;
                        }

                        if (this.board[cx + x - 1, cy + y] == BlockContrants.BLOCK)
                        {
                            isMove = false;
                            break;
                        }
                    }
                }

                if (!isMove)
                {
                    break;
                }
            }

            if (isMove)
            {
                this.currBlock.x--;
            }
        }

        public void RightMove()
        {
            int[,] rMatrix = this.currBlock.rMatrix;
            int cx = this.currBlock.x;
            int cy = this.currBlock.y;

            bool isMove = true;
            for (int y = 0; y < rMatrix.GetLength(1); y++)
            {
                for (int x = 0; x < rMatrix.GetLength(0); x++)
                {
                    if (rMatrix[y, x] == BlockContrants.BLOCK && cy + y >= 0)
                    {
                        if (cx + x + 1 >= BoardContrants.bx)
                        {
                            isMove = false;
                            break;
                        }

                        if (this.board[cx + x + 1, cy + y] == BlockContrants.BLOCK)
                        {
                            isMove = false;
                            break;
                        }
                    }
                }

                if (!isMove)
                {
                    break;
                }
            }

            if (isMove)
            {
                this.currBlock.x++;
            }
        }
    }
}
