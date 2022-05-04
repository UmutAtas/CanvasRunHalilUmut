using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementandRotation : MonoBehaviour
{
    private SwerveInputSystem _swerveInputSystem;
    void Update()
    {
        Rotate();   
    }

    private void Rotate()
    {
        //for (int i = 0; i < Grid.Instance.currentX; i++)
        //{
        //    var orta = Grid.Instance.gridList[Grid.Instance.currentX / 2, 0];
        //    Grid.Instance.gridList[i, 0].transform
        //}
        if (_swerveInputSystem == null)
        {
            _swerveInputSystem = GetComponentInParent<SwerveInputSystem>();
        }
        if (_swerveInputSystem.XBasedCM != 0 && ((transform.eulerAngles.y < 15) || transform.eulerAngles.y > 345))
        {
            if (Mathf.Abs(transform.position.x) > 3.5f)
            {
                return;
            }
            var pos = _swerveInputSystem.XBasedCM;
            var sign = pos / Mathf.Abs(pos);
            transform.Rotate(0f,2f*sign,0f,Space.Self);    
        }
        else if (transform.rotation.y != 0)
        {
            Quaternion rot = new Quaternion(0f, 0f, 0f, 1f);
            transform.localRotation = Quaternion.Slerp(transform.localRotation , rot, 8f*Time.deltaTime);
        }
    }
}
