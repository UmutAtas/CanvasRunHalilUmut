using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridHandler : Singleton<GridHandler>
{
    [SerializeField] private GameObject sphere;
    public int x;
    public int z;
    private GameObject[,] gridList;
    [SerializeField] private List<GameObject> oldGrid;

    private void Start()
    {
        GetGrid();
    }

    public void GetGrid()
    {
        gridList = new GameObject[x, z];
        oldGrid = new List<GameObject>();
        var offset = 1f;
        var gridX = x / 2;
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < z; j++)
            {
                GameObject obj = Instantiate(sphere, (transform.position + new Vector3(-gridX, 0f, 0f)) +
                                                     new Vector3(offset * i, transform.position.y, -offset * j),
                    Quaternion.identity,transform);
                oldGrid.Add(obj);
                gridList[i, j] = obj;
            }
            gridList[i, 0].GetComponent<SwerveInputSystem>().enabled = true;
            var rb =gridList[i, 0].AddComponent<Rigidbody>();
            rb.useGravity = false;
            rb.constraints = RigidbodyConstraints.FreezePosition;
            //gridList[i, 0].AddComponent<PlayerMovementandRotation>();
        }
    }

    public void GetNewGridX(int newNumber)
    {
        DeleteOldGrid();
        var area = (x * z) + newNumber;
        var newX = area / z;
        x = newX;
        GetGrid();
    }
    
    public void GetNewGridZ(int newNumber)
    {
        DeleteOldGrid();
        var area = (x * z) + newNumber;
        var newZ = area / x;
        z = newZ;
        GetGrid();
    }

    private void DeleteOldGrid()
    {
        for (int i = 0; i < oldGrid.Count; i++)
        {
            oldGrid[i].gameObject.SetActive(false);
        }
        oldGrid.Clear();
    }
}
