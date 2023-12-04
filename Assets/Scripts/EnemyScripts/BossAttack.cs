using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    private bool isAttack;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public int bulletCount = 36;
    private float startAttackTime;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        isAttack = false;
        startAttackTime = 0;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttack) 
        {
            if (Time.time > startAttackTime + 1f)
            {
                Attack();
            }
        }
    }

    public void StartAttack() 
    {
        startAttackTime = Time.time;
        isAttack = true;
        animator.SetBool("IsAttack", true);
    }

    private void Attack()
    {
        List<GameObject> bulletList = new List<GameObject> { };
        float step = 360f / (float)bulletCount;
        for (int i = 0; i < bulletCount; i++)
        {
            // ¬ычисл€ем угол отклонени€ дл€ каждой пули
            float deviationAngle = step * i;

            // —оздаем пулю
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bulletList.Add(bullet);

            // ѕолучаем направление пули с учетом угла отклонени€
            Vector2 bulletDirection = Quaternion.Euler(0, 0, deviationAngle) * transform.right;

            // ”станавливаем направление движени€ пули
            bullet.GetComponent<Rigidbody2D>().velocity = bulletDirection * bulletSpeed;
        }
        isAttack = false;
        animator.SetBool("IsAttack", false);
    }

    public bool IsAttack() 
    {
        return isAttack;
    }

}
