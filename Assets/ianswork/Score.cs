using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Timer;
    private int Minutes;
    private int Seconds;
    private int Total;
    private void Start()
    {
        StartScore();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartScore()
    {
        StartCoroutine(goScore());
    }

    System.Collections.IEnumerator goScore()
    {
        if ((Seconds > 59) || (Seconds == 59))
        {
            Seconds = 0;
            Minutes++;
        }
        Seconds++;
        Total++;
        Timer.text = Minutes + ":" + Seconds;
        yield return new WaitForSeconds(1f);
        StartCoroutine(goScore());
    }
    public int GetScore()
    {
        return Total;
    }
}
