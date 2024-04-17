using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor;
using UnityEngine;

public class CollectSapphire : MonoBehaviour
{
    public AudioSource sapphireFX;
    private void OnTriggerEnter(Collider other)
    {
        sapphireFX.Play();
        CollactableControl.sapphireCount += 1;
        this.gameObject.SetActive(false);

    }
}
