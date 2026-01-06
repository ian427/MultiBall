using System.Collections;
using UnityEngine;

public class Introduction : MonoBehaviour
{
    //The values and objects relating to the starting time and countdown of the first UI text
    [SerializeField] private float startTimeA;
    [SerializeField] private float presentTimeA;
    [SerializeField] private GameObject introTextA;

    //The values and objects relating to the starting time and countdown of the second UI text
    [SerializeField] private float startTimeB;
    [SerializeField] private float presentTimeB;
    [SerializeField] private GameObject introTextB;

    //Bools to see which intros are active or not
    [SerializeField] private bool firstIntroActive;
    [SerializeField] private bool lastIntroActive;

    //Used for the computer version
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject tapToPlay;
    [SerializeField] private StartingCountdown sc;

    //A bool for skipping the intro
    [SerializeField] private bool skipped;

    private Coroutine nextText;
    private Coroutine countdown;

    [SerializeField] private AudioSource voiceLine1;
    [SerializeField] private AudioSource voiceLine2;

    //Starts by setting the tapToPlay overlay as true and the regular canvas as false. The time scale is stopped
    void Start()
    {
        skipped = false;
        tapToPlay.SetActive(true);
        canvas.SetActive(false);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Starts the game when space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnGameStart();
        }

        if(skipped == true)
        {
            return;
        }

        //If the skipped value is false, then the countdown will begin which will display the first intro text while waiting for the second one to start
        if(firstIntroActive == true && skipped == false)
        {
            if (skipped == false)
            {
                startTimeA -= Time.unscaledDeltaTime;
                if (startTimeA <= 0)
                {
                    firstIntroActive = false;
                    introTextA.SetActive(false);
                    nextText = StartCoroutine(ActivateNextText());
                }
            }
        }

        //Loads the second intro text and begins the next countdown that shows the other text
        if(lastIntroActive == true)
        {
            if(skipped == false)
            {
                startTimeB -= Time.unscaledDeltaTime;
                if (startTimeB <= 0)
                {
                    lastIntroActive = false;
                    introTextB.SetActive(false);
                    countdown = StartCoroutine(ActivateCountdown());
                }
            }
        }
    }

    //Function called when the game begins, such as starting the text countdown
    public void OnGameStart()
    {
        canvas.SetActive(true);
        tapToPlay.SetActive(false);
        StartCoroutine(beginIntroSequence());
    }

    //
    private IEnumerator beginIntroSequence()
    {
        Time.timeScale = 0;
        yield return null;

        startTimeA = 2f;
        startTimeB = 2f;

        firstIntroActive = true;
        lastIntroActive = false;

        introTextA.SetActive(true);
        introTextB.SetActive(false);

        voiceLine1.Play();
    }

    //A void that is called when a button is pressed. It will skip the intro sequence. 
    public void SkipIntros()
    {
        skipped = true;

        if (nextText != null)
        {
            StopCoroutine(nextText);
        }

        if (countdown != null)
        {
            StopCoroutine(countdown);
        }

        firstIntroActive = true;
        lastIntroActive = false;
        introTextA.SetActive(false);
        introTextB.SetActive(false);

        sc.StartCountdown();
    }

    private IEnumerator ActivateNextText()
    {
        yield return new WaitForSecondsRealtime(1);
        if (skipped == true) yield break;
        lastIntroActive = true;
        introTextB.SetActive(true);
        voiceLine2.Play();
    }

    //An IEnumerator that will begin the 321 countdown after the final intro text id displayed
    private IEnumerator ActivateCountdown()
    {
        yield return new WaitForSecondsRealtime(1);
        if (skipped == true) yield break;
        sc.StartCountdown();
    }

    //AI assistance was used to help make adjustments so the script could function properly
}
