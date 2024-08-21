using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public static cameraFollow instance;
    public Animator anim;
    
   
    public Transform Player;
    // Start is called before the first frame update
    private void Start()
    {
        instance = this;
        anim.SetBool("tremor", false);
        anim.SetBool("tremer", false);
    }
    private void FixedUpdate()
   {
    transform.position = Vector2.Lerp(transform.position,Player.position,0.1f);
   }
    public void Tremer() 
    {
        anim.SetBool("tremer", true);
        Invoke("parar", 0.1f);
    }
    public void Tremor() 
    {
        anim.SetBool("tremor", true);
        Invoke("parartr", 0.4f);
    }
    public void parar() 
    {
        anim.SetBool("tremer", false);
      
    }
    public void parartr()
    {

        anim.SetBool("tremor", false);

    }

}
