using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject textPanel;
    public TextMeshProUGUI npcText;

    
    public void ShowDialogue(string text)
    {
        textPanel.SetActive(true);
        npcText.text = text;
    }

    public void HideDialogue()
    {
        textPanel.SetActive(false);
    }
}
