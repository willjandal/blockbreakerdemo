using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject particleSFX;

    Level level; //Cached Reference

    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
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
