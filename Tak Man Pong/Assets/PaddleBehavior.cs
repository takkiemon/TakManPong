using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleBehavior : MonoBehaviour
{
    public int score;
    public float moveSpeed;
    public KeyCode moveUp;
    public KeyCode moveDown;
    public float maxHeight;
    public float minHeight;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        maxHeight = 5.5f;
        minHeight = -3.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(moveUp) && gameObject.transform.position.y <= maxHeight)
        {
            gameObject.transform.position += new Vector3(0, moveSpeed, 0);
        }
        if (Input.GetKey(moveDown) && gameObject.transform.position.y >= minHeight)
        {
            gameObject.transform.position -= new Vector3(0, moveSpeed, 0);
        }
    }
}
