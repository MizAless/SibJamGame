using System.Collections;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 10.0f;
    public float fireRate = 2f; // �������� �������� � ��������� � �������

    private float nextFireTime;

    void Update()
    {
        // �������� �� ������� ������ �������� � ����������� ������� ���������
        if (Input.GetButtonDown("Fire1") && Time.time > nextFireTime)
        {
            // �������� �������
            Shoot();

            // ��������� ������� ���������� ���������� ��������
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
    {
        // �������� ������� �� �������
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        // ����������� �������� ������� (������)
        Vector2 bulletDirection = bulletSpawnPoint.right;

        // ���������� �������� �������� �������
        bullet.GetComponent<Rigidbody2D>().velocity = bulletDirection * bulletSpeed;
    }
}
