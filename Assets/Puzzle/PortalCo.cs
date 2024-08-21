using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCo : MonoBehaviour
{
    [SerializeField] private Transform teleport;
    // Start is called before the first frame update
    public Transform irDestino() 
    {
        return teleport;
    }
}
