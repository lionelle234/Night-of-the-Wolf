using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldTriggerCheck : MonoBehaviour
{
    
    private Wolf wolf;

    private void Awake()
    {

        wolf = GetComponentInParent<Wolf>();

    }
    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Holdable")
        {
            wolf.canReceiveAttackInput = false;
            wolf.canReceiveHoldInput = true;
            wolf.holdObject = collision.gameObject;


        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Holdable")
        {
            wolf.canReceiveAttackInput = true;
            wolf.canReceiveHoldInput = false;
        }
    }


}
