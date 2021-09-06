using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stunt : MonoBehaviour
{
    public Animator anim;
    public GameObject cam;
    public GameObject camPos;
    public GameObject surfParent;
    public Animator camAnimator;
    public Animator camPosAnimator;

    public ParticleSystem playerTrail;




    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        camAnimator = cam.GetComponent<Animator>();
        camPosAnimator = camPos.GetComponent<Animator>();

    }
    private void OnTriggerEnter(Collider other)

    {

        if (other.tag == "Ramp")
        {
            Debug.Log("ramp");
            anim.SetBool("Stunt", true);
            camAnimator.SetBool("Jump", true);
            camPosAnimator.SetBool("Up", true);
            playerTrail.Stop();

        }


        if (other.tag == "Ramp2")
        {

            Debug.Log("ramp2");
            anim.SetBool("Stunt2", true);
            camAnimator.SetBool("Jump", true);
            camPosAnimator.SetBool("Up", true);
            playerTrail.Stop();


        }


        if (other.tag == "Ramp3")
        {

            Debug.Log("ramp3");
            anim.SetBool("Stunt3", true);
            camAnimator.SetBool("Jump", true);
            camPosAnimator.SetBool("Up", true);
            playerTrail.Stop();


        }

        if (other.tag == "Ramp4")
        {

            Debug.Log("ramp4");
            anim.SetBool("Stunt4", true);
            camAnimator.SetBool("Jump", true);
            camPosAnimator.SetBool("Up", true);
            playerTrail.Stop();


        }



    }
        private void OnTriggerExit(Collider other)
        {
            anim.SetBool("Stunt", false);
            anim.SetBool("Stunt2", false);
            anim.SetBool("Stunt3", false);
            anim.SetBool("Stunt4", false);

            camAnimator.SetBool("Jump", false);
            camPosAnimator.SetBool("Up", false);
            
            StartCoroutine(PlayerCoroutine());


        }


    IEnumerator PlayerCoroutine()
    {

        yield return new WaitForSeconds(1.4f);
        playerTrail.Play();

    }

}
