using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public AudioSource shootSource;
    public AudioClip[] shootsClips = new AudioClip[2];
    public Upgrade currentlvl;
    public int[] NeedLvl = new int[4];
    public float bulletSpeed;
    public float fireRate; // Скорость стрельбы в выстрелах в секунду
    public int projCount;


    private float nextFireTime = 0;

    void Start()
    {
        fireRate = PlayerPrefs.GetFloat("RateOfBullet");
        bulletSpeed = PlayerPrefs.GetFloat("SpeedProjectile");
        projCount = (int)PlayerPrefs.GetFloat("CountProjectile");
        shootSource.volume = 0.1f;
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
        for(int i = 0; i < NeedLvl.Length; i++)
        {
            if (NeedLvl[i] == currentlvl.currentUpgrade && shootSource.clip != shootsClips[i])
            {
                shootSource.clip = shootsClips[i];
            }
        }
        // Проверка на нажатие кнопки стрельбы и ограничение частоты выстрелов
        if (Input.GetButton("Fire1") && Time.time > nextFireTime)
        {
            // Создание снаряда
            Shoot();

            // Установка времени следующего возможного выстрела
            nextFireTime = Time.time + 1f / fireRate;
        }
    }



    void Shoot()
    {
        shootSource.Play();
        List<GameObject> bulletList = new List<GameObject> { };
        var count = (int)PlayerPrefs.GetFloat("CountProjectile");
        for (int i = 0; i < count; i++)
        {
            int step = (count % 2 == 0) ? 10 : 5;
            // Вычисляем угол отклонения для каждой пули
            float deviationAngle = (int)(count / 2) * -5 + step * i;

            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bulletList.Add(bullet);

            Vector2 bulletDirection = Quaternion.Euler(0, 0, deviationAngle) * bulletSpawnPoint.right;

            bullet.GetComponent<Rigidbody2D>().velocity = bulletDirection * bulletSpeed;
        }


    }
}
