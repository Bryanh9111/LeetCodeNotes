using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._3_暴_搜索算法._3._1_DFS._1_回溯算法解题套路框架
{
    class Leetcode_51
    {
        IList<IList<string>> res = new List<IList<string>>();
        public IList<IList<string>> SolveNQueens(int n)
        {
            // '.' 表示空，'Q' 表示皇后，初始化空棋盘。
            IList<IList<char>> board = new List<IList<char>>();
            for(int i = 0; i < n; i++)
            {
                IList<char> lst = new List<char>();
                for(int j = 0; j < n; j++)
                {
                    lst.Add('.');
                }
                board.Add(lst);
            }
            Helper(board, 0);
            return res;
        }

        // 路径：board 中⼩于 row 的那些⾏都已经成功放置了皇后
        // 选择列表：第 row ⾏的所有列都是放置皇后的选择
        // 结束条件：row 超过 board 的最后⼀⾏
        public void Helper(IList<IList<char>> board, int row)
        {
            // 触发结束条件
            if (row == board.Count)
            {
                IList<string> boardStr = new List<string>();
                foreach(var lst in board)
                {
                    boardStr.Add(string.Join("", lst));
                }
                res.Add(new List<string>(boardStr));
                return;
            }

            for(int col = 0; col < board[0].Count; col++)
            {
                // 排除不合法选择
                if (!IsValid(board, row, col))
                    continue;
                // 做选择
                board[row][col] = 'Q';
                // 进⼊下⼀⾏决策
                Helper(board, row + 1);
                // 撤销选择
                board[row][col] = '.';
            }
        }

        public bool IsValid(IList<IList<char>> board, int row, int col)
        {
            // 检查列是否有皇后互相冲突
            for (int i = 0; i < board.Count; i++)
            {
                if (board[i][col] == 'Q')
                    return false;
            }
            // 检查左上⽅是否有皇后互相冲突
            for (int i = row - 1, j = col - 1; i >= 0 && j >= 0; i--, j--)
            {
                if (board[i][j] == 'Q')
                    return false;
            }
            // 检查右上⽅是否有皇后互相冲突
            for (int i = row - 1, j = col + 1; i >= 0 && j < board.Count; i--, j++)
            {
                if (board[i][j] == 'Q')
                    return false;
            }
            return true;
        }
    }
}
