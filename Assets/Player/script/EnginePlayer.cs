using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnginePlayer : MonoBehaviour
{
  
    public Image barra;
    public Text livro;
    string TxLivro;

    public float maxcharge;
    public float fillSpeed  = 1f;
    public float targetFillAmount;
    bool reload = false;
    // Start is called before the first frame update
    void Start()
    {
        
         TxLivro = puzzlescript.instance.LivroPoint.ToString();
         livro.text = TxLivro;

    }

    // Update is called once per frame
    void Update()
    {
        
        recover();
        
        if(PlayerMovements.instance.intCharge == 0 && !reload)
        {
             reload = true;
            
             StartCoroutine(Increment());
        }
        
    }
    public void recover()
    {
        if(!reload)
        {
        barra.fillAmount = Mathf.Lerp(barra.fillAmount, PlayerMovements.instance.intCharge / maxcharge, Time.deltaTime * fillSpeed);
        }
        else
        {
            barra.fillAmount = Mathf.Lerp(barra.fillAmount, targetFillAmount, Time.deltaTime * fillSpeed);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.layer == 7)
        {
            puzzlescript.instance.IncrementeLivro();
             TxLivro = puzzlescript.instance.LivroPoint.ToString();
             livro.text = TxLivro;
        }
    }
    IEnumerator Increment()
    {
   yield return new WaitForSeconds(10f);
  PlayerMovements.instance.intCharge = maxcharge;
  PlayerMovements.instance.bloq = false;
    reload = false;
    }

}
