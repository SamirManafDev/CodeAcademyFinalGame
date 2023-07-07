using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKey : MonoBehaviour
{
    [SerializeField] public GameObject key;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Key")
        {
            collision.gameObject.SetActive(false);
            key.SetActive(true);
            gameObject.layer = LayerMask.NameToLayer("Player");
        }
    }

}
