using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInterfaceFunctions : MonoBehaviour
{
    public GameObject window;

    public void Close()
    {
        window.SetActive(false);
    }

    public void Open()
    {
        window.SetActive(true);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // If running a built application
        Application.Quit();
#endif
    }
}
