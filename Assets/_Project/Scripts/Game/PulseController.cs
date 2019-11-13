using UnityEngine;

public class PulseController : MonoBehaviour
{
    Component[] lights;
    Component[] exhausts;
    private bool exhaustActive;
    private AudioSource engineHum;
    // Start is called before the first frame update
    void Start()
    {
        lights = transform.GetComponentsInChildren(typeof(Light));
        exhausts = transform.GetComponentsInChildren(typeof(ParticleSystem));
        engineHum = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: Handle slow cooloff and warmup, and pulsing during flight
        foreach (Light light in lights)
        {
            light.intensity = 1f + Mathf.Abs(Mathf.Sin(Time.time * 10)) / 15;
        }
    }

    public void HandleExhaust(float acceleration)
    {
        if (exhaustActive != acceleration > 0)
        {
            ChangeExhaustStatus();
            exhaustActive = !exhaustActive;
        }
    }

    void ChangeExhaustStatus()
    {
        if (exhaustActive)
        {
            engineHum.Stop();
            foreach (ParticleSystem exhaust in exhausts)
            {
                exhaust.Stop();
            }
        }
        else
        {
            engineHum.Play();
            foreach (ParticleSystem exhaust in exhausts)
            {
                exhaust.Play();
            }
        }
    }
}
