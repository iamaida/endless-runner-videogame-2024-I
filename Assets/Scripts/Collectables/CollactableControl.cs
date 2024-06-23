#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollactableControl : MonoBehaviour
{
    public static int sapphireCount;
    public GameObject sapphireCountDisplay;
    public GameObject sapphireEndDisplay;
    // Update is called once per frame
    void Update()
    {
        sapphireCountDisplay.GetComponent<Text>().text = "" + sapphireCount;
        sapphireEndDisplay.GetComponent<Text>().text = "" + sapphireCount;
    }
}
#endif