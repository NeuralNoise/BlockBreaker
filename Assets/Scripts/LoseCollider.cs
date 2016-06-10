using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour
{
    LevelManager levelManager;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        levelManager.LoadLevel("Game Over");
    }
}
