using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows.Speech;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rigidbody2D;
    public float Speed = 6f;
    public uiManager uiManager;
    public int LeftPlayerScore;
    public int RightPlayerScore;

    public static event Action BallReset;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        SendBallInRandomDirection();
    }

    private void SendBallInRandomDirection()
    {
        BallReset?.Invoke();
        
        rigidbody2D.velocity = Vector3.zero;
        rigidbody2D.isKinematic = true;
        transform.position = Vector3.zero;
        rigidbody2D.isKinematic = false;
        
        Vector2 newBallVector = new Vector2();
        newBallVector.x = Random.Range(-1f, 1f);
        newBallVector.y = Random.Range(-1f, 1f);
        rigidbody2D.velocity = newBallVector.normalized * Speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SendBallInRandomDirection();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Movement>() == null)
        {
            return;
        }

        collision.gameObject.GetComponent<Movement>().speed *= 1.1f;
        rigidbody2D.velocity *= 1.1f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (transform.position.x > 0)
        {
            Debug.Log("Player Left +1");
            LeftPlayerScore++;
            uiManager.SetLeftPlayerScoreText(LeftPlayerScore.ToString());
            
        }
        else
        {
            Debug.Log("Player Right +1");
            RightPlayerScore++;
            uiManager.SetRightPlayerScoreText(RightPlayerScore.ToString());
        }
        
        SendBallInRandomDirection();
    }
}