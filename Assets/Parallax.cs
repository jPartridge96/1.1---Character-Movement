using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public new GameObject camera;
    public float parallaxEffect;

    private float len, startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        len = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        float dist = (camera.transform.position.x * parallaxEffect);
        float temp = (camera.transform.position.x * (1 - parallaxEffect));

        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

        if(temp > startPos + len)
            startPos += len;
        else if (temp < startPos - len)
            startPos -= len;
    }
}
