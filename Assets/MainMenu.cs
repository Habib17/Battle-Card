using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button newGameButton;

    public Button loadButton;

    public Button quitGameButton;
    // Start is called before the first frame update

    public string newGameSceneName;
    public GameObject loadGameMenu;


    public void Awake(){
        newGameButton.onClick.AddListener(NewGame);
        loadButton.onClick.AddListener(OpenLoadGameMenu);
        quitGameButton.onClick.AddListener(ExitGame);
    }
    public void NewGame(){
        SceneManager.LoadScene(newGameSceneName);
    }

    public void OpenLoadGameMenu(){
        loadGameMenu.SetActive(true);
    }

    public void ExitGame(){
        Debug.Log("Keluar Dari Game");
        Application.Quit();
    }
}
