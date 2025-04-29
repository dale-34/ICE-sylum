using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GeneratorManager : MonoBehaviour
{
    public static bool genFailed = false;
    private bool genSet = false;

    // generators
    public GameObject gen_1;
    public Image gen_1_image;

    public GameObject gen_2;
    public Image gen_2_image;

    public GameObject gen_3;
    public Image gen_3_image;

    public int[] failOrder;
    int failIndex = 0;

    public AudioSource audioSource;
    public Text genFailText;


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
            gen_1_image.color = Color.green;
            gen_2_image.color = Color.green;
            gen_3_image.color = Color.green;
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
        genFailText.text = "";
        genFailed = false;
        genSet = false;
        currGenID = 0;
        audioSource.Stop();
        ResetLights();
    }

    void Start()
    {
        lights = GameObject.FindGameObjectsWithTag("light");
        gen_1_image.color = Color.green;
        gen_2_image.color = Color.green;
        gen_3_image.color = Color.green;

        genFailText.text = "";
    }

    void Update()
    {
        if (genFailed)
        {

            if (!genSet)
            {
                audioSource.Play();

                // randomly generated generator - currGenID = Random.Range(1, 4);

                currGenID = failOrder[failIndex];
                if (failIndex + 1 == failOrder.Length)
                {
                    failIndex = 0;
                }
                else
                {
                    failIndex++;
                }

                


                genFailText.text = "A generator has failed! \r\nYou must manually restart it!";

                if (currGenID == 1)
                {
                    currGen = gen_1;
                    gen_1_image.color = Color.red;
                }
                else if (currGenID == 2)
                {
                    currGen = gen_2;
                    gen_2_image.color = Color.red;
                }
                else if (currGenID == 3)
                {
                    currGen = gen_3;
                    gen_3_image.color = Color.red;
                }

                Generator currGenScript = currGen.GetComponent<Generator>();
                currGenScript.genOn = false;

                TurnLightsRed();

                genSet = true;
            }
        }
    }
}
