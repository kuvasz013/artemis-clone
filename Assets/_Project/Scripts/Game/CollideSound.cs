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
    // Make sure that deathzone has a collider, box, or mesh.. ect..,
    // Make sure to turn "off" collider trigger for your deathzone Area;
    // Make sure That anything that collides into deathzone, is rigidbody;
}