using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    public Camera cam;
    public float speed = 1.5f;
    public float chaseDist = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float dist = Vector3.Distance(cam.transform.position, gameObject.transform.position);

        if (dist <= chaseDist)
        {
            transform.position = Vector3.MoveTowards(transform.position, cam.transform.position, speed * Time.deltaTime);

        }

    }
}
