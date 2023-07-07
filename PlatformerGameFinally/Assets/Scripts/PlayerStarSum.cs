using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStarSum : MonoBehaviour
{
    [SerializeField] AudioClip StarSound;
    private float _star;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Star")
        {
            GameObject.Find("Star Sound").GetComponent<AudioSource>().Play();
            Destroy(collision.gameObject);
            _star++;
            UIManager.Instance.UpdateStarValue(_star);
        }
    }
}
