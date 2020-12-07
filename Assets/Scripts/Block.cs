using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    [SerializeField] AudioClip breakSound;

    //sample code changes

    Level level; //Cached Reference
    GameStatus score;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.CountBreakableBlocks();

        score = FindObjectOfType<GameStatus>();
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
        score.AddToScore();
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        level.BlockDestroyed();
    }
}
