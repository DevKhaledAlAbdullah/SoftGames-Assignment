using UnityEngine;
using TMPro;

namespace SoftGames.Utilities
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class FPSCounter : MonoBehaviour
    {
        #region Fields

        [SerializeField] private float updateInterval = 0.5f;

        private float accumulated = 0f;
        private int frames = 0;
        private float timeLeft;
        private TextMeshProUGUI fpsText;

        #endregion

        #region Unity Methods

        private void Start()
        {
            fpsText = GetComponent<TextMeshProUGUI>();
            timeLeft = updateInterval;
        }

        private void Update()
        {
            timeLeft -= Time.deltaTime;
            accumulated += Time.timeScale / Time.deltaTime;
            frames++;

            if (timeLeft <= 0.0f)
            {
                float fps = accumulated / frames;
                fpsText.text = $"FPS: {Mathf.RoundToInt(fps)}";

                timeLeft = updateInterval;
                accumulated = 0f;
                frames = 0;
            }
        }

        #endregion
    }
}
