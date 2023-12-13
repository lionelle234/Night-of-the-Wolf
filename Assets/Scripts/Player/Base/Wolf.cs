using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.InputSystem;

public class Wolf : MonoBehaviour
{



    [HideInInspector] public Vector2 movInput;
    [HideInInspector] public Rigidbody2D rb2d;
    [HideInInspector] public Animator wolfMator;
    [HideInInspector] public BoxCollider2D bc2d;

    [HideInInspector] public bool inputReceivedJump;
    [HideInInspector] public bool canReceiveJumpInput;
    [HideInInspector] public bool inputReceivedAttack;
    [HideInInspector] public bool canReceiveAttackInput;
    [HideInInspector] public bool inputReceivedHold;
    [HideInInspector] public bool canReceiveHoldInput;
    [HideInInspector] public float currentSpeed;
    [HideInInspector] public bool m_facingRight = true;
    [HideInInspector] public bool isVulnerable;
    [SerializeField] public GameObject objChildren;
    [HideInInspector] public GameObject holdObject;
    [SerializeField] private Transform holdPos;

    [HideInInspector] public bool isGrounded;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private Vector2 grounding; 
    [SerializeField] private LayerMask whatIsGround;

    [SerializeField] public int maxHealth;
    [SerializeField] public int currentHealth;
    private float atkTimer;
    [SerializeField] private float atkCount;

    public InventoryController inventory;
    public CameraChange camChange;
    public SFXController voice;
    public WolfStateMachine StateMachine { get; set; }
    public PlayerIdleState IdleState { get; set; }
    [SerializeField]
    private PlayerIdleSOBase PlayerIdleBase;
    public PlayerIdleSOBase PlayerIdleBaseInstance { get; set; }

    public PlayerMovementState MovementState { get; set; }
    [SerializeField]
    private PlayerMovementSOBase PlayerMovementBase;
    public PlayerMovementSOBase PlayerMovementBaseInstance { get; set; }

    public PlayerJumpState JumpState { get; set; }
    [SerializeField]
    private PlayerJumpSOBase PlayerJumpBase;
    public PlayerJumpSOBase PlayerJumpBaseInstance { get; set; }

    public PlayerFallState FallState { get; set; }
    [SerializeField]
    private PlayerFallSOBase PlayerFallBase;
    public PlayerFallSOBase PlayerFallBaseInstance { get; set; }

    public PlayerAttackState AttackState { get; set; }
    public PlayerHurtState HurtState { get; set; }
    public PlayerDeadState DeadState { get; set; }
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        wolfMator = GetComponent<Animator>();
        bc2d = GetComponent<BoxCollider2D>();

        PlayerIdleBaseInstance = Instantiate(PlayerIdleBase);
        PlayerMovementBaseInstance = Instantiate(PlayerMovementBase);
        PlayerJumpBaseInstance = Instantiate(PlayerJumpBase);
        PlayerFallBaseInstance = Instantiate(PlayerFallBase);

        StateMachine = new WolfStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine);
        MovementState = new PlayerMovementState(this, StateMachine);
        JumpState = new PlayerJumpState(this, StateMachine);
        FallState = new PlayerFallState(this, StateMachine);
        AttackState = new PlayerAttackState(this, StateMachine);
        HurtState = new PlayerHurtState(this, StateMachine);
        DeadState = new PlayerDeadState(this, StateMachine);

    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        isVulnerable = true;

        PlayerIdleBaseInstance.Initialize(gameObject, this);
        PlayerMovementBaseInstance.Initialize(gameObject, this);
        PlayerJumpBaseInstance.Initialize(gameObject, this);
        PlayerFallBaseInstance.Initialize(gameObject, this);

        StateMachine.Initialize(IdleState);
    }


    private void FixedUpdate()
    {

        StateMachine.CurrentWolfState.FrameUpdate();
        isGrounded = Physics2D.BoxCast(transform.position, grounding, 0, -transform.up, groundCheckRadius, whatIsGround);
        //Debug.Log(StateMachine.CurrentWolfState);


    }


    private void Update()
    {
        if (inputReceivedAttack)
        {
            if (atkTimer < atkCount)
            {
                atkTimer += Time.deltaTime;
            }
            else
            {
                atkTimer = 0;
                inputReceivedAttack = false;
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position - transform.up * groundCheckRadius, grounding);

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Projectile")
        {
            if (isVulnerable)
            {
                
                Hurt();
            }

        }

        if (collision.gameObject.tag == "Hazard" || collision.gameObject.tag == "Water")
        {
            StateMachine.ChangeState(DeadState);
        }

        if (collision.gameObject.tag == "Item")
        {
            inventory.AddItem(collision.gameObject.name);
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.tag == "PowerUp")
        {
            inventory.AddItem(collision.gameObject.name);
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.tag == "Health")
        {   
            if (currentHealth != maxHealth)
            {
                currentHealth = maxHealth;
                inventory.ChangeHearts(0);
                collision.gameObject.SetActive(false);
            }

        }

        if (collision.gameObject.tag == "CamPlus")
        {
            int camIndex = int.Parse(collision.gameObject.name);
            camChange.ChangeCameraPlus(camIndex);
        }

        if (collision.gameObject.tag == "BossAttack")
        {
            if (isVulnerable)
            {
                Hurt();
            }
        }

        if (collision.gameObject.tag == "CheckPoint")
        {
            DirectorController.instance.CheckPoint(collision.gameObject.transform.localPosition);
            Destroy(collision.gameObject);
        }
    }

    


    public void OnMove(InputValue value)
    {
        movInput = value.Get<Vector2>();

    }
    public void OnAttack()
    {
        if (canReceiveAttackInput && isGrounded && inputReceivedAttack == false)
        {
            inputReceivedAttack = true;
            StateMachine.ChangeState(AttackState);
        }
        else if (canReceiveHoldInput && isGrounded && inventory.hasFangs)
        {
            if (inputReceivedHold == false)
            {   
                HoldObject();
                inputReceivedHold = true;
            }
            else
            {   
                ReleaseObject();
                inputReceivedHold = false;
            }
        }

        
    }

    public void OnJump()
    {
        if (isGrounded)
        {
            if (canReceiveJumpInput)
            {
                inputReceivedJump = true;
            }

        }
    }

    public void EndAttack()
    {
        if (movInput.x != 0)
        {
            wolfMator.SetBool("Moving", true);
            StateMachine.ChangeState(MovementState);

        }
        else
        {
            wolfMator.SetTrigger("Idling");
            StateMachine.ChangeState(IdleState);
        }
    }

    public void Hurt()
    {   
        if (inventory.hasShield)
        {
            currentHealth -= 1;
            inventory.ChangeHearts(1);
        }
        else
        {
            currentHealth -= 2;
            inventory.ChangeHearts(2);
        }
        

        if (currentHealth <= 0)
        {
            
            StateMachine.ChangeState(DeadState);
        }
        else
        {
            
            StateMachine.ChangeState(HurtState);
        }
    }
    public void HoldObject()
    {
        holdObject.GetComponent<BoxCollider2D>().isTrigger = true;
        holdObject.layer = LayerMask.NameToLayer("Default");
        holdObject.GetComponent<Rigidbody2D>().isKinematic = true;
        holdObject.transform.SetParent(gameObject.transform);
        holdObject.transform.position = new Vector2(holdPos.position.x, holdObject.transform.position.y);
    }

    public void ReleaseObject()
    {   
        if (holdObject != null)
        {
            holdObject.GetComponent<BoxCollider2D>().isTrigger = false;
            holdObject.GetComponent<Rigidbody2D>().isKinematic = false;
            holdObject.transform.SetParent(null);
            if (m_facingRight)
            {
                holdObject.transform.position = new Vector2(holdObject.transform.position.x + 0.01f, holdObject.transform.position.y);
            }
            else
            {
                holdObject.transform.position = new Vector2(holdObject.transform.position.x + 0.01f * -1, holdObject.transform.position.y);
            }
            holdObject.layer = LayerMask.NameToLayer("Ground");
        }


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
        currentHealth = maxHealth;
        wolfMator.SetTrigger("Idling");
        StateMachine.ChangeState(IdleState);
    }
    public class AnimationTriggerType
    {
    }
}
