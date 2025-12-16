using UnityEngine;
using TMPro;

public class StartingCountdown : MonoBehaviour
{
    [SerializeField] private float startTime;
    [SerializeField] private float presentTime;

    [SerializeField] private float secondCounter;

    [SerializeField] private GameObject startingCanvas;
    [SerializeField] private GameObject timeTextObject;
    [SerializeField] private TMP_Text timeText;

    [HideInInspector] public bool started;
    [SerializeField] private AudioSource secondClick;
    [SerializeField] private AudioSource buzzer;
    private bool onTwo;

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

            secondCounter -= Time.unscaledDeltaTime;
            if(secondCounter <= 0)
            {
                secondClick.Play();
                secondCounter = 1f;
            }

            if(presentTime <= 0)
            {
                buzzer.Play();
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
        secondCounter = 1f;
        presentTime = startTime;
        secondClick.Play();
    }
}
