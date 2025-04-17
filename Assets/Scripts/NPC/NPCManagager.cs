using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPCManagager : MonoBehaviour
{
    public GameObject textPanel;
    public string textToShow;
    public TextMeshProUGUI npcText;
    private bool isPlayerInRange;

    void Start()
    {
        textToShow="Hello, I am an NPC!";
        isPlayerInRange=false;
        
    }

    void ShowText()
    {
        textPanel.SetActive(true);
        npcText.text = textToShow;
    }
    void HiddeText()
    {
        textPanel.SetActive(false);
    }

    


    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            ShowText();
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            HiddeText();
            isPlayerInRange = false;
        }
    }
}
