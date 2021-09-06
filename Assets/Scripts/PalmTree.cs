using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalmTree : MonoBehaviour
{
    public Rigidbody palm;
    public Animator palmTree;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag=="BigObstacle")
        {
            palmTree.SetBool("IsHit", true);



           /* palm.useGravity = true;
            palm.AddForce(transform.up * 200);
            palm.AddForce(transform.forward * -200);
*/
        }
    }
}
