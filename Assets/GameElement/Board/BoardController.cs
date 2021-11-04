using System.Collections.Generic;
using Tetris.Manager;
using Tetris.UserInterface.Menu;
using UnityEngine;

namespace Tetris.GameElement.Board
{
    /// <summary>
    /// Management of the game board.
    /// Author: AZinman
    /// </summary>
    public class BoardController : MonoBehaviour
    {
        private const int MIN_BOARD_SIZE_X = 5;
        private const int MIN_BOARD_SIZE_Y = 5;

        [SerializeField] private Box boardBox = null;
        [SerializeField] private Line line = null;
        [SerializeField] private PauseMenu pauseMenu = null;
        [SerializeField] private Information information = null;

        private Vector2Int boardSize;
        private Line[] rows;
        private int boardTop;

        private void Start()
        {
            boardSize = GameManager.Instance.BoardSize;
            boardTop = boardSize.y - Constant.BOARD_GROUND;

            if (boardSize.x < MIN_BOARD_SIZE_X || boardSize.y < MIN_BOARD_SIZE_Y)
            {
                Debug.LogError("Start(): Board too small.");
            }
            if (boardBox == null)
            {
                Debug.LogError("Start(): Missing Box.");
            }

            InitBoard();
        }

        /// <summary>
        /// Initialize a board with empty rows.
        /// </summary>
        private void InitBoard()
        {
            rows = new Line[boardSize.y];

            for (int row = Constant.BOARD_GROUND; row < boardTop; row++)
            {
                InitNewLine(row);
            }
        }

        /// <summary>
        /// Initialize a line with empty boxes.
        /// </summary>
        /// <param name="row">Position on the board.</param>
        private void InitNewLine(int row)
        {
            Vector3 position = new Vector3(Constant.BOARD_LEFT_BORDER, row) * Constant.BOX_SIZE;

            Line lineGo = Instantiate(line, position, Quaternion.identity, this.transform);
            lineGo.InitEmptyLine(boardBox);

            rows[row] = lineGo;
        }

        /// <summary>
        /// Check that all posionscan be used.
        /// </summary>
        /// <param name="checkPositionList">Possitions to check.</param>
        /// <returns>true = yes, false = no</returns>
        public bool IsMovePossible(List<Vector2Int> checkPositionList)
        {
            foreach (Vector2Int checkPosition in checkPositionList)
            {
                if (!IsPossitionInBound(checkPosition) || !IsPositionCanBePassed(checkPosition))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Check that the position lies between left and right border.
        /// </summary>
        /// <param name="position">Possition to check.</param>
        /// <returns>true = yes, false = no</returns>
        private bool IsPossitionInBound(Vector2Int position)
        {
            return position.x >= Constant.BOARD_LEFT_BORDER
                && position.x < boardSize.x - Constant.BOARD_LEFT_BORDER;
        }

        /// <summary>
        /// Check that the position is empty or above the board.
        /// </summary>
        /// <param name="position">Possition to check.</param>
        /// <returns>true = yes, false = no</returns>
        private bool IsPositionCanBePassed(Vector2Int position)
        {
            bool usable = false;
            if (position.y >= Constant.BOARD_GROUND)
            {
                if (position.y < boardTop)
                {
                    usable = rows[position.y].IsPositionUsable(position.x);
                }
                else
                {
                    // Positions above the board can be passed.
                    usable = true;
                }
            }
            return usable;
        }

        /// <summary>
        /// Activities after a stone has reached its final position.
        /// GameOver check, full rows removement, score calculation.
        /// </summary>
        /// <param name="boxes"></param>
        public void Touchdown(Box[] boxes)
        {
            HashSet<int> rowNumbersToDestroy = GetFullRowsWithGameOverCheck(boxes);

            if (rowNumbersToDestroy.Count > 0)
            {
                DestroyRows(rowNumbersToDestroy);

                Collapse();

                information.AddPoints(rowNumbersToDestroy.Count);
            }
        }

        /// <summary>
        /// Remove full rows, 
        /// </summary>
        private void Collapse()
        {
            int rowsToCollapse = 0;
            for (int row = Constant.BOARD_GROUND; row < boardTop; row++)
            {
                if (rows[row] == null)
                {
                    rowsToCollapse++;
                }
                else
                {
                    if (rowsToCollapse > 0)
                    {
                        rows[row].DropDown(rowsToCollapse);
                        rows[row - rowsToCollapse] = rows[row];
                        rows[row] = null;
                    }
                }
            }

            FillWithEmptyLines(rowsToCollapse);
        }

        private void FillWithEmptyLines(int number)
        {
            for (int row = boardTop - number; row < boardSize.y - Constant.BOARD_GROUND; row++)
            {
                InitNewLine(row);
            }
        }

        /// <summary>
        /// Remove rows.
        /// </summary>
        /// <param name="rowNumberSet">Row numbers</param>
        private void DestroyRows(HashSet<int> rowNumberSet)
        {
            foreach (int rowNumber in rowNumberSet)
            {
                Destroy(rows[rowNumber].gameObject);
                rows[rowNumber] = null;
            }
        }

        /// <summary>
        /// Check for complete lines, including Game Over Check.
        /// </summary>
        /// <param name="boxes"></param>
        /// <returns>A set of row numbers to remove</returns>
        private HashSet<int> GetFullRowsWithGameOverCheck(Box[] boxes)
        {
            HashSet<int> rowNumbersToDestroy = new HashSet<int>();

            foreach (Box box in boxes)
            {
                Vector2Int position = box.GetIntPosition();
                if (position.y >= boardTop)
                {
                    // Part of the stone is not on the board.
                    pauseMenu.GameOver();
                }
                else
                {
                    rows[position.y].SetBox(position.x, box.GetSprite());
                    if (rows[position.y].IsLineComplete())
                    {
                        rowNumbersToDestroy.Add(position.y);
                    }
                }
            }

            return rowNumbersToDestroy;
        }
    }
}
