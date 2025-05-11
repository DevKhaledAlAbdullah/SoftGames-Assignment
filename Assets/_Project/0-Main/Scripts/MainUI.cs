using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using SoftGames.Constants;
using SoftGames.Events;

namespace SoftGames.UI
{
    public class MainUI : MonoBehaviour
    {
        #region Fields


        #endregion

        #region Unity Methods

        private void Start()
        {
            Application.targetFrameRate = 60;
        }

        #endregion

        #region Button Handlers

        public void LoadAceOfShadows()
        {
            SceneManager.LoadScene(SceneNames.AceOfShadows);
        }

        public void LoadMagicWords()
        {
            SceneManager.LoadScene(SceneNames.MagicWords);
        }

        public void LoadPhoenixFlame()
        {
            SceneManager.LoadScene(SceneNames.PhoenixFlame);
        }

        public void QuitGame()
        {
            Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }

        #endregion
    }
}
