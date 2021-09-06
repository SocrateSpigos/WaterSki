using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonExplosion : MonoBehaviour
{
    public GameObject explosionGo;
    public Score score;
   



    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            score.ScoreCounter();
           
            GameObject go = Instantiate(explosionGo, transform.position, explosionGo.transform.rotation);
            Destroy(gameObject);

        }
    }

}
