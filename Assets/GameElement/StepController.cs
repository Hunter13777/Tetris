using Tetris.GameElement.Board;
using Tetris.GameElement.Stone;
using Tetris.Manager;
using UnityEngine;

namespace Tetris.GameElement
{
    /// <summary>
    /// Periodic movement of the stone, performed without player input.
    /// Author: AZinman
    /// </summary>
    public class StepController : MonoBehaviour
    {
        [SerializeField] private BoardController boardController;
        [SerializeField] private StoneController stoneController;

        [Range(0.1f, 2)]
        [Tooltip("Time in seconds between descent steps.")]
        [SerializeField] private float stepTime = 1f;

        private Vector2Int stoneSpawnPosition;

        private void Start()
        {
            InvokeRepeating("Step", 1f, stepTime);
            Vector2Int boardSize = GameManager.Instance.BoardSize;
            // Spawn position is in the middle of the top row.
            stoneSpawnPosition = new Vector2Int((boardSize.x - Constant.BOARD_LEFT_BORDER) / 2,
                boardSize.y - Constant.BOARD_GROUND);
        }

        /// <summary>
        /// Descent of the active stone.
        /// </summary>
        void Step()
        {
            if (stoneController.IsActivStoneSet())
            {
                if (boardController.IsMovePossible(stoneController.GetMovePositions(Direction.DOWN)))
                {
                    // Stone can be moved down.
                    stoneController.MoveInDirection(Direction.DOWN);
                }
                else
                {
                    // Stone reached its final position.
                    boardController.Touchdown(stoneController.GetActivStoneBoxes());
                    stoneController.Touchdown();
                }
            }
            else
            {
                // No activ stone on the board, create a new one.
                stoneController.CreateRandomStone(stoneSpawnPosition);
            }
        }
    }
}
