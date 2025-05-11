using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private DialogueManager dm;

    void Start()
    {
        dm = FindObjectOfType<DialogueManager>();
        
    }
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
            dm.ShowDialogue(line);
            yield return new WaitForSeconds(timeBetweenDialogues);
        }

        dm.HideDialogue();
        GameContext.isFinalBattle = true;
        SceneManager.LoadScene("BattleScene");
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && dm != null)
        {
            dm.HideDialogue();
        }
    }
}
