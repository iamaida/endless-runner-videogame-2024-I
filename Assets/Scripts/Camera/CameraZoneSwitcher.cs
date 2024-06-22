using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using Cinemachine;

public class CameraZoneSwitcher : MonoBehaviour
{
    public string triggerTag;

    public CinemachineVirtualCamera primaryCamera;
    // Start is called before the first frame update
    public CinemachineVirtualCamera[] virtualCameras;
    //private void Start()
    //{
    //  SwitchToCamera(primaryCamera);

    //}
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entrada: " + triggerTag);
        primaryCamera.enabled = false;
        virtualCameras[0].enabled = true;
        PlayerMove.canMove = true;
        //Debug.Log("Otro Trigger tag: " + other);
        //if (other.CompareTag(triggerTag))
        // {
        //  CinemachineVirtualCamera targetCamera = other.GetComponentInChildren<CinemachineVirtualCamera>();
        SwitchToCamera(virtualCameras[0]);
        // }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Salida Camera Zone");
        virtualCameras[0].enabled = false;
        primaryCamera.enabled = true;
        PlayerMove.canMove = true;

        // if (other.CompareTag(triggerTag))
        //{
        //CinemachineVirtualCamera targetCamera = other.GetComponentInChildren<CinemachineVirtualCamera>();
        //SwitchToCamera(primaryCamera);
        //}
    }

    // Update is called once per frame
    private void SwitchToCamera(CinemachineVirtualCamera targetCamera)
    {
        targetCamera.enabled = true;
        PlayerMove.canMove = true;
        // foreach (CinemachineVirtualCamera camera in virtualCameras)
        //{
        //  camera.enabled = camera == targetCamera;

        //}
    }
}
