using UnityEngine;
using UnityEngine.UI;

public class VolumeButtonSlider : MonoBehaviour
{
    public Slider volumeSlider;
    public Button volumeDownButton;
    public Button volumeUpButton;
    public float stepSize = 0.05f; // how much each click changes volume

    void Start()
    {
        // Set initial slider value from AudioListener
        volumeSlider.value = AudioListener.volume;

        // Update audio volume when slider changes (if you also let it be interactive)
        volumeSlider.onValueChanged.AddListener((val) =>
        {
            AudioListener.volume = val;
        });

        // Left/right buttons change the slider value
        volumeDownButton.onClick.AddListener(() =>
        {
            volumeSlider.value = Mathf.Clamp01(volumeSlider.value - stepSize);
        });

        volumeUpButton.onClick.AddListener(() =>
        {
            volumeSlider.value = Mathf.Clamp01(volumeSlider.value + stepSize);
        });
    }
}
