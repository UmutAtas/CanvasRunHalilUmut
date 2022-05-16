using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEditorInternal;

public class cameramove : MonoBehaviour
{
    public Transform pTransform;
    private Vector3 offset;
    public CinemachineVirtualCamera cmVirtual;
    private Cinemachine3rdPersonFollow transposer;
    private Vector3 firstOffset;
    private Vector3 lastOffset;
    void Start()
    {
        offset = new Vector3(0, 12f, -13.5f);
        transposer = cmVirtual.GetCinemachineComponent<Cinemachine3rdPersonFollow>();
        transposer.ShoulderOffset = new Vector3(0f, 10f, -10f);
        firstOffset = new Vector3(0f, 11f, -12f);
        lastOffset = new Vector3(0f, 19.70f, -16.78f);
    }
    
   void Update()
   {
       GetNewCameraPos();
       if (GameManager.Instance.levelEnd)
       {
           transposer.ShoulderOffset = Vector3.Lerp(transposer.ShoulderOffset, lastOffset, 4f * Time.deltaTime);
       }
   }

   private void GetNewCameraPos()
   {
       if (Grid.Instance.currentZ > 13)
           transposer.ShoulderOffset = Vector3.Lerp(transposer.ShoulderOffset, offset, 0.8f * Time.deltaTime);
       else if(Grid.Instance.currentZ < 13 && Grid.Instance.currentZ > 8)
           transposer.ShoulderOffset = Vector3.Lerp(transposer.ShoulderOffset, firstOffset, 0.8f * Time.deltaTime);
       else if (GameManager.Instance.afterRamp)
           transposer.ShoulderOffset = Vector3.Lerp(transposer.ShoulderOffset, offset, 0.8f * Time.deltaTime);
       else if (GameManager.Instance.afterDump)
           transposer.ShoulderOffset = Vector3.Lerp(transposer.ShoulderOffset, new Vector3(0f, 10f, -10f), 0.8f * Time.deltaTime);
   }
}
