using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball : MonoBehaviour
{

    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 10f;
    //[SerializeField] AudioClip[] ballSound;
    [SerializeField] AudioClip ballSound;

    Vector2 paddleToBallVector;

    bool hasStarted = false;

    //cached component references
    AudioSource myAudioSource;

    // Start is called before the first frame update
    void Start()
    {

        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        /*LockBallToPaddle();
        LaunchOnMouseClick();*/

        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();

        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Primary Button Clicked");
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
        }

    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddleToBallVector + paddlePos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            //AudioClip clip = ballSound[UnityEngine.Random.Range(0, ballSound.Length)];
            myAudioSource.PlayOneShot(ballSound);
        }

    }
}
