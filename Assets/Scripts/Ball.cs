using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    Paddle paddle;
    bool hasStarted = false;
    Vector3 paddleToBallVector;

	// Use this for initialization
	void Start ()
    {
        paddle = FindObjectOfType<Paddle>();
        paddleToBallVector = transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(!hasStarted)
        {
            transform.position = paddle.transform.position + paddleToBallVector;
            if (Input.GetMouseButtonDown(0))
            {
                hasStarted = true;
                print("Launch ball");
                GetComponent<Rigidbody2D>().velocity = new Vector3(2, 15, 0);
            }
        }

	}
}
