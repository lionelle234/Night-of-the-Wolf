using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DirectorControllerMain : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject tutorialScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Forest (Man)");
    }
    public void TutorialON()
    {   
        mainMenu.SetActive(false);
        tutorialScreen.SetActive(true);
    }

    public void TutorialOFF()
    {   
        mainMenu.SetActive(true);
        tutorialScreen.SetActive(false);
    }

    public void Return()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
