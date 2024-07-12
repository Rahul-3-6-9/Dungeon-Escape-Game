using UnityEngine;

public class Flame : MonoBehaviour
{
    public Collider2D collider2d; // assign in Inspector
    public float frequency = 2f; // toggle every 1 second

    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= frequency)
        {
            timer = 0f;
            collider2d.enabled = !collider2d.enabled;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FindObjectOfType<AudioManger>().play("Flame");
        }
    }

}