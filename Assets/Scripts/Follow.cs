using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class Follow : MonoBehaviour
{

    public Transform target; 
    public float moveSpeed; 
    public float rotationSpeed = 5; 
    private Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        InvokeRepeating("Approach", 0f,1f);
    }


    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), rotationSpeed * Time.deltaTime);
        transform.position += transform.forward * Time.deltaTime * moveSpeed;

    }

    void Approach()
    {
        moveSpeed += 0.3f;
    }

}
