using UnityEngine;

public class WallBounce : MonoBehaviour
{
    [SerializeField] private GameObject cameraObject;
    [SerializeField] private CameraAnimTest test;

    private void Start()
    {
        //cameraObject = GameObject.Find("MainCamera");
        test = cameraObject.GetComponent<CameraAnimTest>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            test.ShakyCam();
        }
    }
}
