using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public bool isAttack;
    public GameObject bullet;
    public float bulletSpeed;
    private float startAttackTime;
    // Start is called before the first frame update
    void Start()
    {
        isAttack = false;
        startAttackTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartAttack() 
    {
        startAttackTime = Time.time;
    }

    public void Attack()
    {

    }

}
