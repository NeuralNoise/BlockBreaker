using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour
{
    public AudioClip crack;
    public GameObject smoke;
    public Sprite[] hitSprites;
    public static int breakableCount = 0;

    int timesHit;
    LevelManager levelManager;
    SpriteRenderer spriteRenderer;
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
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        if (timesHit >= maxHits)
        {
            Destroy();
        }
        else
        {
            Damage();
        }
    }

    void Destroy()
    {
        breakableCount--;
        levelManager.BrickDestroyed();
        GameObject smokePuff = Instantiate(smoke, transform.position + new  Vector3(0.5f,0.25f,0), Quaternion.identity) as GameObject;
        ParticleSystem smokeSystem = smokePuff.GetComponent<ParticleSystem>();
        smokeSystem.startColor = spriteRenderer.color;
        DestroyObject(gameObject, 0.1f);
    }

    void Damage()
    {
        int spriteIndex = timesHit - 1;
        Sprite sprite = hitSprites[spriteIndex];
        if(sprite)
        {
            spriteRenderer.sprite = sprite;
        }
        else
        {
            Debug.LogError("Brick sprite missing");
        }
    }
}
