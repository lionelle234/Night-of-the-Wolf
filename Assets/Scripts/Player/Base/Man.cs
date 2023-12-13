using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;

public class Man : MonoBehaviour
{
    [HideInInspector] public Vector2 movInput;
    [HideInInspector] public Rigidbody2D rb2d;
    [HideInInspector] public Animator manMator;
    [HideInInspector] public BoxCollider2D bc2d;
    public GameObject objChildren;

    [HideInInspector] public float currentSpeed;
    [HideInInspector] public bool m_facingRight = true;
    [HideInInspector] public bool isLedging;
    [HideInInspector] public bool isHiding;
    [HideInInspector] public bool outOfReach;

    [SerializeField] private GameObject waterAura;
    [SerializeField] private GameObject thunderAura;

    [HideInInspector] public bool isGrounded;
    [SerializeField] private Vector2 grounding;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask whatIsGround;

    [HideInInspector] public bool isLaddered;
    [SerializeField] private Transform ladderCheck;
    [SerializeField] private float ladderCheckRadius;
    [SerializeField] public LayerMask whatIsLadder;


    [HideInInspector] public bool onLadder;
    [SerializeField] private Transform onLadderCheck;
    [SerializeField] private float onLadderCheckRadius;

    [HideInInspector] public bool canReceiveTorchInput;
    [HideInInspector] public bool inputReceivedTorch;
    [HideInInspector] public bool canReceiveWaterCrestInput;
    [HideInInspector] public bool inputReceivedWaterCrest;
    [HideInInspector] public bool canReceiveThunderCrestInput;
    [HideInInspector] public bool inputReceivedThunderCrest;

    public InventoryController inventory;
    public CameraChange camchange;
    public DialogueController dialogue;
    
    public ManStateMachine StateMachine { get; set; }
    public ManIdleState IdleState { get; set; }
    [SerializeField]
    private ManIdleSOBase ManIdleBase;
    public ManIdleSOBase ManIdleBaseInstance { get; set; }

    public ManMovementState MovementState { get; set; }
    [SerializeField]
    private ManMovementSOBase ManMovementBase;
    public ManMovementSOBase ManMovementBaseInstance { get; set; }

    public ManLadderState LadderState { get; set; }
    public ManLedgeState LedgeState { get; set; }
    public ManDropState DropState { get; set; }
    public ManTorchState TorchState { get; set; }
    public ManDeadState DeadState { get; set; }
    public ManFallState FallState { get; set; }
    public ManNoteState NoteState { get; set; }
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        manMator = GetComponent<Animator>();
        bc2d = GetComponent<BoxCollider2D>();

        ManIdleBaseInstance = Instantiate(ManIdleBase);
        ManMovementBaseInstance = Instantiate(ManMovementBase);

        StateMachine = new ManStateMachine();

        IdleState = new ManIdleState(this, StateMachine);
        MovementState = new ManMovementState(this, StateMachine);
        LadderState = new ManLadderState(this, StateMachine);
        LedgeState = new ManLedgeState(this, StateMachine);
        DropState =  new ManDropState(this, StateMachine);
        TorchState = new ManTorchState(this, StateMachine);
        DeadState = new ManDeadState(this, StateMachine);
        FallState = new ManFallState(this, StateMachine);
        NoteState = new ManNoteState(this, StateMachine);

    }

    // Start is called before the first frame update
    void Start()
    {
        
        ManIdleBaseInstance.Initialize(gameObject, this);
        ManMovementBaseInstance.Initialize(gameObject, this);

        StateMachine.Initialize(IdleState);
    }


    private void FixedUpdate()
    {

        StateMachine.CurrentManState.FrameUpdate();
        isGrounded = Physics2D.BoxCast(transform.position, grounding, 0, -transform.up, groundCheckRadius, whatIsGround);
        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        //isGrounded = Physics2D.BoxCast(groundCheck.position, grounding, groundCheckRadius,directionground,whatIsGround);
        isLaddered = Physics2D.OverlapCircle(ladderCheck.position, ladderCheckRadius, whatIsLadder);
        onLadder = Physics2D.OverlapCircle(onLadderCheck.position, onLadderCheckRadius, whatIsLadder);

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position - transform.up * groundCheckRadius, grounding);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hide")
        {
            isHiding = true;
            transform.GetComponent<SpriteRenderer>().color = Color.gray;
        }



        if (collision.gameObject.tag == "CamPlus")
        {
            int camIndex = int.Parse(collision.gameObject.name);
            camchange.ChangeCameraPlus(camIndex);
        }

        if (collision.gameObject.tag == "CamMinus")
        {
            int camIndex = int.Parse(collision.gameObject.name);
            camchange.ChangeCameraMinus(camIndex);
        }

        if (collision.gameObject.tag == "Dialogue")
        {
            StateMachine.ChangeState(NoteState);
            int noteIndex = int.Parse(collision.gameObject.name);
            dialogue.NoteRead(noteIndex);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "CheckPoint")
        {
            DirectorController.instance.CheckPoint(collision.gameObject.transform.localPosition);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "PowerUp")
        {
            inventory.AddItem(collision.gameObject.name);
            if (collision.gameObject.name == "Crest (Water)")
            {
                canReceiveWaterCrestInput = true;
            }
            collision.gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (collision.gameObject.GetComponent<Enemy>().isStunned == false)
            {   

                if (collision.gameObject.GetComponent<Enemy>().StateMachine.CurrentEnemyState == collision.gameObject.GetComponent<Enemy>().AggroState)
                {
                    StateMachine.ChangeState(DeadState);
                }
                else
                {
                    if (isHiding == false)
                    {   
                        StateMachine.ChangeState(DeadState);
                    }
                    else
                    {
                        if (movInput.x != 0)
                        {
                            StateMachine.ChangeState(DeadState);
                        }
                    }
                }

            }

        }

        if (collision.gameObject.tag == "Item")
        {
            inventory.AddItem(collision.gameObject.name);


            collision.gameObject.SetActive(false);

           
        }



        if (collision.gameObject.tag == "NextScene")
        {
            DirectorController.instance.NextScene();
        }

        if (collision.gameObject.tag == "Hazard" || collision.gameObject.tag == "Water")
        {
            StateMachine.ChangeState(DeadState);
        }
        if (collision.gameObject.tag == "WaterInteraction")
        {   
            if (movInput.x != 0)
            {
                transform.SetParent(null);
                rb2d.bodyType = RigidbodyType2D.Dynamic;
            }
            else
            {
                transform.SetParent(collision.gameObject.transform);
                rb2d.bodyType = RigidbodyType2D.Kinematic;
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hide")
        {
            isHiding = false;
            transform.GetComponent<SpriteRenderer>().color = Color.white;
        }

        if (collision.gameObject.tag == "WaterInteraction")
        {
            transform.SetParent(null);
            rb2d.bodyType = RigidbodyType2D.Dynamic;

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ledge")
        {
            isLedging = true;

        }

    }




    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ledge")
        {
            isLedging = false;

        }




    }


    public void OnMove(InputValue value)
    {   
        if (StateMachine.CurrentManState != DropState)
        {
            movInput = value.Get<Vector2>();
        }
        

    }
    public void OnAttack()
    {   
        if (inventory.torchCount > 0 && canReceiveTorchInput)
        {
            inputReceivedTorch = true;
        }
        else
        {
            return;
        }
        
    }

    public void OnCrest()
    {
        if (canReceiveWaterCrestInput)
        {
            if (inputReceivedWaterCrest == false)
            {
                inputReceivedWaterCrest = true;
                waterAura.SetActive(true);
            }
            else
            {
                inputReceivedWaterCrest = false;
                waterAura.SetActive(false);
            }
        }
        else if (canReceiveThunderCrestInput)
        {
            if (inputReceivedThunderCrest == false)
            {
                inputReceivedThunderCrest = true;
                thunderAura.SetActive(true);
            }
            else
            {
                inputReceivedThunderCrest = false;
                thunderAura.SetActive(false);
            }
        }
    }

    public void OnSwap()
    {
        if (inventory.hasWater && inventory.hasThunder)
        {
            if (canReceiveWaterCrestInput)
            {
                if (inputReceivedWaterCrest == false)
                {   
                    canReceiveThunderCrestInput = true;
                    canReceiveWaterCrestInput = false;
                }
            }

            else if (canReceiveThunderCrestInput)
            {
                if (inputReceivedThunderCrest == false)
                {
                    canReceiveWaterCrestInput = true;
                    canReceiveThunderCrestInput = false;
                }
            }
        }
    }
    public void ClimbLedge()
    {   
        if (m_facingRight)
        {
            transform.position += new Vector3(0.09f, 0.12f, 0);
        }
        else
        {
            transform.position -= new Vector3(0.09f, -0.12f, 0);
        }

        rb2d.gravityScale = 1;
        isLedging = false;
    }

    public void DropLedge()
    {   
        if (m_facingRight)
        {
            transform.position += new Vector3(0.08f, -0.14f, 0);
        }
        else
        {
            transform.position -= new Vector3(0.08f, 0.14f, 0);
        }
        
        isLedging = false;
        manMator.SetTrigger("Laddering");
        StateMachine.ChangeState(LadderState);
    }

    public void StoreTorch()
    {
        StateMachine.ChangeState(IdleState);
    }

    public void Dead()
    {
        DirectorController.instance.Continue();
    }

    public void Respawn()
    {

        rb2d.gravityScale = 1;
        bc2d.enabled = true;
        objChildren.SetActive(true);
        transform.position = DirectorController.instance.respawnPos;
        manMator.SetTrigger("Idling");
        StateMachine.ChangeState(IdleState);
    }



    public class AnimationTriggerType
    {
    }
}
