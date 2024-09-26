using UnityEngine;

namespace PlayerControl
{
    public class PlayerAnimationController : MonoBehaviour
    {
        private static readonly int NormalSpeed = Animator.StringToHash("NormalSpeed");
        
        [SerializeField] private PlayerMover playerMover;
        [SerializeField] private Animator animator;

        private void OnEnable() => playerMover.OnJoystickTilt += SetRunAnimationValue;
        private void OnDisable() => playerMover.OnJoystickTilt -= SetRunAnimationValue;
        private void SetRunAnimationValue(Vector2 direction) => animator.SetFloat(NormalSpeed, direction.magnitude);
    }
}
