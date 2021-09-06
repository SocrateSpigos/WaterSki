using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CoinSpinHandler : MonoBehaviour
{
    // simple rotation around the Y-axis
    float rotateSpeed = 200.0f;

    public void Start()
    {
    }

    void Update()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }
    
}
