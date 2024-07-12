using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public void level01()
    {
        SceneManager.LoadSceneAsync("Level_01");
        
    }

    public void level02()
    {
        SceneManager.LoadSceneAsync("Level_02");
        
    }

    public void level03()
    {
        SceneManager.LoadSceneAsync("Level_03");
        
    }

}
