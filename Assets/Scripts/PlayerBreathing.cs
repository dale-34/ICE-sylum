using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBreathing : MonoBehaviour
{
    public AudioSource audioSource;
    private bool wasBreathing = false;

    void Update()
    {
        if (EnemyChase.playBreathing && !wasBreathing)
        {
            audioSource.Play();
            wasBreathing = true;
        } 
        else if (!EnemyChase.playBreathing && wasBreathing)
        {
            audioSource.Stop();
            wasBreathing = false;
        }
    }
}

