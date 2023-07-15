using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomMovement : MonoBehaviour
{
    [SerializeField] public  Animator TomAnimator;
    //[SerializeField] AudioClip TomHunt;
    public Transform player;
    public float moveSpeed = 1f;
    private void Update()
    {
        if (player.GetComponent<PlayerIsPlane>().IsPlane == true)
        {
            moveSpeed = 1f;
            transform.position = Vector3.Lerp(transform.position, player.transform.position, .8f * moveSpeed*Time.deltaTime);
            transform.LookAt(player.transform);
            //Vector3 direction= player.position - transform.position;
            //direction.Normalize();
            //transform.Translate(direction*moveSpeed*Time.deltaTime);
            TomAnimator.SetBool("Runn", true);
        }
        else
        {
            TomAnimator.SetBool("Runn", false);
            moveSpeed = 0;
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        GetComponent<PlayerMovement>()._health -= 30f;
    //        //moveSpeed = 0f;
    //        GameObject.Find("TomHunt Sound").GetComponent<AudioSource>().Play();
    //        TomAnimator.SetBool("Hunt", true);
    //    }
    //}
}
