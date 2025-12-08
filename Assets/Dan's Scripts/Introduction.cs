using System.Collections;
using UnityEngine;

public class Introduction : MonoBehaviour
{
    [SerializeField] private float startTimeA;
    [SerializeField] private float presentTimeA;
    [SerializeField] private GameObject introTextA;

    [SerializeField] private float startTimeB;
    [SerializeField] private float presentTimeB;
    [SerializeField] private GameObject introTextB;

    [SerializeField] private bool firstIntroActive;
    [SerializeField] private bool lastIntroActive;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startTimeA = 2f;
        startTimeB = 2f;

        firstIntroActive = true;
        lastIntroActive = false;

        introTextA.SetActive(true);
        introTextB.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(firstIntroActive == true)
        {
            startTimeA -= 1 * Time.deltaTime;
            if(startTimeA <= 0)
            {
                firstIntroActive = false;
                introTextA.SetActive(false);
                StartCoroutine(ActivateNextText());
            }
        }

        if(lastIntroActive == true)
        {
            startTimeB -= 1 * Time.deltaTime;
            if(startTimeB <= 0)
            {
                lastIntroActive = false;
                introTextB.SetActive(false);
            }
        }
    }

    private IEnumerator ActivateNextText()
    {
        yield return new WaitForSeconds(1);
        lastIntroActive = true;
        introTextB.SetActive(true);
    }

    private IEnumerator ActivateCountdown()
    {
        yield return new WaitForSeconds(1);
    }
}
