using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Grid : Singleton<Grid>
{
    public GameObject[,] gridList;
    public int startX = 2;
    public int startZ = 10;
    public int remainder = 0;
    public int plusX;
    public int plusZ;
    public int currentX;
    public int currentZ;
    private int newSpawnx = 0;
    private float offsetX = 0.5f;
    private float offsetZ = 0.5f;
    [SerializeField] private int zSpawnOffset = -20;
    [SerializeField] private Transform frontRowParent;
    private float firstRowZLocalPos = 0f;

    private void Awake()
    {
        gridList = new GameObject[1000, 1000];
        currentX = startX;
        currentZ = startZ;
    }
    private void Start()
    {
        FirstGrid();
    }
    private void FirstGrid()
    {
        var offset = 0.5f;
        var gridX = startX / 2;
        for (int i = 0; i < startX; i++)
        {
            for (int j = 0; j < startZ; j++)
            {
                Vector3 gridPos = (transform.position + new Vector3(-gridX + 0.5f, 0f, 0f)) +
                                  new Vector3(offset * i, transform.position.y, -offset * j);
                SetGrid(i,j,gridPos);
            }
        }
        currentX = startX;
        currentZ = startZ;
    }
    private void SetGrid(int x, int z, Vector3 pos)
    {
        gridList[x, z] = ObjectPool.Instance.GetPooledObject(0);
        gridList[x, z].transform.SetParent(transform);
        gridList[x, z].transform.position = pos;
        gridList[x, 0].transform.SetParent(frontRowParent);
        var firstRow = gridList[x, 0].transform.localPosition;
        gridList[x, 0].transform.localPosition = new Vector3(firstRow.x, firstRow.y, 0f);
    }
    public void GetNewWidth(int number)
    {
        plusX = Mathf.Abs(number);
        if (number > 0)
        {
            for (int i = currentX; i < currentX + plusX; i++)
            {
                for (int j = 0; j < currentZ; j++)
                {
                    Vector3 gridPos = gridList[newSpawnx, j].transform.position;
                    SetGrid(i,j,gridPos);
                    if (newSpawnx == 0)
                    {
                        var pos =gridList[i, j].transform.position;
                        gridList[i, j].transform.DOLocalMove(
                            new Vector3(pos.x - offsetX, pos.y, pos.z) - transform.position,
                            0.5f);
                    }
                    else if (newSpawnx != 0)
                    {
                        var pos =gridList[i, j].transform.position;
                        gridList[i, j].transform.DOLocalMove(
                            new Vector3(pos.x + offsetX, pos.y, pos.z) - transform.position,
                            0.5f);
                    }
                }
                switch (newSpawnx)
                {
                    case 0 :
                        newSpawnx += 1;
                        break;
                    case 1 :
                        newSpawnx = 0;
                        offsetX += 0.5f;
                        break;
                }
            }
        }
        else if (number < 0)
        {
            for (int i = currentX; i < currentX + plusX; i++)
            {
                for (int j = 0; j < currentZ; j++)
                {
                    var objectToPool = gridList[i + number, j];
                    ObjectPool.Instance.SetPooledObject(objectToPool, 0);
                }
            }
        }
        currentX += number;
    }
    public void GetNewLength(int number)
    {
        plusZ = Mathf.Abs(number);
        if (number > 0)
        {
            for (int i = 0; i < currentX; i++)
            {
                offsetZ = 0.5f;
                for (int j = currentZ; j < currentZ + plusZ; j++)
                {
                    Vector3 gridPos = gridList[i, 0].transform.position + new Vector3(0f,0f,-zSpawnOffset-offsetZ);
                    var transformToFollow = gridList[i, currentZ - 1].transform;
                    SetGrid(i,j,gridPos);
                    var pos = transformToFollow.position;
                    gridList[i, j].transform.DOLocalMove(new Vector3(pos.x,pos.y,pos.z-offsetZ) - transform.position, 1f);
                    offsetZ += 0.5f;
                }
            }
        }
        else if (number < 0)
        {
            for (int i = 0; i < currentX; i++)
            {
                for (int j = currentZ; j < currentZ + plusZ; j++)
                {
                    var objectToPool = gridList[i, j + number];
                    ObjectPool.Instance.SetPooledObject(objectToPool, 0);
                }
            }
        }
        currentZ += number;
    }
    private void MoveGrid()
    {
        if (GameManager.Instance.dumpSection == false)
        {
            var offset = 0.5f - 0.30935f;
            for (int i = 0; i < currentX; i++)
            {
                for (int j = 1; j < currentZ; j++)
                {
                    Vector3 pos = gridList[i, j-1].transform.position;
                    gridList[i, j].transform.DOMove(pos + (Vector3.back * offset), 0.1f);
                    gridList[i, 0].transform.rotation = Quaternion.identity;
                }
            }
        }
    }
    private void Update()
    {
        MoveGrid();
    }
}
