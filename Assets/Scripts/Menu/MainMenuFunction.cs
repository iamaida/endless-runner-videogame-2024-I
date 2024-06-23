#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuFunction : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject userNameDisplay;
    public Button playButton;
    public Button quitButton;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        userNameDisplay.GetComponent<Text>().text = Register.username;
        playButton.onClick.AddListener(GotoPlayGameScene);
        quitButton.onClick.AddListener(GoToLoginScene);

    }

    void GotoPlayGameScene()
    {
        SceneManager.LoadScene(1);
    }
    public void GoToLoginScene()
    {
        SceneManager.LoadScene(0);

    }
}
#endif