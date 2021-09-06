using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jaws : MonoBehaviour
{

    public GameObject incoming;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            incoming.SetActive(true);
        }
    }

    
}
