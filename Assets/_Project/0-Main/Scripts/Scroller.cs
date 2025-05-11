using UnityEngine;
using UnityEngine.UI;

namespace SoftGames.UI
{
    /// <summary>
    /// Scrolls the UV of a RawImage over time to create a texture scrolling effect.
    /// </summary>
    [RequireComponent(typeof(RawImage))]
    public class Scroller : MonoBehaviour
    {
        #region Serialized Fields

        [Header("Scroll Target")]
        [Tooltip("The RawImage component whose UV will be scrolled.")]
        [SerializeField] private RawImage targetImage;

        [Header("Scroll Speed")]
        [Tooltip("Scroll speed in the X direction.")]
        [SerializeField] private float scrollSpeedX = 0.1f;

        [Tooltip("Scroll speed in the Y direction.")]
        [SerializeField] private float scrollSpeedY = 0.0f;

        #endregion

        #region Unity Methods

        private void Reset()
        {
            targetImage = GetComponent<RawImage>();
        }

        private void Update()
        {
            if (targetImage == null) return;

            Vector2 offset = new Vector2(scrollSpeedX, scrollSpeedY) * Time.deltaTime;
            Rect currentRect = targetImage.uvRect;
            currentRect.position += offset;
            targetImage.uvRect = currentRect;
        }

        #endregion
    }
}
