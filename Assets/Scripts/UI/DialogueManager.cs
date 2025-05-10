using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
    public GameObject textPanel;
    public TextMeshProUGUI npcText;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
   

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
