using UnityEngine;
using UnityEngine.SceneManagement;

namespace SoftGames.Utilities
{
    public class BackButton : MonoBehaviour
    {
        public void BackOnClick()
        {
            SceneManager.LoadScene(Constants.SceneNames.MainMenu, LoadSceneMode.Single);
        }

    }
}
