using UnityEngine;
using UnityEngine.UI;

public class DisplayUsername : MonoBehaviour
{
    public Text usernameText;

    private void Start()
    {
        usernameText.text = Username.username;
    }
}
