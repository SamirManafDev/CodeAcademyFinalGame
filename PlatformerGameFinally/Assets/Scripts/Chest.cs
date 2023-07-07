using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] Animator animatorChest;
    [SerializeField] GameObject gameWin;
    [SerializeField] AudioClip openChest;
    [SerializeField] ParticleSystem coinParticle;
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.layer==LayerMask.NameToLayer("Player"))
        {
            animatorChest.SetBool("Open", true);
            GameObject.Find("Chest Sound").GetComponent<AudioSource>().Play();
            FindAnyObjectByType<PlayerMovement>().animator.SetBool("Happy", true);
            StartCoroutine(CoinParticle());
            StartCoroutine(GameWin());
        }
        else
        {
            animatorChest.SetBool("Open",false);
            FindAnyObjectByType<PlayerMovement>().animator.SetBool("Happy", false);
        }
    }
    IEnumerator GameWin()
    {
        yield return new WaitForSeconds(2f);
        gameWin.SetActive(true);
        UIManager.Instance.OpenRestartPanel();
    }
    IEnumerator CoinParticle()
    {
        yield return new WaitForSeconds(1f);
        coinParticle.Play();
    }
}
