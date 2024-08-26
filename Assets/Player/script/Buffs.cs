using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffs : MonoBehaviour
{
    public float buftime = 5f;
    public static Buffs  instance;
    public GameObject buff1;
    public GameObject buff2;
    public GameObject buff3;
    public Enemy_1 enemyMecanic;

    void Start()
    {
        instance = this;
        enemyMecanic = FindObjectOfType<Enemy_1>();
        enemyMecanic = GetComponent<Enemy_1>();
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.gameObject.CompareTag("livro1"))//aumeta velocidade
        {
             GameObject effect1 = Instantiate(buff1,transform.position,Quaternion.identity);
              effect1.transform.parent = PlayerMovements.instance.transform;
            PlayerMovements.instance.speed += 2f;
            Destroy(other.gameObject);
            StartCoroutine(Debuff(effect1));
        }   
       if(other.gameObject.CompareTag("livro2")) //aumenta dash
        {   
            GameObject effect2 = Instantiate(buff2,transform.position,Quaternion.identity);
            effect2.transform.parent = PlayerMovements.instance.transform;
            PlayerMovements.instance.dashDistance +=2;
            Destroy(other.gameObject);
            StartCoroutine(Debuff(effect2));
        }
        if (other.gameObject.CompareTag("livro3")) //Buff de intagivel
        {
            GameObject effect3 = Instantiate(buff3, transform.position, Quaternion.identity);
            effect3.transform.parent = PlayerMovements.instance.transform;
            PlayerMovements.instance.col.enabled = false;
            Destroy(other.gameObject);
            StartCoroutine(Debuff(effect3));
        }

    }
    IEnumerator Debuff(GameObject effect)
    {
        
        yield return new WaitForSeconds(buftime);
        if(PlayerMovements.instance.speed == 4f)
        {
            PlayerMovements.instance.speed -= 2f;
            Destroy(effect);
        }
        if (PlayerMovements.instance.speed == 8f)
        {
            PlayerMovements.instance.speed -= 6f;
            Destroy(effect);
        }
        if (PlayerMovements.instance.dashDistance == 4f)
        {
            PlayerMovements.instance.dashDistance -= 2f;
            Destroy(effect);
        }

        PlayerMovements.instance.col.enabled = true;
        Destroy(effect);
    }
}
