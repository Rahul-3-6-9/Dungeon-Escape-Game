using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    public Text key;
    public Player_Movements Player_Movements;
    private int value = 0;
    void Update()
    {
        bool key_value = Player_Movements.Key_Collected;
        if (key_value) { value = 1; }
        key.text = ": " + value.ToString() + " / 1";
    }
}