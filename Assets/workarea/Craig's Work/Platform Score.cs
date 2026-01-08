using UnityEngine;
using UnityEngine.UI;

public class PlatformScore : MonoBehaviour
{
    public int Score;
    public Text ScoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D col)
    {

        if(col.gameObject.CompareTag("Ball"))
        {
            AddScore();
        }
    }
    void AddScore()
    {
        Score++;
        ScoreText.text = Score.ToString(); 
    }
}
