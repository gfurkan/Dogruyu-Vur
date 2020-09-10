using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReposition : MonoBehaviour
{
    [SerializeField]
    private GameObject ballPosition;

    BallControl ballControl;

    void Start()
    {
        ballControl = Object.FindObjectOfType<BallControl>();
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "edge" || collision.gameObject.tag=="circle")
        {
            ballControl.EnqueueBall();
        }
    }
}
