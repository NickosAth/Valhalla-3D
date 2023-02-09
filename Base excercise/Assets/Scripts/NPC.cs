using TMPro;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject dialogueCanvas;
    public GameObject otherCanvas;
    public float distanceToInteract = 2f;
    public GameObject player;
    public string dialogue;
    private bool isDialogueCanvasOpen = false;
    public TextMeshProUGUI dialogueText;

    private void Start()
    {
        dialogueCanvas.SetActive(false);
        otherCanvas.SetActive(false);
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance < distanceToInteract)
        {
            if (!isDialogueCanvasOpen )
            {
                otherCanvas.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.E) && !isDialogueCanvasOpen)
            {
                dialogueCanvas.SetActive(true);
                dialogueText.text = dialogue;
                isDialogueCanvasOpen = true;
                otherCanvas.SetActive(false);
            }
             if (distanceToInteract < distance)
            {
                otherCanvas.SetActive(false);
            };

           
        }
        else
        {
            if (dialogueCanvas.activeSelf && isDialogueCanvasOpen)
            {
                dialogueCanvas.SetActive(false);
                otherCanvas.SetActive(false);
                isDialogueCanvasOpen = false;
            }
        }
    }
}
