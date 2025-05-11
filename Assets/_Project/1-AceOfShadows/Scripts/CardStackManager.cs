using UnityEngine;
using System.Collections;
using TMPro;
using System.Collections.Generic;
using DG.Tweening;

namespace SoftGames.AceOfShadows
{
    public class CardStackManager : MonoBehaviour
    {
        #region Fields

        [Header("Card Setup")]
        [SerializeField] private GameObject cardPrefab;
        [SerializeField] private int totalCards = 144;
        [SerializeField] public TextMeshProUGUI dealerTotalCardsText;
        [SerializeField] private Transform deckPosition;
        [SerializeField] private Players[] players;
        [SerializeField] private float cardOffsetZ = 0.02f;
        [SerializeField] private float cardOffsetX = 0.02f;
        [Header("Card Sprites")]
        [SerializeField] private Sprite[] frontCardSprites;
        [SerializeField] private GameObject finishedUI;

        private Stack<GameObject> deckStack = new Stack<GameObject>();
        private List<GameObject>[] playerStacks;
        private int dealtCardCount = 0;
        private int currentPlayerIndex = 0;

        #endregion

        #region Unity Methods

        private void Start()
        {
            SetupStacks();
            StartCoroutine(DealCardsRoutine());
        }

        #endregion

        #region Initialization

        private void SetupStacks()
        {
            finishedUI.SetActive(false);

            playerStacks = new List<GameObject>[players.Length];
            for (int i = 0; i < playerStacks.Length; i++)
                playerStacks[i] = new List<GameObject>();

            for (int i = 0; i < totalCards; i++)
            {
                GameObject card = Instantiate(cardPrefab, deckPosition.position, Quaternion.identity, deckPosition);
                card.transform.localPosition += new Vector3(-i * cardOffsetX, 0, -i * cardOffsetZ);

                // Assign random sprite
                Sprite randomSprite = frontCardSprites[Random.Range(0, frontCardSprites.Length)];
                Card cardScript = card.GetComponent<Card>();
                cardScript.SetFrontSprite(randomSprite);
                cardScript.FlipToBack();

                deckStack.Push(card);
            }

            // Flip the top card
            //if (deckStack.TryPeek(out GameObject top))
            //    top.GetComponent<Card>().FlipToFront();

            UpdateStackCounters();
        }

        #endregion

        #region Core Logic

        private IEnumerator DealCardsRoutine()
        {
            while (dealtCardCount < totalCards)
            {
                yield return new WaitForSeconds(1f);

                if (deckStack.Count == 0) break;

                GameObject topCard = deckStack.Pop();
                Card cardScript = topCard.GetComponent<Card>();

                Transform target = players[currentPlayerIndex].playerPos.transform;
                int targetIndex = currentPlayerIndex;
                int stackDepth = playerStacks[targetIndex].Count;

                playerStacks[targetIndex].Add(topCard);
                dealtCardCount++;

                Vector3 targetPos = target.position + new Vector3(0, 0, -stackDepth * cardOffsetZ);
                topCard.transform.SetParent(null);

                // Move the card to the target
                topCard.transform.DOMove(targetPos, 0.5f)
                    .SetEase(Ease.InOutSine)
                    .OnComplete(() =>
                    {
                        topCard.transform.SetParent(target);
                        topCard.transform.rotation = Quaternion.identity; // reset rotation after flip
                        UpdateStackCounters();
                    });

                // Mid-air flip after 0.25s
                //DOVirtual.DelayedCall(0.25f, () =>
                //{
                    cardScript.FlipToFront();
                //});

                currentPlayerIndex = (currentPlayerIndex + 1) % players.Length;

                
            }

            yield return new WaitForSeconds(1f);
            finishedUI.SetActive(true);
        }

        #endregion

        #region UI

        private void UpdateStackCounters()
        {
            for (int i = 0; i < players.Length; i++)
            {
                players[i].stackCountersText.text = playerStacks[i].Count.ToString();
            }

            dealerTotalCardsText.text = (totalCards - dealtCardCount).ToString();
        }

        #endregion
    }
}
