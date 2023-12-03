using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    public GameObject bulletPrefab;
    public float bulletSpeed = 10.0f;
    public float fireRate = 1f; // �������� �������� � ��������� � �������

    private GameObject Player;

    private float nextFireTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        Vector3 direction = Player.transform.position - transform.position;
        direction.Normalize();

        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFireTime)
        {
            // �������� �������
            Shoot();

            // ��������� ������� ���������� ���������� ��������
            nextFireTime = Time.time + 1f / fireRate;
        }
    }
}
