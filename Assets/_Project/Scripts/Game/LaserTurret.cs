using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTurret : MonoBehaviour
{
    public GameObject projectile;
    private SelectionController selection;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        selection = GetComponentInParent<SelectionController>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (selection.GetCurrentTarget() != null)
            {
                audioSource.Play();

                Transform target = selection.GetCurrentTarget().transform;
                Quaternion rotation = Quaternion.LookRotation((target.position - transform.position), Vector3.forward);
                GameObject instance = (GameObject)Instantiate(projectile, transform.position, rotation);
            }
        }
    }
}
