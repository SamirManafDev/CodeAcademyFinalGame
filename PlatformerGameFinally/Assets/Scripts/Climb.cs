using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Climb : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] private Transform endTransform;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.DOMove(endTransform.position, 4f);

            animator.SetBool("Climb", true);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("Climb", false);
    }
}
