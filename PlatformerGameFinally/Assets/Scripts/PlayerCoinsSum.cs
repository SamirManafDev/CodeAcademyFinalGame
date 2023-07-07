using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoinsSum : MonoBehaviour
{
    [SerializeField] AudioClip coinSound;

    private float _coins;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            GameObject.Find("Coin Sound").GetComponent<AudioSource>().Play();
            Destroy(collision.gameObject);
            _coins++;
            UIManager.Instance.UpdateCoinValue(_coins);
            Debug.Log(_coins);
        }
    }


}
