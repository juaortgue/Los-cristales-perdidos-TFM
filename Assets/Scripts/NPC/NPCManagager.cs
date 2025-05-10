using UnityEngine;

public class NPCManagager : MonoBehaviour
{
    public string textToShow;

    void Start()
    {
        
        if (string.IsNullOrEmpty(textToShow))
        {
            textToShow = "Hello, I am an NPC!";
        }
    }

   

     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DialogueManager.Instance.ShowDialogue(textToShow);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DialogueManager.Instance.HideDialogue();
        }
    }
}