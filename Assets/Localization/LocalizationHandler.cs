using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Tetris.Localization
{
    /// <summary>
    /// Management of localization.
    /// Author: AZinman
    /// </summary>
    public static class LocalizationHandler
    {
        private static GameLanguage language = GameLanguage.DE;

        private static Dictionary<string, string> label;
        private static Dictionary<string, string> button;

        private static bool ready = false;

        public static void SetLanguage(GameLanguage gl)
        {
            language = gl;
        }

        /// <summary>
        /// Load localization file.
        /// </summary>
        /// <param name="fileName"></param>
        public static void LoadLocalizedText(string fileName)
        {
            label = new Dictionary<string, string>();
            button = new Dictionary<string, string>();

            string filePath = Path.Combine(Application.streamingAssetsPath, fileName);

            if (File.Exists(filePath))
            {
                string dataAsJson = File.ReadAllText(filePath);
                LocalizationData loadedData = JsonUtility.FromJson<LocalizationData>(dataAsJson);

                InitSingleText(label, loadedData.label);
                InitSingleText(button, loadedData.button);
            }
            else
            {
                Debug.LogWarning("LocalizationHandler: Missing file " + fileName);
            }
            ready = true;
        }

        /// <summary>
        /// Write text to Dictionary.
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="textLine"></param>
        private static void InitSingleText(Dictionary<string, string> dc, LocalizationSingleText[] textLine)
        {
            for (int i = 0; i < textLine.Length; i++)
            {
                dc.Add(textLine[i].textKey, TextLocalization(textLine[i].text));
            }
        }

        /// <summary>
        /// Get Textline in active language.
        /// </summary>
        /// <param name="multi"></param>
        /// <returns></returns>
        private static string TextLocalization(LocalizationMultilanguageText multi)
        {
            string locText;
            switch (language)
            {
                case GameLanguage.EN:
                    locText = multi.en;
                    break;
                case GameLanguage.DE:
                    locText = multi.de;
                    break;
                default:
                    locText = multi.de;
                    Debug.LogWarning("LocalizationHandler: Unknown language " + language.ToString());
                    break;
            }
            return locText;
        }

        /// <summary>
        /// Get label text text that corresponds to the key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Label(string key)
        {
            return GetSingleText(label, key);
        }

        /// <summary>
        /// Get button text text that corresponds to the key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Button(string key)
        {
            return GetSingleText(button, key);
        }

        /// <summary>
        /// Get text from specific dictionary.
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private static string GetSingleText(Dictionary<string, string> dc, string key)
        {
            string text = key;
            if (dc.ContainsKey(key))
            {
                text = dc[key];
            }
            else
            {
                Debug.LogWarning("LocalizationHandler: Localized text missing, key is " + key);
            }
            return text;
        }

        /// <summary>
        /// Loclization is loaded.
        /// </summary>
        /// <returns></returns>
        public static bool IsReady()
        {
            return ready;
        }
    }
}
