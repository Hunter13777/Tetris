using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tetris.UserInterface.Menu
{
    /// <summary>
    /// Game pause / game over menu
    /// </summary>
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject gamePauseLable = null;
        [SerializeField] private GameObject gameOverLable = null;
        [SerializeField] private GameObject continueButton = null;

        private bool gameIsPaused = false;
        private bool gameOver = false;

        public void QuitGame()
        {
            Application.Quit();
        }

        public void BackToMainMenu()
        {
            UnPause();
            SceneManager.LoadScene(SceneName.MainMenu.ToString());
        }

        public void RestartScene()
        {
            UnPause();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        /// <summary>
        /// Pause if unpaused, unpause if paused.
        /// </summary>
        public void PauseStateChange()
        {
            if (!gameOver)
            {
                if (gameIsPaused)
                {
                    UnPause();
                }
                else
                {
                    Pause();
                }
            }
        }

        private void Pause()
        {
            gameObject.SetActive(true);
            Time.timeScale = 0f;
            gameIsPaused = true;
        }

        private void UnPause()
        {
            gameObject.SetActive(false);
            Time.timeScale = 1f;
            gameIsPaused = false;
        }

        /// <summary>
        /// Game Over screen.
        /// </summary>
        public void GameOver()
        {
            Pause();
            gamePauseLable.SetActive(false);
            gameOverLable.SetActive(true);
            continueButton.SetActive(false);
            gameOver = true;
        }
    }
}
