using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{
    private GameObject MenuPause;

    private void Start()
    {
        MenuPause = GameObject.Find("MenuPause");
    }

    public void ResumeButton()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().enabled = true;
        Time.timeScale = 1;
        MenuPause.SetActive(false);
    }

    private void Update()
    {
            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().Stop();
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().enabled = false;
            Time.timeScale = 0;
        
    }
}
