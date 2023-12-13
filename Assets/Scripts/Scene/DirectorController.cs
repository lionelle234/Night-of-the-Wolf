using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Cinemachine.DocumentationSortingAttribute;

public class DirectorController : MonoBehaviour
{   
    public static DirectorController instance;
    [SerializeField] private GameObject blackScreen;
    [SerializeField] private GameObject continueMenu;
    [SerializeField] private Wolf wolf;
    [SerializeField] private GameObject barrier;
    [SerializeField] private GameObject barrier2;
    [SerializeField] private GameObject cam;
    [SerializeField] private CinemachineVirtualCamera camm;
    [SerializeField] private GameObject cam2;
    [SerializeField] private CinemachineVirtualCamera camm2;
    [SerializeField] private Man man;
    [SerializeField] private Boss boss;
    [SerializeField] private GameObject camSwap;
    private GameObject[] enemies;
    private GameObject[] items;
    private GameObject[] wateroos;
    private MovingPlatform[] platForms;
    private ResetPosition[] objeCts;
    [HideInInspector] public Vector2 respawnPos;
    private bool checkPointActive;
    public float waterSpeed;

    private void Awake()
    {
        instance = this;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        items = GameObject.FindGameObjectsWithTag("Item");
        wateroos = GameObject.FindGameObjectsWithTag("Water");
        platForms = FindObjectsByType<MovingPlatform>(FindObjectsSortMode.None);
        objeCts = FindObjectsByType<ResetPosition>(FindObjectsSortMode.None);
    }
    // Start is called before the first frame update
    void Start()
    {
        waterSpeed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void GameOver()
    {   
        blackScreen.SetActive(true);
        ResetEnemies();
        man.inventory.RemoveAllItems();
        AudioController.instance.BGMOff();
 
    }

    public void GameOverWolf()
    {
        blackScreen.SetActive(true);
        ResetEnemies();
        if (boss.onActivated)
        {
            boss.Inactive();
        }

        AudioController.instance.BGMOff();
    }

    public void Continue()
    {
        continueMenu.SetActive(true);
    }

    public void ContinueYes()
    {
        

        if (checkPointActive)
        {   if (man != null)
            {
                man.Respawn();

                ResetWateroos();
            }
            if (wolf != null)
            {
                wolf.Respawn();
            }
            if (boss != null && boss.onActivated)
            {
                boss.Active();
            }

            StartEnemies();
            ResetItems();
            ResetObjects();

            StopPlatforms();
            blackScreen.SetActive(false);
            continueMenu.SetActive(false);
            AudioController.instance.BGMOn();


        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


    }

    public void ContinueNo()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ResetEnemies()
    {
        foreach (GameObject enemy in enemies)
        {
            if (enemy.GetComponent<Enemy>().gameObject.activeSelf == false)
            {
                enemy.GetComponent<Enemy>().gameObject.SetActive(true);

                enemy.GetComponent<Enemy>().ResetPosition();
            }
            else
            {
                if (enemy.GetComponent<Enemy>().StateMachine.CurrentEnemyState != enemy.GetComponent<Enemy>().InactiveState)
                {

                    enemy.GetComponent<Enemy>().ResetPosition();


                }
            }




        }
    }

    public void ResetItems()
    {
        foreach (GameObject item in items)
        {
            if (item.activeSelf == false)
            {

                item.SetActive(true);
            }
        }
    }

    public void ResetObjects()
    {
        foreach (ResetPosition objeCt in objeCts)
        {
            objeCt.transform.position = objeCt.iniPos;

            if (objeCt.gameObject.activeSelf == false)
            {
                objeCt.gameObject.SetActive(true);
            }
        }
    }

    public void ResetWateroos()
    {
        foreach (GameObject wateroo in wateroos)
        {   

            if (wateroo.GetComponent<WaterController>().speed !=  wateroo.GetComponent<WaterController>().iniSpeed) 
            {

                FlipWater(wateroo);
            }
        }
    }

    public void StopPlatforms()
    {
        foreach (MovingPlatform platForm in platForms)
        {
            if (platForm.stop == false)
            {
                platForm.stop = true;
            }
        }
    }

    public void StartEnemies()
    {
        foreach (GameObject enemy in enemies)
        {
            if (enemy.GetComponent<Enemy>().onScreen)
            {

                enemy.GetComponent<Enemy>().ResetState();
            }
        }
    }



    public void CheckPoint(Vector2 checkPos)
    {
        respawnPos = checkPos;

        if (checkPointActive == false)
        {
            checkPointActive = true;
        }
    }

    public void FlipWater(GameObject waters)
    {
        
        Vector3 scale = waters.transform.localScale;
        scale.x *= -1;
        waters.transform.localScale = scale;
        waters.GetComponent<WaterController>().speed *= -1;

    }

    public void TeleportWolf()
    {   
        wolf.transform.position = new Vector2(12.96733f, 1.108206f);
        barrier2.SetActive(true);
        camSwap.SetActive(true);
        
    }
    public void BossDefeated()
    {
        SceneManager.LoadScene("End");
    }


}
