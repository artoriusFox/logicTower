using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public Transform LookAt;
    public float BoundX = 0.3f;
    public float BoundY = 0.15f;
    private void LateUpdate()
    {
        var delta = Vector3.zero;
        var deltaX = LookAt.position.x - transform.position.x;
        if (deltaX > BoundX || deltaX < -BoundX)
        {
            delta.x = (transform.position.x < LookAt.position.x ? deltaX - BoundX : deltaX + BoundX);
        }

        var deltaY = LookAt.position.y - transform.position.y;
    
        if (deltaY > BoundY || deltaY < -BoundY)
        {
            delta.y = (transform.position.y < LookAt.position.y ? deltaY - BoundY : deltaY + BoundY);
        }

        transform.position += new Vector3(delta.x, delta.y, 0);
    }
}