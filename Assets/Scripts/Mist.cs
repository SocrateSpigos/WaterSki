using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mist : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

    }
}
