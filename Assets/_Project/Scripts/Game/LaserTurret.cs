using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTurret : MonoBehaviour
{
    public GameObject projectile;
    private SelectionController selection;
    private AudioSource audioSource;
    public int burstCount;
    public float burstInterval;

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
                Transform target = selection.GetCurrentTarget().transform;
                StartCoroutine(Shoot(target));
            }
        }
    }
    IEnumerator Shoot(Transform target)
    {
        for (int i = 0; i < burstCount; i++)
        {
            audioSource.Play();
            Quaternion rotation = Quaternion.LookRotation((target.position - transform.position), Vector3.forward);
            GameObject instance = (GameObject)Instantiate(projectile, transform.position, rotation);

            //Set the ship to be the parent of the projectile
            //This way it's easier to identify own, for bypassing own shields for example
            instance.transform.SetParent(transform.parent);
            yield return new WaitForSeconds(burstInterval);
        }
    }
}
