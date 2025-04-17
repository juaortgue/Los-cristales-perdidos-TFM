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
   

    void Start()
    {
        textToShow="Hello, I am an NPC!";
        
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
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            HiddeText();
        }
    }
}
