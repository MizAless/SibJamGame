using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5f;

    private GameObject Player;

    private Rigidbody2D Rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 directionToPlayer = (Player.transform.position - transform.position).normalized;
        transform.position += directionToPlayer * speed * Time.deltaTime;
    }
}
