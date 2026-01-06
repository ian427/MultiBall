using UnityEngine;
using UnityEngine.UI;

public class BrightnessSettings : MonoBehaviour
{
    [SerializeField] private Image brightnessImage;
    [SerializeField] private Slider brightnessSlider;

    [Range(0f, 1f)]
    [SerializeField] private float maxDarkness = 0.9f;
    private float currentBrightness;
    private float savedBrightness;

    private void Start()
    {
        savedBrightness = PlayerPrefs.GetFloat("ScreenBrightness", 0f);
        brightnessSlider.value = savedBrightness;
        SetBrightness(savedBrightness);
        brightnessSlider.onValueChanged.AddListener(SetBrightness);
    }

    public void SetBrightness(float value)
    {
        PlayerPrefs.SetFloat("ScreenBrightness", value);
        currentBrightness = Mathf.Lerp(maxDarkness, 0f, value);
        Color color = brightnessImage.color;
        color.a = currentBrightness;
        brightnessImage.color = color;
    }
}
