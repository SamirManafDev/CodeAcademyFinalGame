using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoucerDoMove : MonoBehaviour
{
    [SerializeField] Transform endTransform;
    [SerializeField] AudioClip Bouncer;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bouncer")
        {
            GameObject.Find("Bouncer Sound").GetComponent<AudioSource>().Play();
            transform.DOMove(endTransform.position, 1f);
            transform.DOJump(endTransform.position, 3f, 1, 1f);
        }
    }
}
