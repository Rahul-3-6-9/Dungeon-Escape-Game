using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text score;
    public Player_Movements Player_Movements;
    void Update()
    {
        int score_unit = Player_Movements.score;
       score.text = "=0"+score_unit.ToString();
    }
}