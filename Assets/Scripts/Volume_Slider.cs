using UnityEngine;
using UnityEngine.UI;

public class Volume_Slider : MonoBehaviour
{
    public Slider slider; // The Slider component

    private void Start()
    {
        // Get a reference to the Slider component
        slider = GetComponent<Slider>();

        // Add a listener to the onValueChanged event
        slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void OnSliderValueChanged(float value)
    {
        // Print the slider value to the console
        Debug.Log("Slider value: " + value);
    }
}