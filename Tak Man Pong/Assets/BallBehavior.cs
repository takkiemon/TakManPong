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
    private Vector3 storedPosition;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

        if ((int)Random.Range(0, 2) == 1)
        {
            SpawnBall(true);
        }
        else
        {
            SpawnBall(false);
        }

        maxheight = cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, 0)).y;
        minHeight = cam.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
        rightBoundary = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, 0)).x;
        leftBoundary = cam.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        leftScore = 0;
        rightScore = 0;
    }

    public void SpawnBall(bool goingRight)
    {
        this.goingRight = goingRight;
        storedPosition = new Vector3(0, 0, 0);
        gameObject.transform.position = storedPosition;
        ballDirection = new Vector3(1, Random.Range(-1f, 1f), 0);
    }

    // Update is called once per frame
    void Update()
    {
        storedPosition = gameObject.transform.position;
        if (goingRight)
        {
            //gameObject.transform.position += new Vector3(ballSpeed, 0, 0);
            storedPosition += ballDirection * ballSpeed;
        } else
        {
            //gameObject.transform.position += new Vector3(-ballSpeed, 0, 0);
            storedPosition += ballDirection * -ballSpeed;
        }

        if (storedPosition.y > maxheight - gameObject.transform.localScale.y * 0.5f
            || storedPosition.y < minHeight + gameObject.transform.localScale.y * 0.5f)
        {
            ballDirection.y *= -1;
        }

        if (storedPosition.x > rightBoundary + gameObject.transform.localScale.x * 0.5f)
        {
            rightScore++;
            SpawnBall(true);
        } else if (storedPosition.x < leftBoundary - gameObject.transform.localScale.x * 0.5f)
        {
            leftScore++;
            SpawnBall(false);
        }

        gameObject.transform.position = storedPosition;
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
