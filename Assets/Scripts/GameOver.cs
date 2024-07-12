using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject gameoverUI;
    public Player_Movements Player_Movements;
    public Rigidbody2D rb;
    public GameObject InGameUI;
    void Update()
    {
        if (Player_Movements.IsDead)
        {
            InGameUI.SetActive(false);
            gameoverUI.SetActive(true);
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
        }
    }
}
