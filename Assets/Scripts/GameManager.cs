using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject PauseUI;
    public GameObject InGameUI;
    public Rigidbody2D rb;
    public void Replay()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    public void startgame()
    {
        SceneManager.LoadSceneAsync("Level_01");
    }

    public void stopgame()
    {
        Application.Quit();
    }

    public void menu()
    {
        SceneManager.LoadSceneAsync("Menu");
        
    }

    public void levels()
    {
        SceneManager.LoadSceneAsync("Levels");
        
    }

    public void pause()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        FindObjectOfType<AudioManger>().play("Background");
        InGameUI.SetActive(false);
        PauseUI.SetActive(true);
    }

    public void resume()
    {
        rb.constraints = ~RigidbodyConstraints2D.FreezePosition;
        FindObjectOfType<AudioManger>().stop("Background");
        PauseUI.SetActive(false);
        InGameUI.SetActive(true);
    }
}
