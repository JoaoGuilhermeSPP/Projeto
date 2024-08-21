using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzlescript : MonoBehaviour
{
    public static puzzlescript instance;
    public int Count = 0;
    public int LivroPoint = 0;
    public GameObject Portal;
    public int RequiredCount = 3;
    public int RequiredLivro = 2;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        Portal.SetActive(false);
    }

    void Update()
    {
        if (Count >= RequiredCount && LivroPoint >= RequiredLivro)
        {
            cameraFollow.instance.Tremor();
            Portal.SetActive(true);
           

        }

    }
    public void IncrementeLivro() 
    {
        if (LivroPoint < RequiredLivro ) 
        {
            LivroPoint++;
        }
    }
    public void Incremente()
    {
        if (Count < RequiredCount)
        {
            Count++;
        }
    }
}


