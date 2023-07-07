using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class PlayerIsPlane : MonoBehaviour
{
    [SerializeField] LayerMask plane;


    public bool IsPlane = false;

    private void Update()
    {
        IsPlaneOn();
    }

    public void IsPlaneOn()
    {
        if (Physics.Raycast(transform.position, UnityEngine.Vector3.down, 1f,plane))
        {
            IsPlane = true;
        }
        else
        {
            IsPlane = false;
        }
    }
}
