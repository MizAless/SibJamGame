using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public float speed = 5f;

    private GameObject Player;

    private Rigidbody2D Rigidbody;

    private bool IsWalking = true;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsWalking)
        {
            if (Vector2.Distance(transform.position, Player.transform.position) > 10)
            {
                speed = 30f;
            }
            else if (Vector2.Distance(transform.position, Player.transform.position) > 5)
            {
                speed = 8;
            }
            else
            {
                speed = 0;
            }

            Vector3 directionToPlayer = (Player.transform.position - transform.position).normalized;
            if (directionToPlayer.x < 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }

            transform.position += directionToPlayer * speed * Time.deltaTime;
        }
    }
}
