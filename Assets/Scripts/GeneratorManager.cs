using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorManager : MonoBehaviour
{
    public bool genFailed = false;
    public bool genSet = false;

    // generators
    public GameObject gen_1;
    public GameObject gen_2;
    public GameObject gen_3;

    // lights
    public GameObject[] lights;

    // generator with issue
    public int currGenID;
    GameObject currGen;

    void ResetLights()
    {
        foreach (GameObject lightObj in lights)
        {
            Light light = lightObj.GetComponent<Light>();
            if (light != null)
            {
                light.color = Color.white;
            }
        }
    }

    void TurnLightsRed()
    {
        foreach (GameObject lightObj in lights)
        {
            Light light = lightObj.GetComponent<Light>();
            if (light != null)
            {
                light.color = Color.red;
            }
        }
    }

    public void RestoreGenerator()
    {
        genFailed = false;
        genSet = false;
        currGenID = 0;
        ResetLights();
    }

    void Start()
    {
        lights = GameObject.FindGameObjectsWithTag("light");
    }

    void Update()
    {
        if (genFailed)
        {
            if (!genSet)
            {
                currGenID = Random.Range(1, 4);

                if (currGenID == 1)
                {
                    currGen = gen_1;
                }
                else if (currGenID == 2)
                {
                    currGen = gen_2;
                }
                else if (currGenID == 3)
                {
                    currGen = gen_3;
                }

                Generator currGenScript = currGen.GetComponent<Generator>();
                currGenScript.genOn = false;

                TurnLightsRed();

                genSet = true;
            }
        }
    }
}
