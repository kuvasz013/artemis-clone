using UnityEngine;

public class CollideSound : MonoBehaviour
{
    public AudioClip sfx;
    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = sfx;
    }

    void OnCollisionEnter()
    {
        GetComponent<AudioSource>().Play();
    }
}