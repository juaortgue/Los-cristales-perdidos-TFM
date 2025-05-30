using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalSceneManager : MonoBehaviour
{
    public string[] dialogues = new string[]
    {
        "So... you've come at last.",
        "This village, these people... they are nothing but dust in the path of power.",
        "The Dark Crystal is awakened. Its energy pulses with ancient wrath.",
        "Your efforts are noble, but futile.",
        "Now, witness true magic... and PERISH!"
    };

    public string[] postBattleDialogues = new string[]
    {
        "Impossible... How could I lose to you?",
        "But you... you fought for others. For hope.",
        "Maybe there's still time... to make things right.",
        "Take the crystal. Use it wisely...",
    };

    public GameObject player;


    public float timeBetweenDialogues = 4f;

    private bool triggered = false;
    private DialogueManager dm;
    private bool isPostGame = false;

    void Start()
    {
        dm = FindObjectOfType<DialogueManager>();
        isPostGame = GameContext.previousScene.Equals(SceneEnum.BattleScene);

        if (isPostGame)
        {
            GameContext.previousScene = SceneEnum.FinalBattleScene;
            GameObject finalSceneManager = GameObject.Find("StartFinalSceneManager");
            if (finalSceneManager != null)
            {
                finalSceneManager.SetActive(false);
            }
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<Animator>().SetBool("isRunning", false);
            StartCoroutine(StartPostGameDialogueSequence());
        }


    }

    IEnumerator StartPostGameDialogueSequence()
    {
        GameContext.isDialogueOpen = true;
        foreach (string line in postBattleDialogues)
        {
            dm.ShowDialogue(line);
            yield return new WaitForSeconds(timeBetweenDialogues);
        }
        if (PlayerStats.Instance != null)
        {
            PlayerStats.Instance.ResetStats();
            Destroy(PlayerStats.Instance.gameObject);
        }
        dm.HideDialogue();
        GameContext.isFinalBattle = false;
        yield return new WaitForSeconds(2f);
        GameContext.isDialogueOpen = false;
        SceneManager.LoadScene("MainMenuScene");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !triggered && !isPostGame)
        {   
            triggered = true;
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<Animator>().SetBool("isRunning", false);
            PlayerStats.Instance.setPlayerPosition(player.transform.position);
            GameContext.previousScene = SceneEnum.FinalBattleScene;
            StartCoroutine(StartDialogueSequence());
        }
    }

    IEnumerator StartDialogueSequence()
    {
        GameContext.isDialogueOpen = true;
        foreach (string line in dialogues)
        {
            dm.ShowDialogue(line);
            yield return new WaitForSeconds(timeBetweenDialogues);
        }

        dm.HideDialogue();
        GameContext.isFinalBattle = true;
        GameContext.isDialogueOpen = false;
        SceneManager.LoadScene("BattleScene");
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && dm != null)
        {
            GameContext.isDialogueOpen = false;
            dm.HideDialogue();
        }
    }
}
