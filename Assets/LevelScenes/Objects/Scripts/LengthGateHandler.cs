using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

public class LengthGateHandler : MonoBehaviour
{
    public int textNumber;
    public int multiplier;
    private TextMeshProUGUI txt;
    private void Start()
    {
        GetGateLength();
    }
    private void GetGateLength()
    {
        //multiplier = Random.Range(1, 10);
        textNumber = Grid.Instance.currentX * multiplier;
        txt = GetComponentInChildren<TextMeshProUGUI>();
        txt.SetText("Length +" + textNumber.ToString());
    }
    private void Update()
    {
        textNumber = Grid.Instance.currentX * multiplier;
        txt.SetText("Length +" + textNumber.ToString());
    }
}
