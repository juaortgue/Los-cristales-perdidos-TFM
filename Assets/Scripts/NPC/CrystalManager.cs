using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CrystalManager : MonoBehaviour
{
    public string textToShow;

    void Start()
    {

        if (string.IsNullOrEmpty(textToShow))
        {
            textToShow = "Your level is too low. Reach level 5 to pass.!";
        }
    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (PlayerStats.Instance.getLevel() < 5)
            {
                DialogueManager.Instance.ShowDialogue(textToShow);
            }
            else
            {
                DialogueManager.Instance.HideDialogue();
                SceneManager.LoadScene("FinalBattleScene");
            }
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
