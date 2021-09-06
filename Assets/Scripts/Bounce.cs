using UnityEngine;
using System.Collections;

public class Bounce : MonoBehaviour
{
    public Rigidbody rb;
    public float Thrust = 500;
    public GameObject waterBounce;
    public int hitsTaken=0;
  



    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "pelvis")
        {
            hitsTaken += 1;
            Debug.Log("Collision!");

            //rb.AddForce(transform.up * Thrust);
            rb.AddForce(new Vector3(0f, 100, 50), ForceMode.Impulse);
            waterBounce.SetActive(true);

            rb.useGravity = true;

            if (hitsTaken==1)
            {

                Destroy(gameObject);


            }

        }

    }
}