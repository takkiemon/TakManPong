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

    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        score = 0;

        Vector3 tempVec3 = cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, 0));
        maxHeight = tempVec3.y - transform.localScale.y * 0.5f;
        tempVec3 = cam.ScreenToWorldPoint(new Vector3(0, 0, 0));
        minHeight = tempVec3.y + transform.localScale.y * 0.5f;
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
