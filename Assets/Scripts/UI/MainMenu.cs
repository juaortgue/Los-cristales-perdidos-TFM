using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   

    public void LoadFirstScene()
    {
        GameContext.previousScene = SceneEnum.MainMenuScene;
        SceneManager.LoadScene(SceneEnum.TownScene.ToString());
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadControlsScene()
    {
        GameContext.previousScene = SceneEnum.MainMenuScene;
        SceneManager.LoadScene(SceneEnum.ControlsScene.ToString());
    }

    public void LoadMainMenuScene()
    {
        GameContext.previousScene = SceneEnum.ControlsScene;
        SceneManager.LoadScene(SceneEnum.MainMenuScene.ToString());
    }
    
    

}
