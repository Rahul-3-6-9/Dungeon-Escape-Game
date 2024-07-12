using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint_Animation : MonoBehaviour
{
    public Animator animator;
    public bool CheckpointReached;
    public bool hasLooped;
    public Player_Movements movements;
    void Start()
    {
        animator.Play("No Flag Checkpoint");
    }

    private void Update()
    {
        if (CheckpointReached)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f && !hasLooped)
            {
                hasLooped = true;
            }
            else if (hasLooped)
            {
                animator.Play("Checkpoint");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && movements.Key_Collected)
        {
            CheckpointReached = true;
            animator.Play("Flag Checkpoint 2");
        }
    }
}
