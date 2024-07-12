using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Movements : MonoBehaviour
{

    public PlayerController controller;
    public Animator animator;
    public BoxCollider2D BoxCollider;

    int HorizontalMove = 0;
    public float Movement = 40f;
    bool jump = false;
    bool crouch = false;
    bool IsTrapped = false;
    public bool IsMoving = false;

    public int MaxHealth = 5;
    public int health;
    public int score = 0;
    private bool start = true;
    public bool Key_Collected; 
    private bool Gate_Destroy=false;

    public bool IsDead = false;
    public GameObject gameObject1;
    public Rigidbody2D rb;

    public HealthBar healthbar;

    public BoxCollider2D BoxCollider2D;
    public CircleCollider2D CircleCollider;

    public void Start()
    {
        animator.SetFloat("Speed", 0.00f);
        HorizontalMove = 0;
        rb.velocity = Vector3.zero;
        health = MaxHealth;
        healthbar.SetMaxHealth(MaxHealth);
        FindObjectOfType<AudioManger>().play("Start Level");
    }
    private void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(HorizontalMove));

        if (Input.GetKeyDown(KeyCode.D))
        {
            HorizontalMove = 1;
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            HorizontalMove = -1;
        }
        else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            HorizontalMove = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            crouch = true;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            crouch = false;
        }

        if (IsDead)
        {
            Destroy(BoxCollider2D);
            Destroy(CircleCollider);
        }

    }

    public void OnLanding()
    {
        animator.SetBool("IsJump", false);
    }

    void FixedUpdate()
    {
        controller.Move(Movement * HorizontalMove * Time.fixedDeltaTime, crouch, jump);
        if (jump)
        {
            animator.SetBool("IsJump", true);
        }
        jump = false;
        animator.SetBool("IsCrouch", !(BoxCollider.enabled));
        if (IsTrapped)
        {
            animator.SetBool("IsTrapped", true);
        }
        else
        {
            animator.SetBool("IsTrapped", false);
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Traps") || other.CompareTag("Dead"))
        {
            IsTrapped = true;
            health = health - 1;
            healthbar.SetHealth(health);
            if (health > 0)
            {
                FindObjectOfType<AudioManger>().play("Player_Hurt");
            }
            else
            {
                health = 0;
                healthbar.SetHealth(health);
                IsDead = true;
                FindObjectOfType<AudioManger>().stop("Player_Hurt");
                FindObjectOfType<AudioManger>().stop("Flame");
                FindObjectOfType<AudioManger>().play("Player_dead");
            }

        }
         else if (other.CompareTag("Fruit"))
        {
            score = score + 1;
            if (start)
            {
                score = score - 1;
                start = false;
            }
        }

        if (other.CompareTag("Dead"))
        {
            IsDead = true;
            healthbar.SetHealth(0);
            FindObjectOfType<AudioManger>().play("Player_dead");
        }

        if (other.CompareTag("Key"))
        {
            Key_Collected = true;
            Destroy(other.gameObject);
            FindObjectOfType<AudioManger>().play("Collected_Animation");
        }

        if (other.CompareTag("Finish") && Key_Collected)
        {
            Destroy(gameObject1);
            PlayerPrefs.SetInt("score", score);
            FindObjectOfType<AudioManger>().play("Level Complete");
            Invoke("LoadScene", 1.5f);
        }
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Traps"))
        {
            IsTrapped = false;
        }
    }

  
}
