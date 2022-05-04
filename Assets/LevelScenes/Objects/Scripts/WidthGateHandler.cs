using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

public class WidthGateHandler : MonoBehaviour
{
    public int textNumber;
    public int multiplier;
    private TextMeshProUGUI txt;
    private void Start()
    {
        GetGateWidth();
    }
    private void GetGateWidth()
    {
        //multiplier = Random.Range(1, 10);
        textNumber = Grid.Instance.currentZ * multiplier;
        txt = GetComponentInChildren<TextMeshProUGUI>();
        txt.SetText("Width +" + textNumber.ToString());
    }
    private void Update()
    {
        textNumber = Grid.Instance.currentZ * multiplier;
        txt.SetText("Width +" + textNumber.ToString());
    }
}
