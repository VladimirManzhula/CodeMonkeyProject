using UnityEngine;

namespace Game.Components
{
    public class PlayerAnimationComponent : MonoBehaviour
    {
        private const string IS_WALKING = "IsWalking";
        
        [SerializeField] private Animator animatorController;
        
        private static readonly int _isWalkable = Animator.StringToHash(IS_WALKING);
        
        public void SetWalkableBool(bool isWalkable) => animatorController.SetBool(_isWalkable, isWalkable);
    }
}