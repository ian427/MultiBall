using System.Collections;

using UnityEngine;

using UnityEngine.UI;

public class BackgroundChanger : MonoBehaviour

{

    public Image backgroundImage; // Reference to the Image component displaying the background

    public Sprite[] backgroundSprites; // Array of sprites to cycle through

    public float timeBetweenChanges = 5f; // Time to wait before changing to the next background

    public float fadeDuration = 1f; // Time it takes to fade in/out

    private int currentBackgroundIndex = 0; // Track current background sprite index

    private void Start()

    {

        // Start the background change coroutine

        if (backgroundSprites.Length > 0)

        {

            StartCoroutine(ChangeBackground());

        }

    }

    private IEnumerator ChangeBackground()

    {

        while (true)

        {

            // Fade to transparent first

            yield return StartCoroutine(FadeOut());

            // Change to the next background

            currentBackgroundIndex = (currentBackgroundIndex + 1) % backgroundSprites.Length;

            backgroundImage.sprite = backgroundSprites[currentBackgroundIndex];

            // Fade in with the new background

            yield return StartCoroutine(FadeIn());

            // Wait before changing again

            yield return new WaitForSeconds(timeBetweenChanges);

        }

    }

    private IEnumerator FadeOut()

    {

        float timeElapsed = 0f;

        Color currentColor = backgroundImage.color;

        while (timeElapsed < fadeDuration)

        {

            timeElapsed += Time.deltaTime;

            float alpha = Mathf.Lerp(1f, 0f, timeElapsed / fadeDuration);

            backgroundImage.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);

            yield return null;

        }

        // Ensure the image is fully transparent at the end

        backgroundImage.color = new Color(currentColor.r, currentColor.g, currentColor.b, 0f);

    }

    private IEnumerator FadeIn()

    {

        float timeElapsed = 0f;

        Color currentColor = backgroundImage.color;

        while (timeElapsed < fadeDuration)

        {

            timeElapsed += Time.deltaTime;

            float alpha = Mathf.Lerp(0f, 1f, timeElapsed / fadeDuration);

            backgroundImage.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);

            yield return null;

        }

        // Ensure the image is fully opaque at the end

        backgroundImage.color = new Color(currentColor.r, currentColor.g, currentColor.b, 1f);

    }

}


