using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [HideInInspector] public Transform playerTransform;

    [HideInInspector] public Animator bossmAtor;
    [HideInInspector] public Rigidbody2D rb2d;
    [HideInInspector] public BoxCollider2D bc2d;
    [HideInInspector] public SpriteRenderer spr;

    [SerializeField] private int maxHealth;
    [HideInInspector] public int currentHealth;
    public Vector2 iniPos;
    public bool iniFacing;
    [HideInInspector] public bool hitGround;
    public bool onScreen;
    public float maxSpeed;
    public Rigidbody2D projecTile;

    public int random1, random2;
    public float atkSpeed, timeBtwShots, waitCount;

    [SerializeField] public bool facingRight;
    [HideInInspector] public bool onActivated;
    [HideInInspector] public bool isActive;
    [HideInInspector] public bool isVulnerable;

    public SFXController voice;
    public SFXController weapon;
    public BossStateMachine StateMachine { get; set; }
    public BossIdleState IdleState { get; set; }
    public BossAttackState AttackState { get; set; }
    public BossTeleportState TeleportState { get; set; }
    public BossDeadState DeadState { get; set; }
    public BossInactiveState InactiveState { get; set; }

    private void Awake()
    {
        bossmAtor = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        bc2d = GetComponent<BoxCollider2D>();
        spr = GetComponent<SpriteRenderer>();



        StateMachine = new BossStateMachine();

        IdleState = new BossIdleState(this, StateMachine);
        AttackState = new BossAttackState(this, StateMachine);
        TeleportState = new BossTeleportState(this, StateMachine);
        DeadState = new BossDeadState(this, StateMachine);
        InactiveState = new BossInactiveState(this, StateMachine);
    }
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        iniPos = transform.position;
        iniFacing = facingRight;
        currentHealth = maxHealth;
        isActive = true;

        StateMachine.Initialize(InactiveState);




    }

    private void FixedUpdate()
    {
        StateMachine.CurrentBossState.FrameUpdate();





    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Flip")
        {
            Flip();
        }

        if (collision.gameObject.tag == "Solid")
        {
            hitGround = true;
        }

        if (collision.gameObject.tag == "HitBoxKill")
        {   
            if (isVulnerable)
            {
                Hurt();
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Solid")
        {
            hitGround = false;
        }
    }

    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        maxSpeed *= -1;
        transform.localScale = scale;
    }

    public void Hurt()
    {   

        currentHealth -= 1;
        spr.color = Color.red;
        isVulnerable = false;


        if (currentHealth == 3)
        {
            voice.PlaySFX(0);
            if (facingRight)
            {
                maxSpeed = 1.3f;
            }
            else
            {
                maxSpeed = -1.3f;
            }

            atkSpeed = 1.2f;
            timeBtwShots = 1.5f;
            waitCount = 2;
        }
        
        else if (currentHealth == 2)
        {
            voice.PlaySFX(0);
            if (facingRight)
            {
                maxSpeed = 1.5f;
            }
            else
            {
                maxSpeed = -1.5f;
            }
            random1 = 3;
            random2 = 5;
            atkSpeed = 1.5f;
            timeBtwShots = 1f;
            waitCount = 2;
        }
        else if (currentHealth == 1)
        {
            voice.PlaySFX(0);
            if (facingRight)
            {
                maxSpeed = 1.7f;
            }
            else
            {
                maxSpeed = -1.7f;
            }
            atkSpeed = 1.7f;
            timeBtwShots = 0.8f;
            waitCount = 1.5f;
        }
        else
        {   
            StateMachine.ChangeState(DeadState);
        }
    }


    public void InitialPosition()
    {
        transform.position = iniPos;
    }

    public void ChangeIdle()
    {
        bossmAtor.SetTrigger("Idling");
        StateMachine.ChangeState(IdleState);
    }

    public void WeaponSFX()
    {
        weapon.PlaySFX(0);
    }

    public void Inactive()
    {
        isActive = false;
        currentHealth = maxHealth;


    }

    public void Active()
    {   
        isActive = true;
        transform.position = iniPos;
        if (facingRight != iniFacing)
        {
            Flip();
        }
        maxSpeed = 1;
        random1 = 2;
        random2 = 4;
        atkSpeed = 1;
        timeBtwShots = 2;
        waitCount = 3;
        StateMachine.ChangeState(IdleState);
    }
    public void Dead()
    {
        DirectorController.instance.BossDefeated();
    }


    private void OnBecameVisible()
    {   
        onActivated = true;
        StateMachine.ChangeState(IdleState);
    }




    public class AnimationTriggerType
    {
    }
}
