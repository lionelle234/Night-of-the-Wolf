using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector] public Transform playerTransform;

    [HideInInspector] public Animator enemAtor;
    [HideInInspector] public Rigidbody2D rb2d;
    [HideInInspector] public BoxCollider2D bc2d;
    [HideInInspector] public SpriteRenderer spr;

    public Rigidbody2D boneArrow;
    public Vector2 iniPos;
    public bool iniFacing;
    [HideInInspector] public bool hitGround;
    public bool onScreen;
    public float maxSpeed;

    [HideInInspector] public bool canSeePlayer;
    [HideInInspector] public RaycastHit2D hit;
    public Transform playerCheck;
    public Vector2 playerCheckEnd;
    public float playerCheckDistance;
    public LayerMask whatIsPlayer;

    [SerializeField] public bool facingRight;
    [HideInInspector] public bool isStunned;
    [HideInInspector] public bool onActivated;
    [HideInInspector] public bool isActive;

    public SFXController voice;
    public EnemyStateMachine StateMachine { get; set; }
    public EnemyIdleState IdleState { get; set; }
    [SerializeField]
    private EnemyIdleSOBase EnemyIdleBase;
    public EnemyIdleSOBase EnemyIdleBaseInstance { get; set; }

    public EnemyAggroState AggroState { get; set; }
    [SerializeField]
    private EnemyAggroSOBase EnemyAggroBase;
    public EnemyAggroSOBase EnemyAggroBaseInstance { get; set; }

    public EnemyStunState StunState { get; set; }
    public EnemyWaitState WaitState { get; set; }
    public EnemyInactiveState InactiveState { get; set; }
    public EnemyDeadState DeadState { get; set; }
    public EnemyStandingState StandingState { get; set; }

    private void Awake()
    {   
        enemAtor = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        bc2d = GetComponent<BoxCollider2D>();
        spr = GetComponent<SpriteRenderer>();


        EnemyIdleBaseInstance = Instantiate(EnemyIdleBase);
        EnemyAggroBaseInstance = Instantiate(EnemyAggroBase);

        StateMachine = new EnemyStateMachine();

        IdleState = new EnemyIdleState(this, StateMachine);
        AggroState = new EnemyAggroState(this, StateMachine);
        StunState =  new EnemyStunState(this, StateMachine);
        WaitState = new EnemyWaitState(this, StateMachine);
        InactiveState = new EnemyInactiveState(this, StateMachine);
        DeadState = new EnemyDeadState(this, StateMachine);
        StandingState = new EnemyStandingState(this, StateMachine);
    }
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        iniPos = transform.position;
        iniFacing = facingRight;
        maxSpeed = 1;

        EnemyIdleBaseInstance.Initialize(gameObject, this);
        EnemyAggroBaseInstance.Initialize(gameObject, this);

        if (facingRight)
        {
            playerCheckEnd *= 1;
        }
        else
        {
            playerCheckEnd *= -1;
        }
        StateMachine.Initialize(InactiveState);

    }

    private void FixedUpdate()
    {
        if (isActive)
        {
            StateMachine.CurrentEnemyState.FrameUpdate();
        }

        if (playerCheck != null && isActive)
        {
            hit = Physics2D.Raycast(playerCheck.position, playerCheckEnd, playerCheckDistance, whatIsPlayer);
        }

        if (isActive == false)
        {
            StateMachine.ChangeState(InactiveState);
        }



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HitBox")
        {
            collision.gameObject.GetComponentInParent<Man>().inventory.torchCount -= 1;
            StateMachine.ChangeState(StunState);
        }

        if (collision.gameObject.tag == "HitBoxKill")
        {
            StateMachine.ChangeState(DeadState);

        }

        if (collision.gameObject.tag == "DropKill")
        {
            
            collision.gameObject.SetActive(false);
            StateMachine.ChangeState(DeadState);
        }

        if (collision.gameObject.tag == "Floor")
        {
            hitGround = true;
        }

        if (collision.gameObject.tag == "Flip")
        {
            Flip();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            hitGround = false;
        }
    }


    public void Flip()
    {
        facingRight = !facingRight;
        maxSpeed *= -1;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        playerCheckEnd *= -1;
        transform.localScale = scale;
    }




    private void OnBecameVisible()
    {
        onScreen = true;
        rb2d.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
        if (onActivated == false)
        {

            StateMachine.Initialize(IdleState);
            onActivated = true;

        }
        else
        {

            if (StateMachine.CurrentEnemyState != IdleState)
            {
                enemAtor.SetTrigger("Idling");
            }

            StateMachine.ChangeState(IdleState);
        }
    }
    private void OnBecameInvisible()
    {
        onScreen = false;
        isActive = false;



    }

    public void ResetPosition()
    {
        bc2d.enabled = true;
        isActive = false;
    }

    public void ResetState()
    {
        rb2d.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
        

        enemAtor.SetTrigger("Idling");
        StateMachine.ChangeState(IdleState);
    }

    public void Dead()
    {   
        if (transform.parent != null)
        {
            transform.SetParent(null);
        }
        gameObject.SetActive(false);
    }

    public class AnimationTriggerType
    {
    }
}
