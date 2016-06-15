using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

    public bool autoPlay = false;
    Ball ball;

	// Use this for initialization
	void Start ()
    {
        Time.timeScale = 1.0f;
        ball = FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(autoPlay && ball.hasStarted)
        {
            AutoPlay();
        }
        else
        {
            MoveWithMouse();
        }
    }

    void MoveWithMouse()
    {
        Vector3 PaddlePos = transform.localPosition;
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
        mousePosInBlocks = Mathf.Clamp(mousePosInBlocks, 1f, 15f);
        PaddlePos.x = mousePosInBlocks;
        transform.localPosition = PaddlePos;
    }

    void AutoPlay()
    {
        Vector3 PaddlePos = transform.localPosition;
        Vector3 ballPos = ball.transform.localPosition;
        float pos = ballPos.x + Random.Range(-1.0f, 1.0f);
        PaddlePos.x = Mathf.Clamp(pos, 1f, 15f);
        transform.localPosition = PaddlePos;
    }   
}
