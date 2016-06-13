using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour
{
    public AudioClip crack;
    public Sprite[] hitSprites;
    public static int breakableCount = 0;

    int timesHit;
    LevelManager levelManager;
    bool isBreakable;

    void Start()
    {
        isBreakable = (this.tag == "Breakable");

        // Keep track of breakable bricks
        if(isBreakable)
        {
            breakableCount++;
        }

        timesHit = 0;
        levelManager = FindObjectOfType<LevelManager>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(crack, transform.position);
        if(isBreakable)
        {
            HandleHits();
        }
    }

    void HandleHits()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit == maxHits)
        {
            breakableCount--;
            levelManager.BrickDestroyed();
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        Sprite sprite = hitSprites[spriteIndex];
        if(sprite)
        {
            GetComponent<SpriteRenderer>().sprite = sprite;
        }
    }
}
