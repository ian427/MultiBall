using System.Collections;
using UnityEngine;

public class SpriteCrossFade : MonoBehaviour
{
    public SpriteRenderer mainRenderer;  // Your primary renderer
    public Sprite[] sprites;             // All sprites to cycle through

    public float timeBetweenChanges = 5f;
    public float fadeDuration = 1f;

    private SpriteRenderer fadeRenderer;
    private int currentIndex = 0;

    private void Start()
    {
        if (sprites.Length == 0)
            return;

        // Create a fade renderer as a child
        GameObject fadeObj = new GameObject("FadeRenderer");
        fadeObj.transform.SetParent(transform);
        fadeObj.transform.localPosition = Vector3.zero;

        fadeRenderer = fadeObj.AddComponent<SpriteRenderer>();
        fadeRenderer.sortingLayerID = mainRenderer.sortingLayerID;
        fadeRenderer.sortingOrder = mainRenderer.sortingOrder + 1; // Render above main
        fadeRenderer.color = new Color(1, 1, 1, 0); // Start invisible

        // Set initial sprite
        mainRenderer.sprite = sprites[currentIndex];

        StartCoroutine(CycleSprites());
    }

    private IEnumerator CycleSprites()
    {
        while (true)
        {
            int nextIndex = (currentIndex + 1) % sprites.Length;
            Sprite nextSprite = sprites[nextIndex];

            fadeRenderer.sprite = nextSprite;
            fadeRenderer.color = new Color(1f, 1f, 1f, 0f);

            float t = 0f;

            // Cross fade
            while (t < fadeDuration)
            {
                t += Time.deltaTime;
                float a = t / fadeDuration;

                fadeRenderer.color = new Color(1, 1, 1, a);     // Fade in
                mainRenderer.color = new Color(1, 1, 1, 1 - a); // Fade out

                yield return null;
            }

            // Swap
            mainRenderer.sprite = nextSprite;
            mainRenderer.color = Color.white;

            fadeRenderer.color = new Color(1, 1, 1, 0);

            currentIndex = nextIndex;

            yield return new WaitForSeconds(timeBetweenChanges);
        }
    }
}
