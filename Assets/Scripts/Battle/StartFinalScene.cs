using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class StartFinalScene : MonoBehaviour
{
    public string[] dialogues = new string[]
    {
        "So... you've come at last.",
        "This village, these people... they are nothing but dust in the path of power.",
        "The Dark Crystal is awakened. Its energy pulses with ancient wrath.",
        "Your efforts are noble, but futile.",
        "Now, witness true magic... and PERISH!"
    };

    public GameObject player;


    public float timeBetweenDialogues = 10f;

    private bool triggered = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !triggered)
        {
            triggered = true;
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<Animator>().SetBool("isRunning", false);
            StartCoroutine(StartDialogueSequence());
        }
    }

    IEnumerator StartDialogueSequence()
    {
        foreach (string line in dialogues)
        {
            DialogueManager.Instance.ShowDialogue(line);
            yield return new WaitForSeconds(timeBetweenDialogues);
        }

        DialogueManager.Instance.HideDialogue();
        BattleContext.isFinalBattle = true;
        SceneManager.LoadScene("BattleScene");
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DialogueManager.Instance.HideDialogue();
        }
    }
}
