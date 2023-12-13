using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [HideInInspector] public bool move;
    [HideInInspector] public bool stop;
    private Rigidbody2D rb2d;
    [SerializeField] private float speed;
    [HideInInspector] public bool isLefted;
    [SerializeField] private Transform leftCheck;
    [SerializeField] private float leftCheckRadius;
    [SerializeField] public LayerMask whatIsLeft;

    [HideInInspector] public bool isRighted;
    [SerializeField] private Transform rightCheck;
    [SerializeField] private float rightCheckRadius;
    [SerializeField] public LayerMask whatIsRight;

    private float speedWater;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        isLefted = Physics2D.OverlapCircle(leftCheck.position, leftCheckRadius, whatIsLeft);
        isRighted = Physics2D.OverlapCircle(rightCheck.position, rightCheckRadius, whatIsRight);
        if (move)
        {
            Move();

            if (isLefted)
            {
                if (speedWater >= 1)
                {
                    stop = false;
                }
                else
                {
                    stop = true;
                }
            }

            else if (isRighted)
            {
                if (speedWater >= 1)
                {
                    stop = true;
                }
                else
                {
                    stop = false;
                }
            }
            else 
            { 
                stop = false;

            }

        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(leftCheck.position, leftCheckRadius);
        Gizmos.DrawWireSphere(rightCheck.position, rightCheckRadius);

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            move = true;
            
            speedWater = collision.gameObject.GetComponent<WaterController>().speed;
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            move = false;

        }
    }



    public void Move()
    {   
        if (stop == false)
        {
            rb2d.velocity = new Vector2(speed * speedWater, 0);


        }
        else
        {
            move = false;
            rb2d.velocity = Vector2.zero;
        }

    }


}
