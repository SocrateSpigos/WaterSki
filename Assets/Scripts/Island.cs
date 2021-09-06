using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island : MonoBehaviour
{
   
    public GameObject cameraPos;
    public GameObject victoryAnim;
    public GameObject trail;
    public GameObject player;
    public GameObject handle;
    public GameObject shark;
    public GameObject surfParent;
    public GameObject IslandWarning;



    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject.Find("Parent").GetComponent<PlayerPath>().enabled = false;


            GameObject.Find("MainCameraPos").GetComponent<PlayerPath>().enabled = false;

            IslandWarning.SetActive(false);
            handle.SetActive(false);
            Destroy(cameraPos);
            player.SetActive(false);
            victoryAnim.SetActive(true);
            trail.SetActive(false);
            Destroy(shark, 1f);
            Destroy(surfParent);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
