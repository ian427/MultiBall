using UnityEngine;
using System.Collections;

public class BackgroundTransition : MonoBehaviour
{
    public GameObject defaultBG;
    public GameObject desertBG;
    public GameObject arcticBG;
    public GameObject jungleBG;
    public GameObject volcanoBG;

    [SerializeField] private Animator anim;
    [SerializeField] private float number;
    private string name;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        defaultBG.SetActive(true);
        desertBG.SetActive(false);
        arcticBG.SetActive(false);
        jungleBG.SetActive(false);
        volcanoBG.SetActive(false);

        anim.SetBool("Switching", false);
        name = "Default";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RandomNumber()
    {
        number = Random.Range(1, 5);
    }

    public void SwitchBackground()
    {
        anim.SetBool("Switching", true);
        RandomNumber();

        if(number == 1)
        {
            if(name != "Desert")
            {
                defaultBG.SetActive(false);
                desertBG.SetActive(true);
                arcticBG.SetActive(false);
                jungleBG.SetActive(false);
                volcanoBG.SetActive(false);

                name = "Desert";
            }

            else
            {
                SwitchBackground();
            }
            
        }

        if(number == 2)
        {
            if (name != "Arctic")
            {
                defaultBG.SetActive(false);
                desertBG.SetActive(false);
                arcticBG.SetActive(true);
                jungleBG.SetActive(false);
                volcanoBG.SetActive(false);

                name = "Arctic";
            }

            else
            {
                SwitchBackground();
            }

        }

        if (number == 3)
        {
            if (name != "Jungle")
            {
                defaultBG.SetActive(false);
                desertBG.SetActive(false);
                arcticBG.SetActive(false);
                jungleBG.SetActive(true);
                volcanoBG.SetActive(false);

                name = "Jungle";
            }

            else
            {
                SwitchBackground();
            }
        }

        if(number == 4)
        {
            if (name != "Volcano")
            {
                defaultBG.SetActive(false);
                desertBG.SetActive(false);
                arcticBG.SetActive(false);
                jungleBG.SetActive(false);
                volcanoBG.SetActive(true);

                name = "Volcano";
            }

            else
            {
                SwitchBackground();
            }
        }

        StartCoroutine(resetBool());
    }

    private IEnumerator resetBool()
    {
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("Switching", false);
    }
    
}
