using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trampoline : MonoBehaviour
{
    public Rigidbody2D rb;
    public float jump;
    public Animator animator;
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FindObjectOfType<AudioManger>().play("Player_Jump");
            animator.SetTrigger("Bounce");
            rb.AddForce(new Vector2(0f, jump));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
            animator.SetTrigger("NotBounce");
    }
}
