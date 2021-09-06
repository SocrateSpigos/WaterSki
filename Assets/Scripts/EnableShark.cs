using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableShark : MonoBehaviour
{
    //public GameObject boatRender;
    //public Renderer rend;
    public GameObject danger;
    public GameObject SharkAttack;
    public Animator anim;


    public void Start()
    {
        /*rend = GetComponent<Renderer>();
        rend.enabled = true;*/
        anim = SharkAttack.GetComponent<Animator>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Player"))
        {
            danger.SetActive(true);
            anim.SetBool("Shark", true);
            //GameObject.Find("boat").GetComponent<Renderer>().enabled = false;

        }
    }


}
