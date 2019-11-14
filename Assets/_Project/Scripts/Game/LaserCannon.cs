using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCannon : MonoBehaviour
{
    private SelectionController selection;
    private AudioSource audioSource;
    private Light lightSource;
    public GameObject projectile;
    public float startWidth, endWidth;

    // Start is called before the first frame update
    void Start()
    {
        selection = GetComponentInParent<SelectionController>();
        audioSource = GetComponent<AudioSource>();
        lightSource = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (selection.GetCurrentTarget() != null)
            {
                audioSource.Play();
                lightSource.enabled = true;

                GameObject instance = (GameObject)Instantiate(projectile, transform.position, Quaternion.identity);

                instance.transform.SetParent(transform);
                instance.GetComponent<LineRenderController>().SetWidth(startWidth, endWidth);
                instance.GetComponent<LineRenderController>().SetSelection(selection);
                StartCoroutine(LineDestroyer(instance));
            }
        }
    }

    IEnumerator LineDestroyer(GameObject instance)
    {   
        yield return new WaitForSeconds(2);
        lightSource.enabled = false;
        Destroy(instance);
    }
}
