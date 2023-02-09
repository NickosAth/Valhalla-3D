using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MoveUsernameToGameScene : MonoBehaviour
{
   
    public InputField inputField;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void setPlayerName()
    {
        PlayerPrefs.SetString("PlayerName", inputField.text);
    }
}

