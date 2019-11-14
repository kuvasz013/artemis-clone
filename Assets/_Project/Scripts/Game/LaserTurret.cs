using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTurret : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    private GameObject laserRay;
    private Vector3 relativePos;

    // Start is called before the first frame update
    void Start()
    {
        laserRay = transform.GetChild(0).gameObject;
        relativePos = endPoint.position - startPoint.position;
        transform.rotation = Quaternion.LookRotation(relativePos, Vector3.up);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        laserRay.transform.Translate(transform.forward * Time.deltaTime * 10, Space.World);
    }
}
