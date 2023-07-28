using System;
using System.Collections;
using System.Collections.Generic;
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
        private static readonly int _toDeath = Animator.StringToHash("ToDeath");
        private bool _isDeathed;

        public static PlayerAnimation Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        private void Update()
        {
            SetAnimatorBools();
        }

        private void SetAnimatorBools()
        {
            if (_isDeathed) return;
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

        public void SetDeathAnimation()
        {
            _isDeathed = true;
            ResetToFalseAllBools();
            _animator.SetTrigger(_toDeath);
        }
        
        private void ResetToFalseAllBools()
        {
            _animator.SetBool(_toIdle, false);
            _animator.SetBool(_toRun, false);
            _animator.SetBool(_toAttack, false);
        }
    }
}