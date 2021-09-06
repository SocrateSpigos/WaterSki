using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public GameObject x2;
    public GameObject x3;
    public GameObject x4;
    public Transform player;
    public Text score;
    public float multiplier;
    public int scoreTracking = 0;
    public Animator scoreAnim;

    // Update is called once per frame
    public void Start()
    {
        scoreAnim = gameObject.GetComponent<Animator>();
        InvokeRepeating("SetFalse", 0f, 0.1f);

    }

    void Update()
    {

        

      if (x2.activeInHierarchy)
        {
            multiplier = scoreTracking;
            multiplier = multiplier * 2;
            score.text = (multiplier).ToString("0");

        }
        
         if (x3.activeInHierarchy)
         {
             multiplier = scoreTracking;
             multiplier = multiplier * 3;
             score.text = (multiplier).ToString("0");

         }

        
        if (x4.activeInHierarchy)
        {
            multiplier = scoreTracking;
            multiplier = multiplier * 4;
            score.text = (multiplier).ToString("0");

        }

    }

    public void ScoreCounter()
    {

        Debug.Log("Coin");
        scoreTracking++;
        score.text = scoreTracking.ToString("0");
        scoreAnim.SetBool("PlusOne", true);

    }

    public void HoopsCounter()
    {

        Debug.Log("Coin");
        scoreTracking=scoreTracking+5;
        score.text = scoreTracking.ToString("0");
        scoreAnim.SetBool("PlusOne", true);

    }

    void SetFalse()
    {
        scoreAnim.SetBool("PlusOne", false);

    }


}
