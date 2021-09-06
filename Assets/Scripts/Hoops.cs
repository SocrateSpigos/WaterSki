using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoops : MonoBehaviour
{
    public GameObject explosionGo;
    public Score score;

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            score.HoopsCounter();

            GameObject go = Instantiate(explosionGo, transform.position, explosionGo.transform.rotation);
            Destroy(gameObject);


        }
    }
}