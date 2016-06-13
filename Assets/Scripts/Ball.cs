using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    Paddle paddle;
    bool hasStarted = false;
    Vector3 paddleToBallVector;
    AudioSource audioSource;
    Rigidbody2D rigidBody2D;

	// Use this for initialization
	void Start ()
    {
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
                GetComponent<Rigidbody2D>().velocity = new Vector3(2, 13, 0);
            }
        }

	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(0,0.2f), Random.Range(0, 0.2f));
        rigidBody2D.velocity += tweak;
        if(hasStarted)
        {
            audioSource.Play();
        }
    }
}
