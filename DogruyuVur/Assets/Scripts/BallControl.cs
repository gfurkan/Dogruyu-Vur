using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    [SerializeField]
    private GameObject[] ballPrefabs;
    [SerializeField]
    private Transform ballTransform;
    [SerializeField]
    private AudioClip ballFired;
    [SerializeField]
    private AudioSource audioSource;

    Queue<GameObject> balls;

    float fireSpeed = 100;
    bool oneShot = true;
    void Start()
    {
        BallPool();
    }

    void Update()
    {
        
    }
    void BallPool()
    {
        balls = new Queue<GameObject>();
        for (int i = 0; i < 20; i++)
        {
            GameObject ball = (GameObject)Instantiate(ballPrefabs[Random.Range(0, ballPrefabs.Length)]);
            ball.transform.position = transform.position;
            ball.transform.rotation = transform.rotation;
            ball.SetActive(false);
            balls.Enqueue(ball);
        }
    }
    public void Fire(float x,float y)
    {
        if (oneShot)
        {
           
            var firingBall = balls.Dequeue();
            firingBall.SetActive(true);
            firingBall.name = "ActiveBall";
            firingBall.transform.position = ballTransform.position;
            firingBall.transform.rotation = ballTransform.rotation;
            Rigidbody2D fbRb = firingBall.GetComponent<Rigidbody2D>();
            fbRb.AddForce(new Vector2(x, y) * fireSpeed);
            if (PlayerPrefs.GetInt("volume") == 1)
            {
                audioSource.PlayOneShot(ballFired);
            }
            oneShot = false;
            
        }


    }
    public void EnqueueBall()
    {
            var activeBall = GameObject.Find("ActiveBall");
            activeBall.transform.position = transform.position;
            activeBall.SetActive(false);
            activeBall.name = "PassiveBall";
            balls.Enqueue(activeBall);
        oneShot = true;
        
    }
} 
