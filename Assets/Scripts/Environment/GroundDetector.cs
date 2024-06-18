using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GroundDetector : MonoBehaviour
{
    public GameObject thePlayer;

    private void OnTriggerEnter(Collider other)
    {

        //this.gameObject.GetComponent<BoxCollider>().enabled = false;
        PlayerMove.isGrounded = true;
        Debug.Log("Player Get Ground");





    }
}
