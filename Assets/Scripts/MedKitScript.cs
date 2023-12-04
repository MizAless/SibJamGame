using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKitScript : MonoBehaviour
{
    public int heal = 50;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().Heal(heal);
            Destroy(gameObject);
        }
    }
}
