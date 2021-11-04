using UnityEngine;

namespace Tetris.GameElement
{
    /// <summary>
    /// Basic element of the board and stones.
    /// Author: AZinman
    /// </summary>
    [RequireComponent(typeof(SpriteRenderer))]
    public class Box : MonoBehaviour
    {
        /// <summary>
        /// Element can be filled with a stone.
        /// </summary>
        public bool Empty { get; set; } = true;

        private SpriteRenderer sr;

        private void Awake()
        {
            sr = GetComponent<SpriteRenderer>();
        }

        public void SetSprite(Sprite sprite)
        {
            sr.sprite = sprite;
        }

        public Sprite GetSprite()
        {
            return sr.sprite;
        }

        public void SetSortingLayer(SortingLayerType layer)
        {
            sr.sortingLayerName = layer.ToString();
        }

        /// <summary>
        /// Global position of this element.
        /// </summary>
        /// <returns>Casted position.</returns>
        public Vector2Int GetIntPosition()
        {
            Vector3 postion = this.transform.position;
            return new Vector2Int((int) postion.x, (int) postion.y);
        }

        /// <summary>
        /// Local position of this element.
        /// </summary>
        /// <returns>Casted position.</returns>
        public Vector2Int GetIntLocalPosition()
        {
            Vector3 postion = this.transform.localPosition;
            return new Vector2Int((int)postion.x, (int)postion.y);
        }
    }
}
