using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage = 20;
    private float startTime = 0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Time.time > startTime + 1f)
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
            startTime = Time.time;
        }
    }
}
