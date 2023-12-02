using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 20;
    public int epxAfterDeath;
    private LevelSystem levelSystem;
    // Start is called before the first frame update
    void Start()
    {
        //health = 20;
    }
    private void Awake()
    {
        levelSystem = GameObject.FindWithTag("Player").GetComponent<LevelSystem>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            //levelSystem.level.AddExp(epxAfterDeath);
            //levelSystem.UpdateXPBarValue();
            levelSystem.level.AddExp(epxAfterDeath);
            levelSystem.UpdateXPBarValue();
            Debug.Log(levelSystem.level.Expirience);
            Destroy(gameObject);

        }
    }
}
