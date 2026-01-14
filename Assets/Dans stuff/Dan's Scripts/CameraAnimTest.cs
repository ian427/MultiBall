using System.Collections;
using UnityEngine;

public class CameraAnimTest : MonoBehaviour
{
    private Animator anim;
    private float resetTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        resetTime = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NormalCam()
    {
        anim.SetBool("BallHitWall", false);
    }

    public void ShakyCam()
    {
        anim.SetBool("BallHitWall", true);
        //StartCoroutine(ResetCam());
    }

    public IEnumerator ResetCam()
    {
        yield return new WaitForSeconds(resetTime);
        NormalCam();
    }
}
