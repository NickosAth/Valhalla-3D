using UnityEngine;
using UnityEngine.UI;

public class Username : MonoBehaviour
{
  
    public static string username;
    public InputField inputField;
 
    public void SaveUsername()
    {
        username = inputField.text;
    }
}

