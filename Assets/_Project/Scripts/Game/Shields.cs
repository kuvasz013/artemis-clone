using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shields : MonoBehaviour
{
    private AudioSource audioSource;
    private MeshRenderer meshRenderer;
    private Coroutine fickle;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void Damage(Damage damage)
    {
        audioSource.Play();

        //If the coroutine is running, we stop it, and reinitiate it
        if (fickle != null)
        {
            StopCoroutine(fickle);
        }
            fickle = StartCoroutine(FickleShields());
    }

    private IEnumerator FickleShields()
    {
        meshRenderer.enabled = true;

        //Changes the alpha of the shields in a random manner
        Color newColor = meshRenderer.material.color;
        for (int i = 0; i < 40; i++)
        {
            float newAlpha = .05f + Random.value / 10;
            newColor.a = newAlpha;
            meshRenderer.material.color = newColor;
            yield return new WaitForSeconds(.02f);
        }

        meshRenderer.enabled = false;

        //Nullify fickle to signal it has been finished
        fickle = null;
    }
}
