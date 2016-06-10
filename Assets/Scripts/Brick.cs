using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour
{
    public int maxHits;
    int timesHit;
    LevelManager levelManager;

    void Start()
    {
        timesHit = 0;
        levelManager = FindObjectOfType<LevelManager>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        timesHit++;
    }

    // TODO Remove this method one we can actually win.
    void SimulateWin()
    {
        levelManager.LoadNextLevel();
    }
}
