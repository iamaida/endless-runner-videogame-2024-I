using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelDistance : MonoBehaviour
{
    public GameObject disDisplay;
    public GameObject disEndDisplay;


    public int disRun;
    public bool addingDis = false;
    public static bool canAdding = true;
    public float disDelay = 0.50f;

    // Update is called once per frame
    void Update()
    {
        if (canAdding)
        {
            if (!addingDis)
            {
                addingDis = true;
                StartCoroutine(AddingDis());
            }

        }


    }

    IEnumerator AddingDis()
    {

        disRun += 1;
        disDisplay.GetComponent<Text>().text = "" + disRun;
        disEndDisplay.GetComponent<Text>().text = "" + disRun;
        yield return new WaitForSeconds(disDelay);
        addingDis = false;

    }
}
