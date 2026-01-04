using UnityEngine;
using UnityEngine.UI;

public class LoadBrightness : MonoBehaviour
{
    [SerializeField] private Image brightnessImage;
    [SerializeField] private float loadedBrightness;
    private float maxDarkness = 0.9f;

    private void Start()
    {
        loadedBrightness = PlayerPrefs.GetFloat("ScreenBrightness");
        loadedBrightness = Mathf.Lerp(0f, maxDarkness, loadedBrightness);
        Color color = brightnessImage.color;
        color.a = loadedBrightness;
        brightnessImage.color = color;
    }
}
