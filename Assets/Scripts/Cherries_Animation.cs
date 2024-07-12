using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;
    private bool hasLooped = false; 
    private bool Collected = false;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Collected)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f && !hasLooped)
            {
                hasLooped = true;
            }
            else if (hasLooped)
            {
                animator.enabled = false;
                Destroy(gameObject);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            // Stop the current animation
            animator.Rebind();
            FindObjectOfType<AudioManger>().play("Collected");

            // Play the new animation
            animator.enabled = true;
            animator.Play("Collected_Animation");
            Collected = true;

        }
    }
}