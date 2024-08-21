using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMecanics : MonoBehaviour
{
        public float speed = 3f;
        public Transform target;
        public bool isFollowing = false;
        public GameObject sinal;

        void Update()
        {
            if (isFollowing && target != null)
            {
                FollowTarget();
            }
        }

        private void FollowTarget()
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }


