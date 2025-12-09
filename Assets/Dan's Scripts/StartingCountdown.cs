using UnityEngine;
using TMPro;

public class StartingCountdown : MonoBehaviour
{
    [SerializeField] private float startTime;
    [SerializeField] private float presentTime;

    [SerializeField] private GameObject startingCanvas;
    [SerializeField] private GameObject timeTextObject;
    [SerializeField] private TMP_Text timeText;

    [HideInInspector] public bool started;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        started = true;
        timeTextObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(started == false)
        {
            presentTime -= Time.unscaledDeltaTime;
            timeText.text = Mathf.Ceil(presentTime).ToString();

            if(presentTime <= 0)
            {
                started = true;
                startingCanvas.SetActive(false);
                Time.timeScale = 1f;
            }
        }
    }

    public void StartCountdown()
    {
        started = false;
        startingCanvas.SetActive(true);
        timeTextObject.SetActive(true);
        startTime = 3f;
        presentTime = startTime;
    }
}
