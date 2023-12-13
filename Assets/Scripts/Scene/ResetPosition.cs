using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    [HideInInspector] public Vector2 iniPos;
    // Start is called before the first frame update
    void Start()
    {
        iniPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
