using System.Collections;
using Tetris.Localization;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tetris.Manager
{
    /// <summary>
    /// Gamestart operations and parameter.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private string localizationFile = null;
        [SerializeField] private GameLanguage gameLanguage = GameLanguage.DE;

        [Tooltip("Size of the game board.")]
        [SerializeField] private Vector2Int boardDimensions = new Vector2Int(10, 20);

        public static GameManager Instance { get; private set; }

        public Vector2Int BoardSize { get; private set; } = new Vector2Int(10, 20);

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Debug.LogError("GameManager: Second instance error.");
                Destroy(gameObject);
            }
        }

        private IEnumerator Start()
        {
            BoardSize = boardDimensions;
            LocalizationHandler.SetLanguage(gameLanguage);
            LocalizationHandler.LoadLocalizedText(localizationFile);
            while (!LocalizationHandler.IsReady())
            {
                yield return null;
            }
            if (SceneName._preload.ToString().Equals(SceneManager.GetActiveScene().name))
            {
                SceneManager.LoadScene(SceneName.MainMenu.ToString());
            }
        }
    }
}
