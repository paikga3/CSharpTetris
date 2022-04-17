using System;
using System.Collections.Generic;
using System.Text;
using Tetris.Constants;

namespace Tetris.Models
{
    public class BlockModel
    {
        public BlockModel(string type, int rotationIdx)
        {
            this.matrix = BlockContrants.blockDic[type];
            this.rotationIdx = rotationIdx;

            this.x = 4;
            // "I","L","J","T","Z","S","D"
            if (type == "I")
            {
                switch(rotationIdx)
                {
                    case 0:
                        this.y = -1;
                        break;
                    case 1:
                        this.y = -3;
                        break;
                    case 2:
                        this.y = -2;
                        break;
                    case 3:
                        this.y = -3;
                        break;
                }
            } else if (type == "L")
            {
                switch (rotationIdx)
                {
                    case 0:
                        this.y = -2;
                        break;
                    case 1:
                        this.y = -3;
                        break;
                    case 2:
                        this.y = -3;
                        break;
                    case 3:
                        this.y = -3;
                        break;
                }
            } else if (type == "J" || type == "T" || type == "Z" || type == "S")
            {
                switch (rotationIdx)
                {
                    case 0:
                        this.y = -2;
                        break;
                    case 1:
                        this.y = -3;
                        break;
                    case 2:
                        this.y = -3;
                        break;
                    case 3:
                        this.y = -3;
                        break;
                }
            } else if (type == "D")
            {
                this.y = -2;
            }
        }

        public int x
        {
            get; set;
        }

        public int y
        {
            get; set;
        }

        public int rotationIdx
        {
            get; set;
        }

        public int[,,] matrix
        {
            get; set;
        }

        public int[,] rMatrix
        {
            get
            {
                int[,] _rMatrix = new int[4, 4]
                {
                    { 0,0,0,0 },
                    { 0,0,0,0 },
                    { 0,0,0,0 },
                    { 0,0,0,0 },
                };
                if (this.matrix != null)
                {
                    for (int i=0; i<this.matrix.GetLength(0); i++)
                    {
                        if (i != this.rotationIdx)
                        {
                            continue;
                        }

                        for (int x=0; x<this.matrix.GetLength(1); x++)
                        {
                            for (int y=0; y<this.matrix.GetLength(2); y++)
                            {
                                _rMatrix[x, y] = this.matrix[i, x, y];
                            }
                        }
                    }
                }

                return _rMatrix;
            }

            set
            {
                this.rMatrix = value;
            }
        }



    }
}
