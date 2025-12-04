using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public DataSerilizer Data;
    public Score score;
    
    [SerializeField] private TextMeshProUGUI HighScoretxt;
    [SerializeField] private TextMeshProUGUI CurrentScoretxt;
    public float FadeDelay = 1f;
    public float AlphaValue = 0;
    public GameObject Pannel;
    SpriteRenderer SpriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = GetComponent<Score>();
        Data = GameObject.Find("DataHolder").GetComponent<DataSerilizer>();
        SpriteRenderer = Pannel.GetComponent<SpriteRenderer>();
    }


    public void GameOver()
    {
        StartCoroutine(FadeTo(AlphaValue, FadeDelay));
        int Highscore = Data.GetHighTime();
        int newscore = score.GetScore();
        if(newscore > Highscore)
        {
            Data.SetHighTime(Highscore);
            //show new score
            Highscore = newscore;
            int Minutes = 0,seconds = 0;
            while (newscore > 60)
            {
                newscore -= 60;
                Minutes++;

            }
            seconds = newscore;
            HighScoretxt.text = Minutes + ":" + seconds;
            CurrentScoretxt.text = Minutes + ":" + seconds;
            
        }
        else
        {
            int SMinutes = 0, SSeconds = 0, HMinutes = 0, HSeconds = 0;
            //show old score 
            while (newscore > 60)
            {
                newscore -= 60;
                SMinutes++;

            }
            HSeconds = newscore;
            while (Highscore > 60)
            {
                Highscore -= 60;
                HMinutes++;

            }
            HSeconds = Highscore;
            HighScoretxt.text = HMinutes + ":" + HSeconds;
            CurrentScoretxt.text = SMinutes + ":" + SSeconds;
        }
       
    }
    private System.Collections.IEnumerator FadeTo(float aValue, float FadeTime)
    {
        float alpha = SpriteRenderer.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / FadeTime)
        {

            Color NewColor = new Color(SpriteRenderer.color.r, SpriteRenderer.color.g, SpriteRenderer.color.b, Mathf.Lerp(alpha, aValue, t));
            SpriteRenderer.color = NewColor;
            yield return null;


        }
    }

}
