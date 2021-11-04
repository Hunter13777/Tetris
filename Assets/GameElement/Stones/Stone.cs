using System.Collections.Generic;
using Tetris.Controls;
using UnityEngine;

namespace Tetris.GameElement.Stone
{
    /// <summary>
    /// Game stone movement.
    /// Author: AZinman
    /// </summary>
    public class Stone : MonoBehaviour
    {
        public Box[] ChildrenBoxes { get; private set; }

        [Tooltip("Visual representation for every box part of this stone.")]
        [SerializeField] private Sprite sprite = null;
        [Tooltip("Should it be possible to rotate this stone.")]
        [SerializeField] private bool rotatable = true;

        private void Start()
        {
            ChildrenBoxes = GetComponentsInChildren<Box>();

            if (sprite != null)
            {
                foreach (Box childBox in ChildrenBoxes)
                {
                    childBox.SetSprite(sprite);
                    childBox.SetSortingLayer(SortingLayerType.Stone);
                }
            }
            else
            {
                Debug.LogWarning("Start(): Missing stone sprite.");
            }
        }

        /// <summary>
        /// Move stone in the direction.
        /// </summary>
        /// <param name="direction"></param>
        public void MoveStone(Direction direction)
        {
            switch (direction)
            {
                case Direction.DOWN:
                    transform.position = transform.position + Vector3.down * Constant.BOX_SIZE;
                    break;
                case Direction.LEFT:
                    transform.position = transform.position + Vector3.left * Constant.BOX_SIZE;
                    break;
                case Direction.RIGHT:
                    transform.position = transform.position + Vector3.right * Constant.BOX_SIZE;
                    break;
                default:
                    Debug.LogWarning("MoveStone(): Direction unknown: " + direction.ToString());
                    break;
            }
        }

        /// <summary>
        /// Get Coordinates of every box of this stone after rotation.
        /// </summary>
        /// <returns>List with coordinates.</returns>
        public List<Vector2Int> GetRotationPositions()
        {
            List<Vector2Int> positionList = new List<Vector2Int>();
            if (rotatable)
            {
                foreach (Box childBox in ChildrenBoxes)
                {
                    Vector2Int locPosition = childBox.GetIntLocalPosition();
                    Vector2Int locPositionRotated = new Vector2Int(-locPosition.y, locPosition.x);
                    Vector2Int globPositionRotated = locPositionRotated + GetIntPosition();

                    positionList.Add(globPositionRotated);
                }
            }
            return positionList;
        }

        /// <summary>
        /// Rotate the stone.
        /// </summary>
        public void Rotate()
        {
            if (rotatable)
            {
                foreach (Box childBox in ChildrenBoxes)
                {
                    Vector2 locPosition = childBox.transform.localPosition;
                    childBox.transform.localPosition = new Vector2(-locPosition.y, locPosition.x);
                }
            }
        }

        /// <summary>
        /// Get global position of this stone.
        /// </summary>
        /// <returns>Casted position.</returns>
        private Vector2Int GetIntPosition()
        {
            Vector3 postion = this.transform.position;
            return new Vector2Int((int)postion.x, (int)postion.y);
        }
    }
}
