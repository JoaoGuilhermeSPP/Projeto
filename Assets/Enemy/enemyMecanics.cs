using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMecanics : MonoBehaviour
{
        public float speed = 3f;
        public Transform target;
        public bool isFollowing = false;
        public GameObject sinal;
        public Animator anim;
        public float rd;
        public LayerMask pl;
        public Transform margem;
    void Update()
        {
            if (isFollowing && target != null)
            {
                FollowTarget();
            }
            Oncoll();
        }

        private void FollowTarget()//Segue o player
    {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    private void Oncoll()//colidi e mata o player hitkill
    {
        Collider2D morte = Physics2D.OverlapCircle(margem.position, rd, pl);
        if (morte != null)
        {
            anim.SetBool("kill", true);
            PlayerMovements.instance.vivo = false;
            PlayerMovements.instance.Rig.constraints = RigidbodyConstraints2D.FreezeAll;
            PlayerMovements.instance.anim.speed = 0; 
        }
    }
    private void OnDrawGizmos()//desenha o colisor
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(margem.position, rd);
    }
}


