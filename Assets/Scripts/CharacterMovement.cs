using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    public Vector3 offset;
    public Transform target;

    private void Update()
    {
        float zDirection = Input.GetAxis("Horizontal");

        transform.position = target.position + offset;

        Vector3 moveDirection = new Vector3(0.02f, 0f, zDirection*0.05f);
        transform.position += moveDirection;
        this.transform.LookAt(target.position);

    }

}