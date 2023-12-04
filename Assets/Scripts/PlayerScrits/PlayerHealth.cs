using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using TMPro;
using System;
using Unity.Mathematics;

public class PlayerHealth : MonoBehaviour
{
    public float health { get; private set; }
    private float MaxHp;
    public GameObject DeathScreen;
    public Image hpBarImage;
    public TMP_Text textHpBar;
    // Start is called before the first frame update
    void Start()
    {
        MaxHp = PlayerPrefs.GetFloat("MaxHP");
        health = MaxHp;
    }

    public void StatsUpgrade()
    {
        var PrevMax = MaxHp;
        MaxHp = PlayerPrefs.GetFloat("MaxHP");


        health *= (float)MaxHp / (float)PrevMax;
        health = (int)health;
        UpdateHPBarValue();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateHPBarValue()
    {
        float coef = health / MaxHp;
        hpBarImage.fillAmount = coef;
        textHpBar.text = Convert.ToString(health + " / " + MaxHp);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        UpdateHPBarValue();
        if (health <= 0)
        {
            Die();
        }
        //print(health);
    }

    public void Heal(int heal)
    {
        health += heal;
        if (health > MaxHp)
        {
            health = MaxHp;
        }
        UpdateHPBarValue();
    }


    private void Die()
    {
        if (!DeathScreen.activeSelf)
        {
            Time.timeScale = 0;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().enabled = false;
            DeathScreen.SetActive(true);
            //PlayerPrefs.SetFloat("HeroSpeed", 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Explosion")
        {
            TakeDamage(50);
        }
    }
}
