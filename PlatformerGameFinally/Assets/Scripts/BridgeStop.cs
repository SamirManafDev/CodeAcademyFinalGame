using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeStop : MonoBehaviour
{
    [SerializeField] Transform start;
    [SerializeField] ParticleSystem Particle;
    [SerializeField] GameObject Body;
    [SerializeField] AudioClip boomJoy;

    BridgeMove bridgeMove;
    private void Start()
    {
        bridgeMove=FindAnyObjectByType<BridgeMove>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject.Find("Boom JoySound").GetComponent<AudioSource>().Play();
            Particle.Play();
            Body.transform.DORotate(new Vector3(0, 30f, 0), 1f);
            bridgeMove.endTween.Kill();
            //bridgeMove.transform.position=new Vector3(0.138300002f, 0.246800005f, -1.79059994f);
        }
    }
}
