using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string SceneToLoad;

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneToLoad);
    }
}
