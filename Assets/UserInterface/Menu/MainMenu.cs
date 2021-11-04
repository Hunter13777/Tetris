using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tetris.UserInterface.Menu
{
    /// <summary>
    /// Game main menu
    /// </summary>
    public class MainMenu : MonoBehaviour
    {
        public void QuitGame()
        {
            Application.Quit();
        }

        public void StartGame()
        {
            SceneManager.LoadScene(SceneName.InGame.ToString());
        }
    }
}
