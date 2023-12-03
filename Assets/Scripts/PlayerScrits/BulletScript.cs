using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private float damage;
    private float flyDistance;
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        damage = PlayerPrefs.GetFloat("HeroDamage");
        flyDistance = PlayerPrefs.GetFloat("DistanceProjectile");
    }

    public void StatsUpgrade()
    {
        damage = PlayerPrefs.GetFloat("HeroDamage");
        flyDistance = PlayerPrefs.GetFloat("DistanceProjectile");
        //Debug.Log(damage);
        Debug.Log(flyDistance);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, startPos) > flyDistance)
        { 
            Destroy(gameObject);    
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage((int)damage);
            Destroy(gameObject);
        }

        if (collision.tag == "Kamikaze")
        {
            collision.gameObject.GetComponent<KamikazeHealth>().TakeDamage((int)damage);
            Destroy(gameObject);
        }
    }
}
