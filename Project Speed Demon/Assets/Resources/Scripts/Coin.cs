using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Coin : MonoBehaviour
{
    [EventRef] public string coinSFX;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Destroy(gameObject);
            RuntimeManager.PlayOneShot(coinSFX);
        }
    }
}
