using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCollider : MonoBehaviour
{
    bool Ecolisao = false;
    private GameObject teleport;
 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fonte") && !Ecolisao)//colisor da fonte e pilar

        {
            Ecolisao = true;
            Vector2 NewPos = other.transform.position;
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            rb.position = NewPos;
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
            puzzlescript.instance.Incremente();
            cameraFollow.instance.Tremer();

        }
        if (other.CompareTag("teleport"))
        {
            teleport = other.gameObject;
           
            Vector2 destino = transform.position = teleport.GetComponent<PortalCo>().irDestino().position;
            transform.position = new Vector2(destino.x + 1.3f, destino.y + 1.3f);

        }

    }
    private void OnTriggerExit2D(Collider2D other)//teleport do pilar com o portal
    {
        if (other.CompareTag("teleport"))
        {
            if (other.gameObject == teleport)
            {
                
                teleport = null;

            }
        }
    }
   
}

    

