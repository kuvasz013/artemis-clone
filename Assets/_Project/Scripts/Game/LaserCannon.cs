using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCannon : MonoBehaviour
{
    private SelectionController selection;
    private AudioSource audioSource;
    private Light lightSource;
    public GameObject projectile;
    public float startWidth, endWidth = .2f;
    public float shotDuration = 2;
    [Tooltip("Sets the number of cycles in which the whole damage value will be dealt during the Shot Duration. Smaller number means fewer cycles and larger damage portions, and vica versa.")]
    public int damageFractions = 5;
    private DamageHandler damageHandler;

    // Start is called before the first frame update
    void Start()
    {
        selection = GetComponentInParent<SelectionController>();
        audioSource = GetComponent<AudioSource>();
        lightSource = GetComponent<Light>();
        damageHandler = GetComponent<DamageHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject target = selection.GetCurrentTarget();

            if (target)
            {
                audioSource.Play();
                lightSource.enabled = true;

                GameObject instance = (GameObject)Instantiate(projectile, transform.position, Quaternion.identity);

                //Set the ship to be the parent, this way it's easier to identify object later
                instance.transform.SetParent(transform);

                instance.GetComponent<LineRenderController>().SetWidth(startWidth, endWidth);
                instance.GetComponent<LineRenderController>().SetSelection(selection);

                //Draw Line, deal damage, and destroy the render
                StartCoroutine(Shoot(instance, target));
            }
        }
    }

    IEnumerator Shoot(GameObject instance, GameObject target)
    {
        //Deal the whole damage in equal portions, spread during the whole shotDuration
        for (int i = 0; i < damageFractions; i++)
        {
            Damage damageFraction = new Damage(damageHandler.damagePerShot / damageFractions, damageHandler.damageType);
            DamageHelper.ApplyDamage(target, damageFraction);
            yield return new WaitForSeconds(shotDuration / damageFractions);
        }

        lightSource.enabled = false;
        Destroy(instance);
    }
}
