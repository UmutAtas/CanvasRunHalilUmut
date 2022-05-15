using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class LevelEndTrigger : MonoBehaviour
{
    private bool triggered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3 && !triggered)
        {
            print("girdi");
            triggered = true;
            GameManager.Instance.dumpSection = true;
            LevelEndForce();
        }
    }

    private void LevelEndForce()
    {
        for (int i = 0; i < Grid.Instance.currentX; i++)
        {
            for (int j = 0; j < Grid.Instance.currentZ; j++)
            {
                var rb = Grid.Instance.gridList[i, j].GetComponent<Rigidbody>();
                var force = Random.Range(100f, 300f);
                rb.AddForce(0f,0f,force);
            }
        }
    }
}
