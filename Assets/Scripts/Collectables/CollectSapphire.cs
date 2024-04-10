using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectSapphire : MonoBehaviour
{
    public AudioSource sapphireFX;
    private void OnTriggerEnter(Collider other)
    {
        sapphireFX.Play();
        this.gameObject.SetActive(false);

    }
}
