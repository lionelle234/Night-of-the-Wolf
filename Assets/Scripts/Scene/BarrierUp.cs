using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierUp : MonoBehaviour
{
    [SerializeField] private GameObject barrIer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wolf")
        {
            if (barrIer.activeSelf == false)
            {
                barrIer.SetActive(true);
            }
        }
    }

}
