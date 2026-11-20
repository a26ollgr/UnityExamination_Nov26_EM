using UnityEditor;
using UnityEngine;
[System.Serializable]
public class DialogueSystem : MonoBehaviour
{
    [SerializeField] private string[] lines;
    [SerializeField] private TMPro.TextMeshProUGUI text;
    [SerializeField] private GameObject dialogueBox;

    private bool dialogueActive = false;

    private GameObject player;

    private int idx = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Dialogue()
    {
        Debug.Log("dialogue");

        if (player.GetComponentInChildren<PlayerInteractions>().hasBall)
        {
            lines[2] = "Greg: I see you have a ball. Nice.";
        }
        else
        {
            lines[2] = "Greg: Unfortunate. No ball.";
        }
        
        if (!dialogueActive)
        {
            dialogueActive = true;
            dialogueBox.SetActive(true);
            player.GetComponent<PlayerMovement>().movementActive = false;
            DisplayNextLine();
        } else
        {
            DisplayNextLine();
        }
    }

    public void DisplayNextLine()
    {
        if (idx < lines.Length)
        {
            text.text = lines[idx];
        }
        idx++;
        if (idx > lines.Length)
        {
            dialogueBox.SetActive(false);
            player.GetComponent<PlayerMovement>().movementActive = true;
            dialogueActive = false;
            text.text = "";
            idx = 0;
        }
    }

}
