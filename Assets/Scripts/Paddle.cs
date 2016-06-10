using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 PaddlePos = transform.localPosition;
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
        mousePosInBlocks = Mathf.Clamp(mousePosInBlocks, 0f, 15f);
        PaddlePos.x = mousePosInBlocks - 0.5f;
        transform.localPosition = PaddlePos;
	}
}
