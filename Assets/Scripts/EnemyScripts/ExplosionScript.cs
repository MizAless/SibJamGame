using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    public float IncSizeSpeed = 5f;
    public float LifeTime = 0.5f;
    public int damage = 50;

    private GameObject Player;
    private bool IsDamaged;

    //private Color color;
    private float startTime;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        //color = new Color(255, 255, 0);
        //gameObject.GetComponent<SpriteRenderer>().color = color;
        startTime = Time.time;
        IsDamaged = false;
    }

    void Update()
    {
        var incSize = IncSizeSpeed * Time.deltaTime;
        transform.localScale += new Vector3(incSize, incSize);
        if (Time.time > startTime + LifeTime)
        {
            Destroy(gameObject);
        }

        if (Vector2.Distance(transform.position, Player.transform.position) < transform.localScale.x - 1 && !IsDamaged)
        {
            Player.GetComponent<PlayerHealth>().TakeDamage(damage);
            IsDamaged = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.tag == "Player")
        //{
        //    collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        //    //print("Hit");
        //}
        if (collision.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
    }
}
