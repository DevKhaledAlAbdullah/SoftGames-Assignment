using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System;
using DG.Tweening;
using static SoftGames.MagicWords.DataModels;
using UnityEngine.SceneManagement;

namespace SoftGames.MagicWords
{
    public class MagicWordsManager : MonoBehaviour
    {
        #region Serialized Fields

        [Header("UI References")]
        [SerializeField] private Transform contentParent;
        [SerializeField] private GameObject leftDialoguePrefab;
        [SerializeField] private GameObject rightDialoguePrefab;
        [SerializeField] private GameObject loadingSpinner;
        [SerializeField] private TextMeshProUGUI errorText;

        [Header("Avatar Fallback")]
        [SerializeField] private Sprite fallbackAvatar;

        [Header("API Settings")]
        [SerializeField] private string endpointUrl = "https://private-624120-softgamesassignment.apiary-mock.com/v3/magicwords";

        #endregion

        #region Runtime Data

        private Dictionary<string, AvatarData> avatarLookup;

        public List<EmojiMap> emojis = new List<EmojiMap>();

        #endregion

        #region Unity Methods

        private void Start()
        {
            StartCoroutine(FetchAndDisplayDialogues());
        }
        

        #endregion

        #region Core Logic

        private IEnumerator FetchAndDisplayDialogues()
        {
            loadingSpinner?.SetActive(true);
            errorText?.gameObject.SetActive(false);

            UnityWebRequest request = UnityWebRequest.Get(endpointUrl);
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                ShowError($"Failed to fetch data: {request.error}");
                yield break;
            }

            RootResponse response = null;

            try
            {
                response = JsonConvert.DeserializeObject<RootResponse>(request.downloadHandler.text);
            }
            catch (Exception ex)
            {
                ShowError($"Parsing error: {ex.Message}");
                yield break;
            }

            if (response == null || response.dialogue == null || response.avatars == null)
            {
                ShowError("Incomplete data received.");
                yield break;
            }
            loadingSpinner?.SetActive(false);
            // Map avatars by name (last wins)
            avatarLookup = new Dictionary<string, AvatarData>();
            foreach (var avatar in response.avatars)
            {
                avatarLookup[avatar.name] = avatar;
            }

            foreach (var dialogue in response.dialogue)
            {
                AvatarData avatar = avatarLookup.ContainsKey(dialogue.name) ? avatarLookup[dialogue.name] : null;
                yield return StartCoroutine(CreateDialogueEntry(dialogue, avatar));
                yield return new WaitForSeconds(1f); 
            }

           
        }

        private void ShowError(string message)
        {
            Debug.LogError(message);
            loadingSpinner?.SetActive(false);

            if (errorText != null)
            {
                errorText.text = message;
                errorText.gameObject.SetActive(true);
            }
        }

        private IEnumerator CreateDialogueEntry(DialogueLine dialogue, AvatarData avatar)
        {
            GameObject prefab = avatar?.position?.ToLower() == "right" ? rightDialoguePrefab : leftDialoguePrefab;

            GameObject dialogueGO = Instantiate(prefab, contentParent);
            dialogueGO.transform.localScale = Vector3.zero;

            // Animate from 0 → 1
            dialogueGO.transform.DOScale(Vector3.one, 0.3f).SetEase(Ease.OutBack);

            DialoguesChat chatComponent = dialogueGO.GetComponent<DialoguesChat>();
            if (chatComponent == null)
            {
                Debug.LogWarning("Missing DialoguesChat component.");
                yield break;
            }

            Sprite avatarSprite = fallbackAvatar;

            if (!string.IsNullOrEmpty(avatar?.url))
            {
                UnityWebRequest avatarRequest = UnityWebRequestTexture.GetTexture(avatar.url);
                yield return avatarRequest.SendWebRequest();

                if (avatarRequest.result == UnityWebRequest.Result.Success)
                {
                    Texture2D texture = DownloadHandlerTexture.GetContent(avatarRequest);
                    avatarSprite = Sprite.Create(texture,
                        new Rect(0, 0, texture.width, texture.height),
                        new Vector2(0.5f, 0.5f));
                }
            }

            chatComponent.SetDialogue(dialogue.name, ReplaceEmojis(dialogue.text), avatarSprite);
        }

        private string ReplaceEmojis(string text)
        {
            foreach (var pair in emojis)
            {
                text = text.Replace(pair.Unicode, pair.emoji);
            }

            return text;
        }
        #endregion
    }

  
}
