using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeHealth : MonoBehaviour
{
    public int health = 100;
    public int epxAfterDeath = 0;

    private LevelSystem levelSystem;
    public GameObject Explosion;
    // Start is called before the first frame update
    private void Awake()
    {
        levelSystem = GameObject.FindWithTag("Player").GetComponent<LevelSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        levelSystem.AddExp(epxAfterDeath);
        //Debug.Log(levelSystem.level.Expirience);
        Destroy(gameObject);
        Instantiate(Explosion, transform.position, Quaternion.identity);

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            health = 0;
        }
    }
}
