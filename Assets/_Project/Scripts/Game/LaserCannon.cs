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
    public float shotDuration;

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
                
                //Set the ship to be the parent, this way it's easier to identify object later
                instance.transform.SetParent(transform);

                instance.GetComponent<LineRenderController>().SetWidth(startWidth, endWidth);
                instance.GetComponent<LineRenderController>().SetSelection(selection);

                //Destroy Line GameObject after predefined period of time
                StartCoroutine(LineDestroyer(instance));
            }
        }
    }

    IEnumerator LineDestroyer(GameObject instance)
    {   
        yield return new WaitForSeconds(shotDuration);
        lightSource.enabled = false;
        Destroy(instance);
    }
}
