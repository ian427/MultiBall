using UnityEngine;
using TMPro;

public class StartingCountdown : MonoBehaviour
{
    //The start and current time floats
    [SerializeField] private float startTime;
    [SerializeField] private float presentTime;
    [SerializeField] private float secondCounter;

    //The canvas and accompanying objectives
    [SerializeField] private GameObject startingCanvas;
    [SerializeField] private GameObject timeTextObject;
    [SerializeField] private TMP_Text timeText;

    //The started bools and matching audio sources
    [HideInInspector] public bool started;
    [SerializeField] private AudioSource secondClick;
    [SerializeField] private AudioSource buzzer;
    private bool onTwo;

    //Sets the started value to true and turns off the timeTextObject;
    void Start()
    {
        started = true;
        timeTextObject.SetActive(false);
    }

    //If started is off then the time will begin counting down. If it hits 0, the starting sound plays, the main canvas is on and the time starts
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

    //A function called in another script that will begin the process to start the 3 2 1 countdown
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
