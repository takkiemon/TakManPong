using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    public Vector3 ballDirection;
    public bool goingRight;
    public float ballSpeed;
    public int leftScore;
    public int rightScore;

    private Camera cam;
    private float maxheight;
    private float minHeight;
    private float leftBoundary;
    private float rightBoundary;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

        if ((int)Random.Range(0, 2) == 1)
        {
            goingRight = true;
        } else
        {
            goingRight = false;
        }
        ballDirection = new Vector3(1, Random.Range(-1f, 1f), 0);

        maxheight = cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, 0)).y;
        minHeight = cam.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
        rightBoundary = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, 0)).x;
        leftBoundary = cam.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        leftScore = 0;
        rightScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (goingRight)
        {
            //gameObject.transform.position += new Vector3(ballSpeed, 0, 0);
            gameObject.transform.position += ballDirection * ballSpeed;
        } else
        {
            //gameObject.transform.position += new Vector3(-ballSpeed, 0, 0);
            gameObject.transform.position += ballDirection * -ballSpeed;
        }

        if (gameObject.transform.position.y > maxheight - gameObject.transform.localScale.y * 0.5f
            || gameObject.transform.position.y < minHeight + gameObject.transform.localScale.y * 0.5f)
        {
            ballDirection.y *= -1;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Paddle")
        {
            goingRight = !goingRight;
            ballDirection.y *= -1;
        }
    }
}
