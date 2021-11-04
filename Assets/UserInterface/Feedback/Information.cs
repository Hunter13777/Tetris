using UnityEngine;
using UnityEngine.UI;

namespace Tetris
{
    /// <summary>
    /// Ingame informations.
    /// Author: AZinman
    /// </summary>
    public class Information : MonoBehaviour
    {
        [SerializeField] private Text scoreNumber = null;

        private int score = 0;

        /// <summary>
        /// Add points to the score.
        /// </summary>
        /// <param name="rowNumber"></param>
        public void AddPoints(int rowNumber)
        {
            score += rowNumber * 2 - 1;
            scoreNumber.text = score.ToString();
        }
    }
}
