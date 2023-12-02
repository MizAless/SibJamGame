using System.Collections;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 10.0f;
    public float fireRate = 2f; // Скорость стрельбы в выстрелах в секунду

    private float nextFireTime;

    void Update()
    {
        // Проверка на нажатие кнопки стрельбы и ограничение частоты выстрелов
        if (Input.GetButtonDown("Fire1") && Time.time > nextFireTime)
        {
            // Создание снаряда
            Shoot();

            // Установка времени следующего возможного выстрела
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
    {
        // Создание снаряда из префаба
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        // Направление движения снаряда (вперед)
        Vector2 bulletDirection = bulletSpawnPoint.right;

        // Назначение скорости движения снаряда
        bullet.GetComponent<Rigidbody2D>().velocity = bulletDirection * bulletSpeed;
    }
}
