using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SoftGames.MagicWords
{
    public class DialoguesChat : MonoBehaviour
    {
        #region UI References

        [Header("Dialogue UI Elements")]
        [Tooltip("Text element to display the speaker's name.")]
        [SerializeField] private TextMeshProUGUI nameText;

        [Tooltip("Text element to display the message with emojis.")]
        [SerializeField] private TextMeshProUGUI messageText;

        [Tooltip("Image element to display the speaker's avatar.")]
        [SerializeField] private Image avatarImage;

        #endregion

        #region Public Methods

        /// <summary>
        /// Sets the dialogue entry data.
        /// </summary>
        /// <param name="name">The name of the speaker.</param>
        /// <param name="message">The dialogue message.</param>
        /// <param name="avatar">The avatar sprite.</param>
        public void SetDialogue(string name, string message, Sprite avatar)
        {
            nameText.text = string.IsNullOrEmpty(name) ? "Unknown" : name;
            messageText.text = string.IsNullOrEmpty(message) ? "..." : message;
            avatarImage.sprite = avatar;
        }

        #endregion
    }
}
