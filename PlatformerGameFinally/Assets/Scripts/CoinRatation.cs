using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRatation : MonoBehaviour
{
    
    float coinSpeed = 200f;

    void Start()
    {

    }

    void Update()
    {
        transform.Rotate(new Vector3(0f, 1f, 0f) * Time.deltaTime * coinSpeed);
    }
}
