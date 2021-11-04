using Tetris.GameElement.Board;
using Tetris.GameElement.Stone;
using Tetris.UserInterface.Menu;
using UnityEngine;

namespace Tetris.Controls
{
    /// <summary>
    /// Input management.
    /// Author: AZinman
    /// </summary>
    public class PlayerOneActionController : MonoBehaviour
    {
        [SerializeField] private BoardController boardController = null;
        [SerializeField] private StoneController stoneController = null;
        [SerializeField] private PauseMenu pauseMenu = null;

        [Range(0.01f, 1)]
        [Tooltip("Delay in seconds after which the button is recognized as hold.")]
        [SerializeField] private float initialHoldDelay = 0.4f;
        [Range(0.01f, 1)]
        [Tooltip("Command repeat delay in seconds, while button is hold.")]
        [SerializeField] private float continiousHoldDelay = 0.2f;

        private PlayerControls controls;

        private float nextMoveLeft;
        private float nextMoveRight;
        private float nextMoveDown;

        private bool moveLeftPerformed = false;
        private bool moveRightPerformed = false;
        private bool moveDownPerformed = false;

        private void Awake()
        {
            controls = new PlayerControls();

            controls.PlayerOneControls.Left.started += ctx => MoveLeftStateChange(true);
            controls.PlayerOneControls.Left.canceled += ctx => MoveLeftStateChange(false);

            controls.PlayerOneControls.Right.started += ctx => MoveRightStateChange(true);
            controls.PlayerOneControls.Right.canceled += ctx => MoveRightStateChange(false);

            controls.PlayerOneControls.Down.started += ctx => MoveDownStateChange(true);
            controls.PlayerOneControls.Down.canceled += ctx => MoveDownStateChange(false);

            controls.PlayerOneControls.Rotate.started += ctx => RotateIfPossible();

            controls.PlayerOneControls.Pause.started += ctx => pauseMenu.PauseStateChange();
        }

        private void Start()
        {
            nextMoveLeft = Time.time;
            nextMoveRight = Time.time;
            nextMoveDown = Time.time;
        }

        /// <summary>
        /// Repeat the action while movement button is hold. 
        /// </summary>
        private void FixedUpdate()
        {
            if (moveLeftPerformed && Time.time > nextMoveLeft)
            {
                MoveIfPossible(Direction.LEFT);
                nextMoveLeft = Time.time + continiousHoldDelay;
            }

            if (moveRightPerformed && Time.time > nextMoveRight)
            {
                MoveIfPossible(Direction.RIGHT);
                nextMoveRight = Time.time + continiousHoldDelay;
            }

            if (moveDownPerformed && Time.time > nextMoveDown)
            {
                MoveIfPossible(Direction.DOWN);
                nextMoveDown = Time.time + continiousHoldDelay;
            }
        }

        /// <summary>
        /// Button left was pressed or released.
        /// </summary>
        /// <param name="performed">true = pressed, false = released</param>
        private void MoveLeftStateChange(bool performed)
        {
            if (performed)
            {
                MoveIfPossible(Direction.LEFT);
                nextMoveLeft = Time.time + initialHoldDelay;
                moveLeftPerformed = true;
            }
            else
            {
                moveLeftPerformed = false;
            }
        }


        /// <summary>
        /// Button right was pressed or released.
        /// </summary>
        /// <param name="performed">true = pressed, false = released</param>
        private void MoveRightStateChange(bool performed)
        {
            if (performed)
            {
                MoveIfPossible(Direction.RIGHT);
                nextMoveRight = Time.time + initialHoldDelay;
                moveRightPerformed = true;
            }
            else
            {
                moveRightPerformed = false;
            }
        }


        /// <summary>
        /// Button down was pressed or released.
        /// </summary>
        /// <param name="performed">true = pressed, false = released</param>
        private void MoveDownStateChange(bool performed)
        {
            if (performed)
            {
                MoveIfPossible(Direction.DOWN);
                nextMoveLeft = Time.time + continiousHoldDelay;
                moveDownPerformed = true;
            }
            else
            {
                moveDownPerformed = false;
            }
        }

        /// <summary>
        /// Move Stone in the direction if valid movement.
        /// </summary>
        /// <param name="direction"> Movement direction</param>
        private void MoveIfPossible(Direction direction)
        {
            if (stoneController.IsActivStoneSet()
                && boardController.IsMovePossible(stoneController.GetMovePositions(direction)))
            {
                stoneController.MoveInDirection(direction);
            }
        }

        /// <summary>
        /// Rotate Stone in the direction if valid rotation.
        /// </summary>
        private void RotateIfPossible()
        {
            if (stoneController.IsActivStoneSet()
                && boardController.IsMovePossible(stoneController.GetRotationPositions()))
            {
                stoneController.Rotate();
            }
        }

        void OnEnable()
        {
            controls.PlayerOneControls.Enable();
        }

        void OnDisable()
        {
            controls.PlayerOneControls.Disable();
        }
    }
}
