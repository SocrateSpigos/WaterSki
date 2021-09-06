using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Transform trigger;
    public Transform Camera;
   // public Transform player;


    private bool isLerp = false;
    float Speed = 2f;


    void Update()
    {
        if (isLerp)
         PositionChanging();

    }

    void PositionChanging()
    {

        Camera.transform.position = Vector3.Lerp(Camera.position, trigger.position, Time.deltaTime * Speed);
        Camera.transform.rotation = Quaternion.Lerp(Camera.rotation, trigger.rotation, Time.deltaTime * Speed * 3f);
        //this.transform.LookAt(player.transform.position);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Yo");
            //transform.LookAt(player);

            isLerp = true;
        }
    }
}
