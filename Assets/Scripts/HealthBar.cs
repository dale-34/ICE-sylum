using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public float full;
    public float curr;
    public Image fillRing;

    void Update()
    {
        fillRing.fillAmount = curr / full;
    }
}
