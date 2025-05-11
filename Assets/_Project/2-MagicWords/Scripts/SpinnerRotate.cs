using UnityEngine;

namespace SoftGames.UI
{    
    public class SpinnerRotate : MonoBehaviour
    {
        #region Serialized Fields

        [Header("Rotation Settings")]
        [Tooltip("Speed of the spinner rotation in degrees per second.")]
        [SerializeField] private float rotationSpeed = 100f;

        #endregion

        #region Private Fields

        private Vector3 currentRotation;

        #endregion

        #region Unity Methods

        private void Start()
        {
            currentRotation = transform.eulerAngles;
        }

        private void Update()
        {
            currentRotation.z -= rotationSpeed * Time.deltaTime;
            transform.eulerAngles = currentRotation;
        }

        #endregion
    }
}
