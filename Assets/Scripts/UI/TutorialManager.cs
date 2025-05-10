using System.Collections;
using UnityEngine;
public class TutorialManager : MonoBehaviour
{
    public string[] dialogues;

    public float timeBetweenDialogues = 1f;
    public GameObject player;
    private bool triggered = false;


    void Start()
    {


        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<Animator>().SetBool("isRunning", false);

        if (!triggered)
        {
            StartCoroutine(StartDialogueSequence());
        }

    }

    IEnumerator StartDialogueSequence()
    {
        triggered = true;


        foreach (string line in dialogues)
        {
            Debug.Log("bucle");
            DialogueManager.Instance.ShowDialogue(line);
            yield return new WaitForSeconds(timeBetweenDialogues);
        }

        DialogueManager.Instance.HideDialogue();
        player.GetComponent<PlayerMovement>().enabled = true;
    }


}
