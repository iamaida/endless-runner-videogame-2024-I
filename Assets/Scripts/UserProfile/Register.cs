//created by gregtchen: https://github.com/gregtchen/Unity-User-System/blob/master/Register.cs
//modified by Aida Mina at 17-04-2024
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Register : MonoBehaviour
{

    public InputField usernameInput;
    public InputField passwordInput;
    public Button signUpButton;
    public Button logInButton;
    public static string username;
    ArrayList credentials;

    // Start is called before the first frame update
    void Start()
    {
        signUpButton.onClick.AddListener(saveCredentials);
        logInButton.onClick.AddListener(login);

        if (File.Exists(Application.dataPath + "/Scripts/UserProfile/dummyuserDB.txt"))
        {
            credentials = new ArrayList(File.ReadAllLines(Application.dataPath + "/Scripts/UserProfile/dummyuserDB.txt"));
        }
        else
        {
            File.WriteAllText(Application.dataPath + "/Scripts/UserProfile/dummyuserDB.txt", "");
        }

    }

    void login()
    {
        bool isExists = false;

        credentials = new ArrayList(File.ReadAllLines(Application.dataPath + "/Scripts/UserProfile/dummyuserDB.txt"));

        foreach (var i in credentials)
        {
            string line = i.ToString();
            //Debug.Log(line);
            //Debug.Log(line.Substring(11));
            //substring 0-indexof(:) - indexof(:)+1 - i.length-1
            if (i.ToString().Substring(0, i.ToString().IndexOf(":")).Equals(usernameInput.text) &&
                i.ToString().Substring(i.ToString().IndexOf(":") + 1).Equals(passwordInput.text))
            {
                isExists = true;
                break;
            }
        }

        if (isExists)
        {
            Debug.Log($"Logging in '{usernameInput.text}'");
            username = usernameInput.text;
            loadMainMenuScene();
        }
        else
        {
            Debug.Log("Wrong credentials!");
        }
    }

    void loadMainMenuScene()
    {
        SceneManager.LoadScene(0);
    }


    void saveCredentials()
    {
        bool isExists = false;

        credentials = new ArrayList(File.ReadAllLines(Application.dataPath + "/Scripts/UserProfile/dummyuserDB.txt"));
        foreach (var i in credentials)
        {
            if (i.ToString().Contains(usernameInput.text))
            {
                isExists = true;
                break;
            }
        }

        if (isExists)
        {
            Debug.Log($"Username '{usernameInput.text}' already exists");
        }
        else
        {
            credentials.Add(usernameInput.text + ":" + passwordInput.text);
            File.WriteAllLines(Application.dataPath + "/Scripts/UserProfile/dummyuserDB.txt", (String[])credentials.ToArray(typeof(string)));
            Debug.Log("Account Registered");
        }
    }


}