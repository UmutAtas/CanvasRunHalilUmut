using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    
    void Update()
    {
        if (GameManager.Instance.dumpSection == false)
        {
            transform.position += Vector3.forward * (10 * Time.deltaTime);
        }
    }
}
