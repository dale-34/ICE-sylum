using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public bool genOn = true;
    public bool turnGenOn = false;
    private GeneratorManager generatorManager;
    public int id = 0;

    // Start is called before the first frame update
    void Start()
    {
        generatorManager = GameObject.FindGameObjectWithTag("GeneratorManager").GetComponent<GeneratorManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (turnGenOn)
        {
            TurnGeneratorOn();
        }
        
    }

    void TurnGeneratorOn()
    {
        if (generatorManager.currGenID == id)
        {
            genOn = true;
            generatorManager.RestoreGenerator();
            turnGenOn = false;
        }
    }
}
