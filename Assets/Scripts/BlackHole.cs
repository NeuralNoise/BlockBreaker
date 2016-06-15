using UnityEngine;
using System.Collections;

public class BlackHole : MonoBehaviour
{
    public BlackHole blackHole;
    public int speed = 60;
    public bool active = true;

    // Use this for initialization
    void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        Rotate();
	}

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.transform.GetComponent<Ball>() && active)
        {
            Teleport(collider2D.transform);
        }
    }

    void OnTriggerExit2D(Collider2D collider2D)
    {
        if(collider2D.transform.GetComponent<Ball>())
        {
            //blackHole.active = true;
            active = true;
        }
    }

    void Rotate()
    {
        float rotationSpeed = - speed * 6 * Time.deltaTime;
        transform.Rotate(new Vector3(0, 0, rotationSpeed));
    }

    void Teleport(Transform ball)
    {
        blackHole.active = false;
        ball.position = blackHole.transform.position;
    }
}
