using System;
using UnityEngine;


namespace SoftGames.MagicWords
{
    public class DataModels : MonoBehaviour
    {
        #region Data Models
        [Serializable]
        public class EmojiMap
        {
            public string Unicode;
            public string emoji;
        }

        [Serializable]
        public class RootResponse
        {
            public DialogueLine[] dialogue;
            public AvatarData[] avatars;
        }

        [Serializable]
        public class DialogueLine
        {
            public string name;
            public string text;
        }

        [Serializable]
        public class AvatarData
        {
            public string name;
            public string url;
            public string position;
        }

        #endregion
    }
}