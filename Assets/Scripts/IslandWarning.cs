using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandWarning : MonoBehaviour
{

    public GameObject incoming;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            incoming.SetActive(true);
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            incoming.SetActive(false);
        }
    }

}
