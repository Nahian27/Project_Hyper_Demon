using FMODUnity;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [EventRef] public string coinSFX;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            RuntimeManager.PlayOneShot(coinSFX);
            HUD_Script.score += 1;
        }
    }
}
