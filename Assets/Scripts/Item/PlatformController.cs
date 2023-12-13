using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.CinemachineFreeLook;

public class PlatformController : MonoBehaviour
{
    [SerializeField]
    private GameObject platForm;
    public bool drop;
    public float timer;
    [SerializeField]
    private float count;
    [SerializeField]
    private float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (drop)
        {
            if (timer < count)
            {
                timer += Time.deltaTime;
                if (platForm != null)
                {
                    DropPlatform();
                }
 
            }
            else
            {   
                if (platForm != null)
                {
                    platForm.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                }
                timer = 0;
                drop = false;
                transform.gameObject.SetActive(false);
            }

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HitBox")
        {
            drop = true;

        }
    }
    public void DropPlatform()
    {
        platForm.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);

    }
}
