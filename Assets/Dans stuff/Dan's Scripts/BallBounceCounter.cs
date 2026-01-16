using System.Collections;
using UnityEngine;
using TMPro;

public class BallBounceCounter : MonoBehaviour
{
    private float ballCountMax;
    [SerializeField] private float ballCount;

    [SerializeField] private float randomNumber;
    [SerializeField] private GameObject rewardObject;
    [SerializeField] private TMP_Text rewardText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ballCountMax = 5f;
        ballCount = 0f;
        rewardObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            ballCount += 1;
            CountChecker();
        }
    }

    private void CountChecker()
    {
        if(ballCount == 5)
        {
            randomNumber = Random.Range(1, 5);

            if(randomNumber == 1)
            {
                rewardText.text = "Great job!";
            }

            if (randomNumber == 2)
            {
                rewardText.text = "You rock!";
            }

            if (randomNumber == 3)
            {
                rewardText.text = "Nice one!";
            }

            if (randomNumber == 4)
            {
                rewardText.text = "Well done!";
            }

            rewardObject.SetActive(true);
            StartCoroutine(turnTextOff());
        }

        if(ballCount > ballCountMax)
        {
            ballCount = 1;
        }
    }

    private IEnumerator turnTextOff()
    {
        yield return new WaitForSeconds(0.7f);
        rewardObject.SetActive(false);
    }
}
