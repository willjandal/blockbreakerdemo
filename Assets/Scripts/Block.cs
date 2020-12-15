using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject particleSFX;
    [SerializeField] int maxHits = 2;

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
            timesHit++;

            if (timesHit >= maxHits)
            {
                DestroyBlock();
            }
            
        }
        
    }

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
