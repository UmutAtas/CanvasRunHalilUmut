using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DumpRebounce : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            other.gameObject.layer = 6;
            var rb = other.GetComponent<Rigidbody>();
            var xForce = Random.Range(-50f, 50f);
            var zForce = Random.Range(-50f, 50f);
            rb.AddForce(xForce,50f,zForce);
        }
    }
}
