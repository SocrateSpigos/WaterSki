using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RafdollOnOff : MonoBehaviour
{
    //public GameObject bigAssCube;

    public float Thrust = 0.01f;


    public BoxCollider mainCollider;
    public GameObject StickmanRig;
    public GameObject bigAssCube;
    public GameObject surfBoard;
    public GameObject CameraPos;
    public GameObject windEffect;
    public GameObject surfParent;
    public GameObject handle;
    public GameObject rope;
    public GameObject Jaws;



    private GameObject waterFX_Up;
    private GameObject trail_Stickman;
    private GameObject waterFX;
    public GameObject head;
    public float speed;
    public GameObject warning;
    public GameObject obstacleWarning;
 
    public bool bounce = false;
    public Rigidbody rb;

    public Animator anim;






    void Start()
    {

        waterFX = GameObject.Find("BigSplash");

        //pathFollowScript = GameObject.Find("PathFollower");
        //pathFollowScript = GameObject.Find("Stickman_heads_sphere");

        warning.SetActive(false);
        trail_Stickman = GameObject.Find("Trail_Stickman");
        waterFX.SetActive(false);
        trail_Stickman.SetActive(true);

        GetRagdollPieces();
        RagdollModeOff();

}

void Update()
    {
        


        if (head.transform.position.y < -1.256)
        {

            if (!waterFX.activeInHierarchy)
            {
                warning.SetActive(false);
                GameObject.Find("Parent").GetComponent<PlayerPath>().enabled = false;

                Destroy(CameraPos);
                Destroy(Jaws);
                Destroy(surfParent, 1f);
                waterFX.SetActive(true);
                obstacleWarning.SetActive(false);
                waterFX.transform.position = new Vector3(head.transform.position.x, head.transform.position.y + 0.5f, head.transform.position.z);
                GameObject.Find("MainCameraPos").GetComponent<PlayerPath>().enabled = false;
                GameObject.Find("MainCamera").GetComponent<Animator>().enabled = false;


            }

        }

        StartCoroutine(CalculateSpeed());

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Obstacle")
        {
            GameObject.Find("MainCameraPos").GetComponent<PlayerPath>().enabled = false;
            Destroy(rope, 1f);

            surfBoard.SetActive(false);
            handle.SetActive(false);
            trail_Stickman.SetActive(false);
            bigAssCube.SetActive(true);
            RagdollModeOn();
            GameObject.Find("Stickman_heads_sphere").GetComponent<Outline>().enabled = false;



        }

        if (other.tag == "BigObstacle")
        {
            GameObject.Find("MainCameraPos").GetComponent<PlayerPath>().enabled = false;
            Destroy(rope, 1f);

            RagdollModeOn();
            trail_Stickman.SetActive(false);
            bigAssCube.SetActive(false);
            surfBoard.SetActive(false);
            handle.SetActive(false);
            GameObject.Find("SharkPivot").GetComponent<Follow>().enabled = false;
            GameObject.Find("Stickman_heads_sphere").GetComponent<Outline>().enabled = false;




        }

        if (other.tag =="Island1")
        {
            surfBoard.SetActive(false);
            handle.SetActive(false);
            GameObject.Find("SharkPivot").GetComponent<Follow>().enabled = false;
        }
        
      
    }

    Collider[] ragDollColliders;
    Rigidbody[] limbsRigidbodies; 

    void GetRagdollPieces()
    {
        ragDollColliders = StickmanRig.GetComponentsInChildren<Collider>();
        limbsRigidbodies = StickmanRig.GetComponentsInChildren<Rigidbody>();
    }

    public void RagdollModeOn()
    {

        anim.enabled = false;
        foreach (Collider col in ragDollColliders)
        {

            col.enabled = true;
        }

        foreach (Rigidbody rigid in limbsRigidbodies)
        {
            rigid.isKinematic = false;
        }
        Destroy(mainCollider);
        GetComponent<Rigidbody>().isKinematic = true;


    }

    void RagdollModeOff()
    {
        foreach (Collider col in ragDollColliders)
        {
            col.enabled = false;
        }

        foreach (Rigidbody rigid in limbsRigidbodies)
        {
            rigid.isKinematic = true;
        }
        mainCollider.enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;

    }

    IEnumerator CalculateSpeed()
    {
        Vector3 lastPosition = transform.position;
        yield return new WaitForFixedUpdate();
        speed = (lastPosition - transform.position).magnitude / Time.deltaTime;

       if (Mathf.Abs(rb.velocity.z) > 0.1f || Mathf.Abs(rb.velocity.z) > 0.1f)
        {


            bounce = true;
            bigAssCube.SetActive(true);
        }
    }

   
}
