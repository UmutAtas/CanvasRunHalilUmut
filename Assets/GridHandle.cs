using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridHandle : Singleton<GridHandle>
{
   public int x;
   public int z;
   public GameObject[,] gridList;
   private int newRemainder = 0;
   private int childCount = 0;

   private void Start()
   {
       GetGrid(0);
   }

   private void GetGrid(int remainder)
   {
       gridList = new GameObject[x, z];
       newRemainder += remainder;
       if (newRemainder == 0 && remainder != 0)
       {
           x -= 1;
       }
       for (int i = 1; i < transform.childCount; i++)
       {
           ObjectPool.Instance.SetPooledObject(transform.GetChild(i).gameObject,0);
       }
       //Grid(x,z);
   }

   public void Grid(int X , int Z,int plusx)
   {
       var offset = 1f;
       var gridX = x / 2;
       for (int i = 0; i < x; i++)
       {
           for (int j = 0; j < z; j++)
           {
               Vector3 gridPos = (transform.position + new Vector3(-gridX, 0f, 0f)) +
                                 new Vector3(offset * i, transform.position.y, -offset * j);
               gridList[i, j] = ObjectPool.Instance.GetPooledObject(0);
               gridList[i, j].transform.SetParent(transform);
               gridList[i, j].transform.position = gridPos;
           }
       }
       //bu methoda data ekle, + - sayılar bunları i,j ye + olarak ekle // dışarda forla objeleri oluştur ve onları burada ekle.
   }
   
   public void GetNewGridXPositive(int newNumber)
   {
       //var newX = newNumber / z;
       //var remainder = newNumber % z;
       //if (remainder > 0 && newRemainder == 0)
       //{
       //    x += 1;
       //}
       //x += newX;
       //GetGrid(remainder);
       for (int i = 0; i < z; i++)
       {
           //1 sıra oluştur
           //gridlist[x+1,z]
       }
   }
   public void GetNewGridXNegative(int newNumber)
   {
       var newX = newNumber / z;
       var remainder = newNumber % z;
       x += newX;
       GetGrid(remainder);
   }
   
   public void GetNewGridZ(int newNumber)
   {
       var area = (x * z) + newNumber;
       var newZ = area / x;
       z = newZ;
       //GetGrid();
       //if (newRemainder > 0 && i == x - 1)
       //{
       //    for (int k = z -1; k >= newRemainder; k--)
       //    {
       //        ObjectPool.Instance.SetPooledObject(gridList[i, k], 0);
       //    }
       //}
   }
}