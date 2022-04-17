using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris.Constants
{
    public class BlockContrants
    {

        #region I_BLOCK
        public static readonly int[,,] I_BLOCK = new int[,,]
        {
            {
                { 2,2,2,0 },
                { 1,1,1,1 },
                { 0,0,2,2 },
                { 0,0,2,2 },
            },
            {
                { 0,0,1,2 },
                { 0,0,1,2 },
                { 2,2,1,2 },
                { 2,2,1,0 },
            },
            {
                { 2,2,0,0 },
                { 2,2,0,0 },
                { 1,1,1,1 },
                { 0,2,2,2 },
            },
            {
                { 0,1,2,2 },
                { 2,1,2,2 },
                { 2,1,0,0 },
                { 2,1,0,0 },
            }
        };
        #endregion

        #region L_BLOCK
        public static readonly int[,,] L_BLOCK = new int[,,]
        {
            {
                { 0,0,0,0 },
                { 1,2,2,0 },
                { 1,1,1,0 },
                { 0,2,2,0 },
            },
            {
                { 0,0,0,0 },
                { 2,1,1,0 },
                { 2,1,2,0 },
                { 2,1,0,0 },
            },
            {
                { 0,0,0,0 },
                { 2,2,0,0 },
                { 1,1,1,0 },
                { 2,2,1,0 },
            },
            {
                { 0,0,0,0 },
                { 2,1,2,0 },
                { 2,1,2,0 },
                { 1,1,0,0 },
            },
        };
        #endregion

        #region J_BLOCK
        public static readonly int[,,] J_BLOCK = new int[,,]
        {
            {
                { 0,0,0,0 },
                { 2,2,1,0 },
                { 1,1,1,0 },
                { 0,2,2,0 },
            },
            {
                { 0,0,0,0 },
                { 0,1,2,0 },
                { 2,1,2,0 },
                { 2,1,1,0 },
            },
            {
                { 0,0,0,0 },
                { 2,2,0,0 },
                { 1,1,1,0 },
                { 1,2,2,0 },
            },
            {
                { 0,0,0,0 },
                { 1,1,2,0 },
                { 2,1,2,0 },
                { 2,1,0,0 },
            },
        };
        #endregion

        #region T_BLOCK
        public static readonly int[,,] T_BLOCK = new int[,,]
        {
            {
                { 0,0,0,0 },
                { 2,1,2,0 },
                { 1,1,1,0 },
                { 0,2,2,0 },
            },
            {
                { 0,0,0,0 },
                { 0,1,2,0 },
                { 2,1,1,0 },
                { 2,1,2,0 },
            },
            {
                { 0,0,0,0 },
                { 2,2,0,0 },
                { 1,1,1,0 },
                { 2,1,2,0 },
            },
            {
                { 0,0,0,0 },
                { 2,1,2,0 },
                { 1,1,2,0 },
                { 2,1,0,0 },
            },
        };
        #endregion

        #region Z_BLOCK
        public static readonly int[,,] Z_BLOCK = new int[,,]
        {
            {
                { 0,0,0,0 },
                { 2,1,1,0 },
                { 1,1,2,0 },
                { 0,0,2,0 },
            },
            {
                { 0,0,0,0 },
                { 0,1,2,0 },
                { 0,1,1,0 },
                { 2,2,1,0 },
            },
            {
                { 0,0,0,0 },
                { 2,0,0,0 },
                { 2,1,1,0 },
                { 1,1,2,0 },
            },
            {
                { 0,0,0,0 },
                { 1,2,2,0 },
                { 1,1,0,0 },
                { 2,1,0,0 },
            },
        };
        #endregion

        #region S_BLOCK
        public static readonly int[,,] S_BLOCK = new int[,,]
        {
            {
                { 0,0,0,0 },
                { 1,1,2,0 },
                { 0,1,1,0 },
                { 0,2,2,0 },
            },
            {
                { 0,0,0,0 },
                { 0,0,1,0 },
                { 2,1,1,0 },
                { 2,1,2,0 },
            },
            {
                { 0,0,0,0 },
                { 2,2,0,0 },
                { 1,1,0,0 },
                { 2,1,1,0 },
            },
            {
                { 0,0,0,0 },
                { 2,1,2,0 },
                { 1,1,2,0 },
                { 1,0,0,0 },
            },
        };
        #endregion

        #region D_BLOCK
        public static readonly int[,,] D_BLOCK = new int[,,]
        {
            {
                { 0,0,0,0 },
                { 0,1,1,0 },
                { 0,1,1,0 },
                { 0,0,0,0 },
            },
            {
                { 0,0,0,0 },
                { 0,1,1,0 },
                { 0,1,1,0 },
                { 0,0,0,0 },
            },
            {
                { 0,0,0,0 },
                { 0,1,1,0 },
                { 0,1,1,0 },
                { 0,0,0,0 },
            },
            {
                { 0,0,0,0 },
                { 0,1,1,0 },
                { 0,1,1,0 },
                { 0,0,0,0 },
            },
        };
        #endregion



        public static readonly Dictionary<string, int[,,]> blockDic = new Dictionary<string, int[,,]>
        {
            { "I", I_BLOCK },
            { "L", L_BLOCK },
            { "J", J_BLOCK },
            { "T", T_BLOCK },
            { "Z", Z_BLOCK },
            { "S", S_BLOCK },
            { "D", D_BLOCK },
        };


        public static readonly int EMPTY = 0;
        public static readonly int BLOCK = 1;
        public static readonly int TURNING_RADIUS = 2;
        public static readonly int CURRENT_BLOCK = 3;
        public static readonly int REMOVE_BLOCK = 4;
    }
}
