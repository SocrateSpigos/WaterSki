using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class SharkPath : MonoBehaviour
{
    public PathCreator pathCreator;
    public float speed = 5;
    float distanceTravelled =1;
    Vector3 offset = new Vector3(0f, 0f, 1f);


    // Update is called once per frame
    void Update()
    {
        distanceTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
        transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);
    }
}

