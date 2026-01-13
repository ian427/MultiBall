using UnityEngine;

public class CameraAnimTest : MonoBehaviour
{
    private Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            NormalCam();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            ShakyCam();
        }
    }

    public void NormalCam()
    {
        anim.SetBool("BallHitWall", false);
    }

    public void ShakyCam()
    {
        anim.SetBool("BallHitWall", true);
    }
}
