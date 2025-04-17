using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPCManagager : MonoBehaviour
{
    public GameObject textPanel;
    public GameObject statsPanel;
    public string textToShow;
    public TextMeshProUGUI npcText;
    private bool isInArea;
   

    void Start()
    {
        isInArea=false;
        if (textToShow == null || textToShow == "")
        {
            textToShow = "Hello, I am a NPC!";
        }
       
        
    }

    void Update()
    {
        if (isInArea && !statsPanel.activeSelf)
        {
            ShowText();
        }else{
            HiddeText();
        }
        
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
            isInArea = true;
        }
    }


    void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            isInArea = false;
        }
    }
}
