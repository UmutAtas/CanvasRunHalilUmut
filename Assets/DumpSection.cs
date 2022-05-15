using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DumpSection : MonoBehaviour
{
    [SerializeField] Transform dumpParent;
    [SerializeField] private Transform slider;
    [SerializeField] private Transform sliderTarget;
    [NonSerialized] public bool dumped = false;
    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3 && !triggered)
        {
            triggered = true;
            GameManager.Instance.dumpSection = true;
            Dump();
            MoveSlider();
        }
    }

    private void Dump()
    {
        var length = 5;
        var gridArray = Grid.Instance.gridList;
        for (int i = 0; i < Grid.Instance.currentX; i++)
        {
            for (int j = Grid.Instance.currentZ -1; j >= length; j--)
            {
                gridArray[i,j].transform.SetParent(dumpParent);
                var rb = gridArray[i, j].GetComponent<Rigidbody>();
                rb.AddForce(0f,0f,130f);
                dumped = true;
            }
        }
        Grid.Instance.currentZ -= length;
    }

    private void MoveSlider()
    {
        slider.DOMove(sliderTarget.position, 1f).SetDelay(3f).OnComplete(() =>
        {
            GameManager.Instance.dumpSection = false;
        });
    }
}
