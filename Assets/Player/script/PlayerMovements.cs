using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovements : MonoBehaviour
{

    public static PlayerMovements instance;
    public Rigidbody2D Rig;
    public  float speed = 2;
    public  float dashDistance = 2f;
    public  float dashTime = 0.5f;
    public float intCharge = 5f;
    public float decremente = 1f;
    private bool isDashing = false;
    public  bool bloq;
    public bool vivo = true;

    public Collider2D col;

    Vector2 dashDirection;
     public Animator anim;
     public Vector2 movement;
     public GameObject effect;

    public GameObject PainelDead;


    // Start is called before the first frame update
    void Start()
    {
        
        Rig = GetComponent<Rigidbody2D>();
        instance = this;
        bloq = false;
        col.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (vivo)
        {
            Move();
            Dash();
        }
        bloq  = intCharge <= 0;
        if (!vivo) 
        {
            speed = 0f;
            anim.SetTrigger("dead");
            Invoke("DeadGameOver",1.2f);
            
        }
    }
    void FixedUpdate() 
    {
       
        Rig.MovePosition(Rig.position + movement * speed * Time.deltaTime); 
       
    }
    void Move()
    {
     movement.x = Input.GetAxisRaw("Horizontal");
     movement.y = Input.GetAxisRaw("Vertical");
     anim.SetFloat("Horizontal", movement.x);
     anim.SetFloat("Vertical", movement.y);
     anim.SetFloat("speed",movement.sqrMagnitude); 
    }
    void Dash()// dash
     {
        Vector2 mdirection = new Vector2(movement.x, movement.y).normalized;

        if(!bloq  && intCharge >= 0)
        {
        if (Input.GetKeyDown(KeyCode.Space) && !isDashing && mdirection.magnitude > 0)
            {
                 GameObject effectD = Instantiate(effect, transform.position, Quaternion.identity);
                  Destroy(effectD, 0.25f);
                  intCharge -= decremente;
                  intCharge = Mathf.Max(intCharge, 0f);
                  StartCoroutine(forceDash(mdirection));
               
            }
        }
     }
    void DeadGameOver() 
    {
        gameObject.SetActive(false);
        PainelDead.SetActive(true);

    }

    //dash
    private IEnumerator forceDash(Vector2 direction)
    {
        isDashing = true;
        dashDirection = direction;
        Vector2 starPos = Rig.position;
        Vector2 endPos = starPos + direction * dashDistance;
        float slapedTime = 0f;

            while(slapedTime < dashTime)
            {
            float dashSpeed = dashDistance / dashTime;
            Rig.MovePosition(Rig.position + dashDirection * dashSpeed * Time.deltaTime);
            slapedTime += Time.deltaTime;
            yield return new WaitForFixedUpdate();
           
            }
            Collider2D[] colliders = Physics2D.OverlapPointAll(endPos);
             foreach (Collider2D collider in colliders)
             {
                if (collider.gameObject.layer == 3) 
                     {
                        isDashing = false;
                        yield break; 
                     }
            }
            Rig.position = endPos; 
            isDashing = false;
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.layer == 3)
        {
            isDashing = false;
        }
    }
}

