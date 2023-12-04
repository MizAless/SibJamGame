using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyEnemyOnLoc : MonoBehaviour
{
    public GameObject door;

    private float NeedTime;
    private bool isEmpty = false;
    // Start is called before the first frame update
    void Start()
    {
        NeedTime = Time.time + 5f; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > NeedTime) 
        {
            door.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" || collision.tag == "Kamikaze")
        {
            isEmpty = false;
            NeedTime = Time.time + 5f;
        }
    }
}
