using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectController : MonoBehaviour
{
    [SerializeField] private GameObject crystal;
    [SerializeField] private GameObject check, check2;

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount == 0)
        {
            SpawnObject();
            gameObject.SetActive(false);
        }


    }

    public void SpawnObject()
    {
        crystal.SetActive(true);
        if (check != null)
        {
            check.SetActive(true);
        }
        if (check2 != null)
        {
            check2.SetActive(true);
        }

    }


}
