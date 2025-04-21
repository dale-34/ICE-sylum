using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnGeneratorOnWithButton : MonoBehaviour
{
    public GameObject generator;
    private GeneratorManager generatorManager;

    // Start is called before the first frame update
    void Start()
    {
        generatorManager = GameObject.FindGameObjectWithTag("GeneratorManager").GetComponent<GeneratorManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            Generator generatorComponent = generator.GetComponent<Generator>();
            generatorComponent.genOn = true;
            generatorManager.RestoreGenerator();
        }
    }

}
