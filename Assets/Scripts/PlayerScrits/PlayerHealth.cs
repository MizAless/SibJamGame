using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using TMPro;
using System;

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
        health = PlayerPrefs.GetFloat("MaxHP") - (PlayerPrefs.GetFloat("MaxHP") - health);
        MaxHp = PlayerPrefs.GetFloat("MaxHP");
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

    private void Die()
    {
        if (!DeathScreen.activeSelf)
        {
            DeathScreen.SetActive(true);
            PlayerPrefs.SetFloat("HeroSpeed", 0);
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
