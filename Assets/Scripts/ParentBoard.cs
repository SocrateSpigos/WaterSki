using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentBoard : MonoBehaviour
{
    public Animator parent;

    void Start()
    {
        parent = gameObject.GetComponent<Animator>();

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Obstacle" || other.tag == "BigObstacle")
        {
            Debug.Log("DamnBoi");
            parent.SetBool("Hit", true);
        }
    }
}
