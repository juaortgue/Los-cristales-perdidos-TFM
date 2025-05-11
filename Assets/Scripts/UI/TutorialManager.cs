using System.Collections;
using UnityEngine;
public class TutorialManager : MonoBehaviour
{
    public string[] dialogues;
    public float timeBetweenDialogues = 1f;
    public GameObject player;
    
    private bool triggered = false;
    private DialogueManager dm;

    void Start()
    {
        dm = FindObjectOfType<DialogueManager>();
        if (GameContext.isTutorial && dm!=null)
        {
            
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<Animator>().SetBool("isRunning", false);

            if (!triggered)
            {
                StartCoroutine(StartDialogueSequence());
            }
        }

    }

    IEnumerator StartDialogueSequence()
    {
        triggered = true;
        GameContext.isTutorial = false;

        foreach (string line in dialogues)
        {
            dm.ShowDialogue(line);
            yield return new WaitForSeconds(timeBetweenDialogues);
        }

        dm.HideDialogue();
        player.GetComponent<PlayerMovement>().enabled = true;
    }


}
