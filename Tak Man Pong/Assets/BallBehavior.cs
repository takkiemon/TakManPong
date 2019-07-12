using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    public Vector3 ballDirection;
    public bool goingRight;
    public float ballSpeed;
    // Start is called before the first frame update
    void Start()
    {
        if ((int)Random.Range(0, 2) == 1)
        {
            goingRight = true;
        } else
        {
            goingRight = false;
        }
        ballDirection = new Vector3(1, Random.Range(-1f, 1f), 0);
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
    }
}
