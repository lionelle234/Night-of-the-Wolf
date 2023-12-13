using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    public float speed;
    [HideInInspector] public float iniSpeed;
    // Start is called before the first frame update
    void Start()
    {
        iniSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
