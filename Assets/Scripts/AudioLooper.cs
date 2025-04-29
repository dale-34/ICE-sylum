using UnityEngine;

public class AudioLooper : MonoBehaviour
{
    public AudioSource audioSource;
    public float interval = 10f;
    private float timer;

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
        timer = interval; 
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            audioSource.Play();
            timer = interval;
        }
    }
}
