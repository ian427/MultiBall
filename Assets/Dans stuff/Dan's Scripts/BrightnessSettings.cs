using UnityEngine;
using UnityEngine.UI;

public class BrightnessSettings : MonoBehaviour
{
    [SerializeField] private Image brightnessOverlay;


    public void ChangeBrightness(float brightnessValue)
    {
        brightnessOverlay.color = new Color(0, 0, 0, 1f - brightnessValue);

        //Color overlayColor = brightnessOverlay.color;
        //overlayColor.a = brightnessValue;
        //brightnessOverlay.color = overlayColor;
    }
}
