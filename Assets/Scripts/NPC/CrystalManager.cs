using UnityEngine;
using UnityEngine.SceneManagement;
public class CrystalManager : MonoBehaviour
{
    public string textToShow;
    private DialogueManager dm;
    void Start()
    {

        if (string.IsNullOrEmpty(textToShow))
        {
            textToShow = "Your level is too low. Reach level 5 to pass.!";
        }
        dm = FindObjectOfType<DialogueManager>();
    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && dm != null)
        {
            if (PlayerStats.Instance.getLevel() < 5)
            {
                dm.ShowDialogue(textToShow);
            }
            else
            {
                GameContext.previousScene = SceneEnum.TownScene;
                dm.HideDialogue();
                SceneManager.LoadScene("FinalBattleScene");
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && dm != null)
        {
            dm.HideDialogue();
        }
    }
}
