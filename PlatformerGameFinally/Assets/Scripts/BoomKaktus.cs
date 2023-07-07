using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ToonyColorsPro.ShaderGenerator.Enums;
using static UnityEngine.ParticleSystem;

public class BoomKaktus : MonoBehaviour
{
    [SerializeField] GameObject _kaktus;
    [SerializeField] ParticleSystem _particle;
    [SerializeField] ParticleSystem _particlee;
    [SerializeField] AudioClip boomSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Box")
        {
            GameObject.Find("Boom Sound").GetComponent<AudioSource>().Play();
            _particle.Play();
            _particlee.Play();
            _kaktus.SetActive(false);

        }

    }

}
