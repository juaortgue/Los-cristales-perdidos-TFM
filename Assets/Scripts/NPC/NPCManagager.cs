using UnityEngine;

public class NPCManagager : MonoBehaviour
{
    public string textToShow;
    
    private DialogueManager dm;

    void Start()
    {
        dm = FindObjectOfType<DialogueManager>();
        if (string.IsNullOrEmpty(textToShow))
        {
            textToShow = "Hello, I am an NPC!";
        }
    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && dm != null)
        {
            GameContext.isDialogueOpen = true;
            dm.ShowDialogue(textToShow);
        }

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && dm != null)
        {
            GameContext.isDialogueOpen = false;
            dm.HideDialogue();
        }
    }
}