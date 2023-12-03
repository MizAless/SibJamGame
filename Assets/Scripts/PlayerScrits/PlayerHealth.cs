using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerHealth : MonoBehaviour
{
    public float health { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        health = PlayerPrefs.GetFloat("MaxHP");
    }

    public void StatsUpgrade()
    {
        health = PlayerPrefs.GetFloat("MaxHP") - (PlayerPrefs.GetFloat("MaxHP") - health);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
        //print(health);
    }

    private void Die()
    {
        //print("Die");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Explosion")
        {
            TakeDamage(50);
        }
    }
}
