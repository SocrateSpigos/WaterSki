using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatStunt : MonoBehaviour
{
    public Animator boatAnimator;
    public ParticleSystem boatTrail;
    public ParticleSystem waterFX;
    // Start is called before the first frame update
    void Start()
    {
        boatAnimator = gameObject.GetComponent<Animator>();


    }
    private void OnTriggerEnter(Collider other)

    {

        if (other.tag == "Ramp" || other.tag == "Ramp3" || other.tag == "Ramp2" || other.tag == "Ramp4")
        {
            boatTrail.Stop();

            boatAnimator.SetBool("JumpBoat", true);
            waterFX.Stop();
        }



    }
    private void OnTriggerExit(Collider other)
    {
        boatAnimator.SetBool("JumpBoat", false);

        if (other.tag == "Ramp" || other.tag == "Ramp3" || other.tag == "Ramp2" || other.tag == "Ramp4")
        {
            StartCoroutine(BoatCoroutine());
        }
    }

    IEnumerator BoatCoroutine()
    {

        yield return new WaitForSeconds(0.5f);
        boatTrail.Play();
        waterFX.Play();


    }

}
