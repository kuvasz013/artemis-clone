using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTurret : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    ParticleSystem emitter;

    // Start is called before the first frame update
    void Start()
    {
        emitter = GetComponent<ParticleSystem>();
        Vector3 relativePos = endPoint.position - startPoint.position;
        emitter.transform.position = startPoint.position;
        emitter.transform.rotation = Quaternion.LookRotation(relativePos, Vector3.up);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
