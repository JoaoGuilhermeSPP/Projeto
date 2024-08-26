using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1 : enemyMecanics
{
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))//detecta o player e faz um sinal 
        {
            if (sinal != null)
            {
                GameObject effect = Instantiate(sinal, transform.position, Quaternion.identity);
                effect.transform.parent = transform;
                effect.transform.localPosition = new Vector3(0f, 0.5f, 0f);
                Destroy(effect, 1.5f);
            }

            target = other.transform;
            isFollowing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)//sai da colisao
    {
        if (other.CompareTag("Player"))
        {
            isFollowing = false;
            target = null;
        }
    }
   
}
   

    
