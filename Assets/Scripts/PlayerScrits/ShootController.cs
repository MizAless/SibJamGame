using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletSpeed;
    public float fireRate; // �������� �������� � ��������� � �������
    public int projCount;


    private float nextFireTime = 0;

    void Start()
    {
        fireRate = PlayerPrefs.GetFloat("RateOfBullet");
        bulletSpeed = PlayerPrefs.GetFloat("SpeedProjectile");
        projCount = (int)PlayerPrefs.GetFloat("CountProjectile");
}

    public void StatsUpgrade()
    {
        fireRate = PlayerPrefs.GetFloat("RateOfBullet");
        bulletSpeed = PlayerPrefs.GetFloat("SpeedProjectile");
        projCount = (int)PlayerPrefs.GetFloat("CountProjectile");
        //Debug.Log(fireRate);
        //Debug.Log(projCount);
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

        List<GameObject> bulletList = new List<GameObject> { };
        var count = (int)PlayerPrefs.GetFloat("CountProjectile");
        for (int i = 0; i < count; i++)
        {
            int step = (count % 2 == 0) ? 10 : 5;
            // ��������� ���� ���������� ��� ������ ����
            float deviationAngle = (int)(count / 2) * -5 + step * i;

            // ������� ����
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bulletList.Add(bullet);

            // �������� ����������� ���� � ������ ���� ����������
            Vector2 bulletDirection = Quaternion.Euler(0, 0, deviationAngle) * bulletSpawnPoint.right;

            // ������������� ����������� �������� ����
            bullet.GetComponent<Rigidbody2D>().velocity = bulletDirection * bulletSpeed;
        }


    }
}
