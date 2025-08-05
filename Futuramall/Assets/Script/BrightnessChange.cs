using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BrightnessController : MonoBehaviour
{
    [Header("UI Elements")]
    public Slider brightnessSlider;
    public Button brightnessDownButton;
    public Button brightnessUpButton;

    [Header("Brightness Target")]
    public CanvasGroup fadeOverlayCanvasGroup;

    [Header("Settings")]
    public float stepSize = 0.05f;
    public float minAlpha = 0f;   // Fully bright
    public float maxAlpha = 0.7f; // Darker screen
    public float fadeDelay = 1.5f; // Wait this long before taking over (match your fade-in duration)

    void Start()
    {
        // Start the delayed setup
        StartCoroutine(EnableBrightnessControlAfterFade());
    }

    IEnumerator EnableBrightnessControlAfterFade()
    {
        yield return new WaitForSeconds(fadeDelay);

        // Now hook up brightness slider and buttons
        brightnessSlider.minValue = minAlpha;
        brightnessSlider.maxValue = maxAlpha;
        brightnessSlider.value = fadeOverlayCanvasGroup.alpha;

        brightnessSlider.onValueChanged.AddListener((val) =>
        {
            fadeOverlayCanvasGroup.alpha = 1-val;
        });

        brightnessDownButton.onClick.AddListener(() =>
        {
            brightnessSlider.value = Mathf.Clamp(brightnessSlider.value - stepSize, minAlpha, maxAlpha);
        });

        brightnessUpButton.onClick.AddListener(() =>
        {
            brightnessSlider.value = Mathf.Clamp(brightnessSlider.value + stepSize, minAlpha, maxAlpha);
        });

        Debug.Log("Brightness control enabled after fade.");
    }
}
