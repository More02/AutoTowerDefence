﻿using System;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private static readonly int _toRun = Animator.StringToHash("ToRun");
    private static readonly int _toIdle = Animator.StringToHash("ToIdle");
    private static readonly int _toAttack = Animator.StringToHash("ToAttack");

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
        if ((Input.GetAxis("Horizontal") != 0) || (Input.GetAxis("Vertical") != 0))
        {
            _animator.SetBool(_toRun, true);
            _animator.SetBool(_toIdle, false);
        }
        else
        {
            _animator.SetBool(_toIdle, true);
            _animator.SetBool(_toRun, false);
        }
    }

    // public void SetAttackAnimation()
    // {
    //     _animator.SetBool(_toAttack, true);
    //     _animator.SetBool(_toRun, false);
    //     _animator.SetBool(_toIdle, false);
    //     Debug.Log("attacked");
    // }
}