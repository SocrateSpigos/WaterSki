using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour
{
    public Transform target;
    public Animator sharkAnim;
    public GameObject waterFX;
    public GameObject waterFX2;
    public GameObject Jaws1;

    void Start()
    {
        sharkAnim = gameObject.GetComponent<Animator>();

    }


    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "AttackRight")
        {
            sharkAnim.SetBool("Contact", true);
            //Jaws1.SetActive(true);
        }

        if (other.tag == "FirstAttack")
        {
            sharkAnim.SetBool("First", true);
            //Jaws1.SetActive(true);
        }
        
        if (other.tag == "SecondAttack")
        {
            sharkAnim.SetBool("Second", true);
            //Jaws1.SetActive(true);
        }

    }
    
    void OnTriggerExit(Collider other)
    {

         sharkAnim.SetBool("First", false);
        sharkAnim.SetBool("Second", false);


    }

    public void Update()
    {
       /*
        if (Vector3.Distance(transform.position, target.position) < 30)
        {
            Debug.Log("Open Mouth");
            sharkAnim.SetBool("IsClose", true);

        }
        else
        {
            sharkAnim.SetBool("IsClose", false);

        }

        if (Vector3.Distance(transform.position, target.position) < 12)
        {
            Debug.Log("OM NOM");
            sharkAnim.SetBool("Contact", true);
            waterFX.SetActive(false);
            waterFX2.SetActive(false);

        }*/
    }

}
