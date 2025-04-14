using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trash : MonoBehaviour
{

    GameObject icecreams;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        icecreams = GameObject.FindGameObjectWithTag("IceCream");
    }

    private void OnMouseDown()
    {
        Destroy(icecreams);
    }
}
