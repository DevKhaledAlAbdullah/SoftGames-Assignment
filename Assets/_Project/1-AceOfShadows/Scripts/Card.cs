using UnityEngine;
using DG.Tweening;

namespace SoftGames.AceOfShadows
{
    public class Card : MonoBehaviour
    {
        #region Components

        [SerializeField] private GameObject front;
        [SerializeField] private GameObject back;
        [SerializeField] private SpriteRenderer frontRenderer;


        private bool isFaceUp = false;

        #endregion

        #region Flip Logic
        public void SetFrontSprite(Sprite sprite)
        {
            frontRenderer.sprite = sprite;
        }

        public void FlipToFront()
        {
            if (isFaceUp) return;

            isFaceUp = true;
            transform.DORotate(new Vector3(0, 90, 0), 0.25f)
                .OnComplete(() =>
                {
                    front.SetActive(false);
                    back.SetActive(true);
                    transform.DORotate(Vector3.zero, 0.25f);
                });
        }

        public void FlipToBack()
        {
            isFaceUp = false;
            front.SetActive(true);
            back.SetActive(false);
        }

        #endregion
    }
}
