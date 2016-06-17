using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    Paddle paddle;
    public bool hasStarted = false;
    Vector3 paddleToBallVector;
    AudioSource audioSource;
    Rigidbody2D rigidBody2D;

	// Use this for initialization
	void Start ()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
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
                rigidBody2D.velocity = new Vector3(2, 8, 0);
            }
        }

	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(hasStarted)
        {
            audioSource.Play();
        }
    }
}
