using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject particleSFX;
    //[SerializeField] int maxHits = 2;
    [SerializeField] Sprite[] hitSprites;

    //cache reference
    Level level;

    //state variables
    [SerializeField] int timesHit; // TODO: deserialized on Release



    private void Start()
    {
        CountBreakableBlocks();

    }


    /// <summary>
    /// Only counts the Breakable Blocks
    /// </summary>
    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();

        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (tag == "Breakable")
        {
            HandleHit();
        }

    }

    /// <summary>
    /// Counts the times the ball hits a block with health count
    /// </summary>
    private void HandleHit()
    {
        timesHit++;

        int maxHits = hitSprites.Length + 1;

        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }

        else
        {
            ShowNextHitSprite();
        }
    }


    /// <summary>
    /// Shows the next Sprite for Damaged blocks
    /// </summary>
    private void ShowNextHitSprite()
    {

        int spriteIndex = timesHit - 1;

        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }

        else
        {
            Debug.LogError("Block sprite is missing from array");
        }
         
    }

    /// <summary>
    /// Destroys the Blocks, executes the SFX and adds a the score
    /// </summary>
    private void DestroyBlock()
    {
        //AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        level.BlockDestroyed();
        destroyedObjectSFX();
        FindObjectOfType<GameStatus>().AddToScore();
    }

    private void destroyedObjectSFX()
    {
        GameObject particleFX = Instantiate(particleSFX, transform.position, transform.rotation);
        Destroy(particleFX, 1f);
    }
}
