using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class PlayerPath : MonoBehaviour
{
    public PathCreator pathCreator;
    public BoatPath boat;

    private float speed = 10;
    public Vector3 offset;
    public float maxOffset;
    private Vector3 horizontalMovement = Vector3.zero;
    public float swipeMult;
    internal bool reverseSwipe = false;
    float distanceTravelled;
    public Transform Target;
    public GameObject shark;

    private Vector2 firstMousePos, lastMousePos;
    //public Animator stunt;

    public void Start()
    {
        speed = boat.speed;
        //stunt = gameObject.GetComponent<Animator>();

    }



    // Update is called once per frame
    void Update()
    {
        if (shark.activeInHierarchy)
        {
            reverseSwipe = true;
            maxOffset = 2.5f;
        }

        transform.rotation = Quaternion.Euler(0, pathCreator.path.GetRotationAtDistance(distanceTravelled).y, 0);

        if (Input.GetMouseButtonDown(0))
        {
            firstMousePos = Input.mousePosition;
            lastMousePos = firstMousePos;
        }
        else if (Input.GetMouseButton(0))
        {
            lastMousePos = Input.mousePosition;
            Vector2 swipe = lastMousePos - firstMousePos;
            // (swipe.x / (Screen.width / 2)) [-0.5 - 0.5] 
            float swipeDirectionMultipler = reverseSwipe ? 1 : -1;
            float swipePixels = Mathf.Clamp(swipeDirectionMultipler * (swipe.x / (Screen.width / 2)), -1, 1);


            horizontalMovement = swipePixels * swipeMult * transform.forward + horizontalMovement;
            horizontalMovement = new Vector3(0, 0, Mathf.Clamp(horizontalMovement.z, -maxOffset, maxOffset));
        }

        distanceTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled) + horizontalMovement + offset;

        this.transform.LookAt(boat.transform.position);

    }

}
