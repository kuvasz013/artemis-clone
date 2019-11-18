using System.Collections;
using UnityEngine;

public class LaserTurret : MonoBehaviour
{
    public GameObject projectile;
    private SelectionController selection;
    private AudioSource audioSource;
    public int burstCount = 5;
    public float burstInterval = .2f;
    public float aimingRange = 200;
    public float flyRange = 100;
    public float damagePerShot = 3;
    public DamageType damageType = DamageType.normal;

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
            
            //Update projectile maximum range
            instance.GetComponent<ProjectileController>().PassRange(flyRange);

            //Copy DamageHandler data and pass it to projectile
            DamageHandler projectileDamageHandler = instance.AddComponent<DamageHandler>();
            projectileDamageHandler.damagePerShot = damagePerShot;
            projectileDamageHandler.damageType = damageType;

            //Set the ship to be the parent of the projectile
            //This way it's easier to identify own, for bypassing own shields for example
            instance.transform.SetParent(transform.parent);
            yield return new WaitForSeconds(burstInterval);
        }
    }
}
