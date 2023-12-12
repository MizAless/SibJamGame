using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    public GameObject[] spawners = new GameObject[1];

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            for (int i = 0; i < spawners.Length; i++)
            {
                if(spawners[i].activeSelf == false)
                {
                    spawners[i].SetActive(true);
                }
                
            }
        }
    }
}
