using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeHealth : EnemyHealth
{
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
        Instantiate(Explosion, transform.position, Quaternion.identity);
        //Debug.Log(levelSystem.level.Expirience);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gameObject.GetComponent<EnemyHealth>().health = 0;
        }
    }
}
