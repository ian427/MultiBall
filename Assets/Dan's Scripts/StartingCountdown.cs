using UnityEngine;
using TMPro;

public class StartingCountdown : MonoBehaviour
{
    [SerializeField] private float startTime;
    [SerializeField] private float presentTime;

    [SerializeField] private GameObject timeTextObject;
    [SerializeField] private TMP_Text timeText;

    private float increment;
    [HideInInspector] public bool started;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        started = true;
        timeTextObject.SetActive(true);
        startTime = 3f;
        increment = 1f;
        presentTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(started == false)
        {
            presentTime -= Time.deltaTime;
            timeText.text = Mathf.Ceil(presentTime).ToString();
            //timeText.text = presentTime.ToString();
            if(presentTime <= 0)
            {
                started = true;
                timeTextObject.SetActive(false);
            }
        }
    }
}
