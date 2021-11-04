using UnityEngine;
using UnityEngine.UI;

namespace Tetris.Localization
{
    /// <summary>
    /// Replace text key with localized test.
    /// Author: AZinman
    /// </summary>
    public class LocalizedTextComponent : MonoBehaviour
    {
        [SerializeField] private StaticTextType staticTextType = StaticTextType.NONE;
        [SerializeField] private string staticKey = null;

        private Text textComponent;
        private string text;

        void Start()
        {
            textComponent = GetComponent<Text>();
            if (!StaticTextType.NONE.Equals(staticTextType) && staticKey != null && staticKey.Length > 0)
            {
                switch (staticTextType)
                {
                    case StaticTextType.LABEL:
                        SetLabel(staticKey);
                        break;
                    case StaticTextType.BUTTON:
                        SetButton(staticKey);
                        break;
                    default:
                        Debug.LogError("LocalizedTextComponent: Unknown StaticTextType " + staticTextType.ToString());
                        break;
                }
            }
            ResetText();
        }

        /// <summary>
        /// Replays label key with localized test.
        /// </summary>
        /// <param name="key"></param>
        public void SetLabel(string key)
        {
            text = LocalizationHandler.Label(key);
            ResetText();
        }

        /// <summary>
        /// 
        /// Replays button key with localized test.
        /// </summary>
        /// <param name="key"></param>
        public void SetButton(string key)
        {
            text = LocalizationHandler.Button(key);
            ResetText();
        }

        /// <summary>
        /// Execute text replacement.
        /// </summary>
        private void ResetText()
        {
            if (textComponent != null && text != null)
            {
                textComponent.text = text;
            }
        }
    }
}
