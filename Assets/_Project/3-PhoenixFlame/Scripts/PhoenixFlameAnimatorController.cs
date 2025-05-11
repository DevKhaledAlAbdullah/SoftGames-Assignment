using UnityEngine;

namespace SoftGames.PhoenixFlame
{
    public class PhoenixFlameAnimatorController : MonoBehaviour
    {
        [SerializeField] private Animator fireAnimator;

        private enum FlameColor { Orange, Green, Blue }
        private FlameColor currentColor = FlameColor.Orange;

        public void CycleColor()
        {
            switch (currentColor)
            {
                case FlameColor.Orange:
                    fireAnimator.SetTrigger(Constants.ConstStrings.ToGreen);
                    currentColor = FlameColor.Green;
                    break;
                case FlameColor.Green:
                    fireAnimator.SetTrigger(Constants.ConstStrings.ToBlue);
                    currentColor = FlameColor.Blue;
                    break;
                case FlameColor.Blue:
                    fireAnimator.SetTrigger(Constants.ConstStrings.ToOrange);
                    currentColor = FlameColor.Orange;
                    break;
            }
        }
    }
}
