using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtScript : MonoBehaviour
{

    public Transform Target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        var newRotation = Quaternion.LookRotation(Target.transform.position - transform.position).eulerAngles;
        newRotation.x = 0;
        newRotation.z = 0;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(newRotation + new Vector3(0,90,90))
            , Time.deltaTime * 2f);

    }
}
