using UnityEngine;

public class TrailRendererColour : MonoBehaviour
{
    private TrailRenderer tr;
    private float randomNumber;
    private string colorName;

    private GameObject colorCheckOBJ;
    private BallColorChecker bcc;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        colorCheckOBJ = GameObject.Find("EventSystem");
        bcc = colorCheckOBJ.GetComponent<BallColorChecker>();

        tr = GetComponent<TrailRenderer>();
        SetStartColour();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetStartColour()
    {
        randomNumber = Random.Range(1, 8);

        if(randomNumber == 1)
        {
            if(colorName != "Blue")
            {
                tr.startColor = Color.blue;
                colorName = "Blue";
                bcc.blueColor = true;
            }

            else
            {
                SetStartColour();
            }
        }

        if(randomNumber == 2)
        {
            if(colorName != "Yellow")
            {
                tr.startColor = Color.yellow;
                colorName = "Yellow";
                bcc.yellowColor = true;
            }

            else
            {
                SetStartColour();
            }
        }

        if(randomNumber == 3)
        {
            if(colorName != "Red")
            {
                tr.startColor = Color.red;
                colorName = "Red";
                bcc.redColor = true;
            }

            else
            {
                SetStartColour();
            }
        }

        if(randomNumber == 4)
        {
            if(colorName != "Green")
            {
                tr.startColor = Color.green;
                colorName = "Green";
                bcc.greenColor = true;
            }

            else
            {
                SetStartColour();
            }
        }

        if (randomNumber == 5)
        {
            if(colorName != "Purple")
            {
                tr.startColor = Color.purple;
                colorName = "Purple";
                bcc.purpleColor = true;
            }

            else
            {
                SetStartColour();
            }
        }

        if(randomNumber == 6)
        {
            if(colorName != "Orange")
            {
                tr.startColor = Color.orange;
                colorName = "Orange";
                bcc.orangeColor = true;
            }

            else
            {
                SetStartColour();
            }
        }

        if(randomNumber == 7)
        {
            if(colorName != "Pink")
            {
                tr.startColor = Color.pink;
                colorName = "Pink";
                bcc.pinkColor = true;
            }

            else
            {
                SetStartColour();
            }
        }
    }
}
