using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class GetGrid : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            other.gameObject.layer = 9;
            if (other.TryGetComponent(out WidthGateHandler width))
            {
                if (width.textNumber < 0)
                {
                    Grid.Instance.GetNewWidth(width.multiplier);
                }
                else if (width.textNumber > 0)
                {
                    Grid.Instance.GetNewWidth(width.multiplier);
                }
            }

            if (other.TryGetComponent(out LengthGateHandler length))
            {
                if (length.textNumber < 0)
                {
                    Grid.Instance.GetNewLength(length.multiplier);
                }
                else if (length.textNumber > 0)
                {
                    Grid.Instance.GetNewLength(length.multiplier);
                }
            }
        }
    }
}
