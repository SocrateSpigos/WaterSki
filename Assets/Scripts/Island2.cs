using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island2 : MonoBehaviour
{

    public GameObject cameraPos;
    public GameObject victoryAnim;
    public GameObject trail;
    public Renderer player;
    public GameObject handle;
    public GameObject shark;



    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            GameObject.Find("Stickman_heads_sphere").GetComponent<PlayerPath>().enabled = false;
            GameObject.Find("MainCameraPos").GetComponent<PlayerPath>().enabled = false;

            handle.SetActive(false);
            Destroy(cameraPos);
            player.enabled = false;
            victoryAnim.SetActive(true);
            trail.SetActive(false);
            shark.SetActive(false);
        }
    }
}
