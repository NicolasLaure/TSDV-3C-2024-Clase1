using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterAnimatorController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private PlayerMovement characterMovement;
    void Start()
    {
        characterMovement = GetComponent<PlayerMovement>();
        characterMovement.CharacterMove += OnCharacterMove;
        characterMovement.CharacterStop += OnCharacterStop;
    }

    void OnCharacterMove(object sender, EventArgs args)
    {
        animator.SetBool("isWalking", true);
    }
    void OnCharacterStop(object sender, EventArgs args)
    {
        animator.SetBool("isWalking", false);
    }
}
