using System.Collections;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletSpeed;
    public float fireRate; // �������� �������� � ��������� � �������

    private float nextFireTime = 0;

    void Start()
    {
        fireRate = PlayerPrefs.GetFloat("RateOfBullet");
        bulletSpeed = PlayerPrefs.GetFloat("SpeedProjectile");
    }

    public void StatsUpgrade()
    {
        fireRate= PlayerPrefs.GetFloat("RateOfBullet");
        bulletSpeed = PlayerPrefs.GetFloat("SpeedProjectile");
        //Debug.Log(fireRate);
        //Debug.Log(bulletSpeed);
    }

    void Update()
    {
        // �������� �� ������� ������ �������� � ����������� ������� ���������
        if (Input.GetButton("Fire1") && Time.time > nextFireTime)
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
