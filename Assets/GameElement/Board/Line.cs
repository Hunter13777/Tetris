using Tetris.Manager;
using UnityEngine;

namespace Tetris.GameElement.Board
{
    /// <summary>
    /// One line of boxes.
    /// Author: AZinman
    /// </summary>
    public class Line : MonoBehaviour
    {
        private int length;
        private Box[] line;

        /// <summary>
        /// Fill the line with empty boxes.
        /// </summary>
        /// <param name="box">Box that shold be used for initialization.</param>
        public void InitEmptyLine(Box box)
        {
            length = GameManager.Instance.BoardSize.x;
            line = new Box[length];

            for (int column = 0; column < length; column++)
            {
                Vector3 size = new Vector3(Constant.BOX_SIZE, Constant.BOX_SIZE);
                Vector3 position = new Vector3(column, Constant.BOARD_LEFT_BORDER) * Constant.BOX_SIZE;
                Box boxGo = Instantiate(box,  this.transform);
                boxGo.transform.localPosition = position;
                boxGo.transform.localScale = size;
                boxGo.SetSortingLayer(SortingLayerType.Board);

                line[column] = boxGo;
            }
        }

        /// <summary>
        /// Check if there is a empty box. 
        /// </summary>
        /// <param name="position">Box number</param>
        /// <returns>true = yes, false = no</returns>
        public bool IsPositionUsable(int position)
        {
            bool usable = false;
            if (position >= Constant.BOARD_LEFT_BORDER && position < length)
            {
                usable = line[position].Empty;
            }
            return usable;
        }

        /// <summary>
        /// Set box sprite and make it no longer empty.
        /// No Validation if the box exists!
        /// </summary>
        /// <param name="position"></param>
        /// <param name="box"></param>
        public void SetBox(int position, Sprite sprite)
        {
            Box boardBox = line[position];
            boardBox.SetSprite(sprite);
            boardBox.Empty = false;
        }

        /// <summary>
        /// Check if there is no empty box in this line.
        /// </summary>
        /// <returns>true = yes, false = no</returns>
        public bool IsLineComplete()
        {
            foreach (Box box in line)
            {
                if (box.Empty)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Move the position of the line a number of rows down.
        /// </summary>
        /// <param name="numberOfRows"></param>
        public void DropDown(int numberOfRows)
        {
            transform.position = transform.position + Vector3.down * numberOfRows * Constant.BOX_SIZE;
        }
    }
}
