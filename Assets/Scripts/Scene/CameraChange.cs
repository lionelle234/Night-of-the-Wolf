using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    [SerializeField]
    GameObject[] camList;
    [SerializeField]
    GameObject[] camSwapList;
    private GameObject camCurrent;
    private CinemachineVirtualCamera camCurrentV;
    private GameObject camSwapCurrent;

  
    private GameObject camNext;
    private CinemachineVirtualCamera camNextV;
    private GameObject camSwapNext;

    [SerializeField] private float count;

    [SerializeField] private GameObject blackScreen;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        


        if (blackScreen.activeSelf)
        {
            if (timer < count)
            {
                timer += Time.deltaTime;
            }
            else
            {

                camNext.SetActive(true);
                camNextV.enabled = true;
                blackScreen.SetActive(false);
               

            }
        }
    }

    public void ChangeCameraPlus(int camIndex)
    {

        timer = 0;
        blackScreen.SetActive(true);

        camCurrent = camList[camIndex];
        camCurrentV = camCurrent.GetComponent<CinemachineVirtualCamera>();
        camCurrent.SetActive(false);
        camCurrentV.enabled = false;
        camSwapCurrent = camSwapList[camIndex];
        camSwapCurrent.SetActive(false);

        camNext = camList[camIndex + 1];
        camNextV = camNext.GetComponent<CinemachineVirtualCamera>();
        camSwapNext = camSwapList[camIndex + 1];
        camSwapNext.SetActive(true);






    }

    public void ChangeCameraMinus(int camIndex)
    {

        timer = 0;
        blackScreen.SetActive(true);

        camCurrent = camList[camIndex];
        camCurrentV = camCurrent.GetComponent<CinemachineVirtualCamera>();
        camCurrent.SetActive(false);
        camCurrentV.enabled = false;
        camSwapCurrent = camSwapList[camIndex];
        camSwapCurrent.SetActive(false);

        camNext = camList[camIndex - 1];
        camNextV = camNext.GetComponent<CinemachineVirtualCamera>();
        camSwapNext = camSwapList[camIndex - 1];
        camSwapNext.SetActive(true);



    }
}
