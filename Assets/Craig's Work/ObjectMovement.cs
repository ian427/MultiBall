using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectMovement : MonoBehaviour
{
    public float speed = 5f;

    Vector2 _direction;
    public Rigidbody2D rb;
    public void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log(context.ReadValue<Vector2>());
        _direction = context.ReadValue<Vector2>();//direction for the varable
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // movement for platform
        transform.Translate(_direction * (speed * Time.deltaTime));

        /*if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0f, 0f);
        }*/
    }
}
