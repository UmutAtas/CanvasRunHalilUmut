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
    }
    private void Update()
    {
        textNumber = Grid.Instance.currentX * multiplier;
        if (textNumber > 0)
        {
            txt.SetText("Length +" + textNumber.ToString());
        }
        else if (textNumber < 0)
        {
            txt.SetText("Length " + textNumber.ToString());
        }
    }
}
