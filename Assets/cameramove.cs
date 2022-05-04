using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cameramove : MonoBehaviour
{
    public Transform pTransform;
    private Vector3 offset;
    public CinemachineVirtualCamera cmVirtual;
    [SerializeField] private Vector3 newFollowOffset;
    void Start()
    {
        //offset  = transform.position - pTransform.position;
        var transposer = cmVirtual.GetCinemachineComponent<Cinemachine3rdPersonFollow>();
        //transposer.ShoulderOffset = newFollowOffset;
    }

   // // Update is called once per frame
   // void Update()
   // {
   //     transform.position = new Vector3(0f, transform.position.y,
   //         Mathf.Lerp(transform.position.z, pTransform.position.z + offset.z, 10f * Time.deltaTime));
   // }
}
