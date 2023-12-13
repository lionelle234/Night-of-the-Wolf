using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DirectorCutscene1 : MonoBehaviour
{
    [SerializeField] private Man man;



    public void ManMove()
    {
        man.movInput.x = 1;
    }

    public void ManStop()
    {
        man.movInput.x = 0;
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
