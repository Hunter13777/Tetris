using System.Collections.Generic;
using UnityEngine;

namespace Tetris.GameElement.Stone
{
    /// <summary>
    /// Managemen of the activ stone on the board.
    /// Author: AZinman
    /// </summary>
    public class StoneController : MonoBehaviour
    {
        [Tooltip("List of the stones used in the game.")]
        [SerializeField] private Stone[] stoneList;

        private Stone activeStone = null;

        /// <summary>
        /// Instantiate a random stone on location.
        /// </summary>
        /// <param name="location">Coordinates</param>
        public void CreateRandomStone(Vector2 location)
        {
            int randomStoneNumber = Random.Range(0, stoneList.Length);
            Stone randomStone = stoneList[randomStoneNumber];

            if (randomStone != null)
            {
                activeStone = Instantiate(randomStone, location, Quaternion.identity);
            }
            else
            {
                Debug.LogError("CreateRandomStone(): Stone is missing.");
            }
        }

        /// <summary>
        /// Is active stone not null.
        /// </summary>
        /// <returns>true = not null, false = null</returns>
        public bool IsActivStoneSet()
        {
            return activeStone != null;
        }

        /// <summary>
        /// Get alls boxes of the activ stone.
        /// No Validation if the stone exists.
        /// </summary>
        /// <returns></returns>
        public Box[] GetActivStoneBoxes()
        {
            return activeStone.ChildrenBoxes;
        }

        /// <summary>
        /// Get all box positions after the move.
        /// </summary>
        /// <param name="direction">Movement direction.</param>
        /// <returns>List of coordinates.</returns>
        public List<Vector2Int> GetMovePositions(Direction direction)
        {
            List<Vector2Int> vectorList = new List<Vector2Int>();

            if (IsActivStoneSet())
            {
                foreach (Box childBox in activeStone.ChildrenBoxes)
                {
                    vectorList.Add(CalcCheckPosition(childBox, direction));
                }
            }

            return vectorList;
        }

        /// <summary>
        /// Get all box positions after the rotation.
        /// </summary>
        /// <returns>List of coordinates.</returns>
        public List<Vector2Int> GetRotationPositions()
        {
            if (IsActivStoneSet())
            {
                return activeStone.GetRotationPositions();
            }
            else
            {
                return new List<Vector2Int>();
            }
        }

        /// <summary>
        /// Calculate box position after the movement.
        /// </summary>
        /// <param name="box"></param>
        /// <param name="direction">Movement direction.</param>
        /// <returns>Coordinates</returns>
        private Vector2Int CalcCheckPosition(Box box, Direction direction)
        {
            Vector2Int checkPosition = box.GetIntPosition() + DirectionToVector(direction) * Constant.BOX_SIZE;
            return checkPosition;
        }

        /// <summary>
        /// Direction to Vector.
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        private Vector2Int DirectionToVector(Direction direction)
        {
            Vector2Int dirVector;
            switch (direction)
            {
                case Direction.DOWN:
                    dirVector = Vector2Int.down;
                    break;
                case Direction.LEFT:
                    dirVector = Vector2Int.left;
                    break;
                case Direction.RIGHT:
                    dirVector = Vector2Int.right;
                    break;
                default:
                    dirVector = Vector2Int.zero;
                    Debug.LogWarning("DirectionToVector(): Direction unknown: " + direction.ToString());
                    break;
            }
            return dirVector;
        }

        /// <summary>
        /// Move stone in direction.
        /// </summary>
        /// <param name="direction"></param>
        public void MoveInDirection(Direction direction)
        {
            if (IsActivStoneSet())
            {
                activeStone.MoveStone(direction);
            }
        }

        /// <summary>
        /// Rotate Stone.
        /// No validation check if the stone exists!
        /// </summary>
        public void Rotate()
        {
            activeStone.Rotate();
        }

        /// <summary>
        /// Destroy active stone.
        /// </summary>
        public void Touchdown()
        {
            if (IsActivStoneSet())
            {
                Destroy(activeStone.gameObject);
                activeStone = null;
            }
        }
    }
}
