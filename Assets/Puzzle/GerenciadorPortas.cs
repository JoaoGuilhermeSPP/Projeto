using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GerenciadorPortas : MonoBehaviour
{
    private GameObject teleport;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (teleport != null) 
            {
                transform.position = teleport.GetComponent<PortalCo>().irDestino().position;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("teleport")) 
        {
            teleport = collision.gameObject;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("teleport")) 
        {
            if (collision.gameObject == teleport)
            {
                teleport = null;
            }
        }
    }


}
