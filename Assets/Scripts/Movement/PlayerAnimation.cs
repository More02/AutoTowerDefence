using Damage;
using UnityEngine;

namespace Movement
{
    /// <summary>
    /// Управление анимацией
    /// </summary>
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        private static readonly int _toRun = Animator.StringToHash("ToRun");
        private static readonly int _toIdle = Animator.StringToHash("ToIdle");
        private static readonly int _toAttack = Animator.StringToHash("ToAttack");

        private void Update()
        {
            SetAnimatorBools();
        }

        private void SetAnimatorBools()
        {
            if ((Input.GetAxis("Horizontal") != 0) || (Input.GetAxis("Vertical") != 0))
            {
                ResetToFalseAllBools();
                _animator.SetBool(_toRun, true);
                if (!AutoShooter.Instance.IsFiring) return;
                ResetToFalseAllBools();
                _animator.SetBool(_toAttack, true);
            }
            else if (AutoShooter.Instance.IsFiring)
            {
                ResetToFalseAllBools();
                _animator.SetBool(_toAttack, true);
            }
            else
            {
                ResetToFalseAllBools();
                _animator.SetBool(_toIdle, true);
            }
        }
        
        private void ResetToFalseAllBools()
        {
            _animator.SetBool(_toIdle, false);
            _animator.SetBool(_toRun, false);
            _animator.SetBool(_toAttack, false);
        }
    }
}