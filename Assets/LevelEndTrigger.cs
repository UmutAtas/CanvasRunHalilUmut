using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;


public class LevelEndTrigger : MonoBehaviour
{
    private bool triggered;
    [SerializeField] private Transform pTransform;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3 && !triggered)
        {
            GameManager.Instance.levelEnd = true;
            GameManager.Instance.afterDump = false;
            triggered = true;
            GameManager.Instance.dumpSection = true;
            LevelEndForce();
            pTransform.DOMove(new Vector3(0f, 0.125f, 268.4f), 3f);
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
