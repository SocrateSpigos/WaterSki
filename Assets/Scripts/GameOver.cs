using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject winner;
    public GameObject gameOver;
    public GameObject splash;
    public GameObject victory1;
    public GameObject victory2;
    public GameObject victory3;

    public void Start()
    {
        
    }

    public void Update()
    {
        if (splash.activeInHierarchy)
        {
            StartCoroutine(WaitForGameOver());
        }


        if (victory1.activeInHierarchy || victory2.activeInHierarchy || victory3.activeInHierarchy )
        {
            StartCoroutine(WaitForWinner());
        }
    }



    public void RestartButton()
    {
        SceneManager.LoadScene("SharkAttack");
    }
    
    public void RestartButton2()
    {
        SceneManager.LoadScene("WaterSki2");
    }

    public void Continue()
    {
        SceneManager.LoadScene("WaterSki2");

    }

    IEnumerator WaitForGameOver()
    {
        yield return new WaitForSeconds(1);
        gameOver.SetActive(true);

    }

    IEnumerator WaitForWinner()
    {
        yield return new WaitForSeconds(5);
        winner.SetActive(true);

    }

}
