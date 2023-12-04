using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    [SerializeField] private TMP_Text levelSkillText;
    private TMP_Text textCountOfPoints;

    public string skill;
    public int upgradeLimit;
    public float value;
    private LevelSystem levelSystem;
    public int currentUpgrade = 1;
    public bool isUpgrade = false;

    void Start()
    {
        PlayerPrefs.SetFloat("HeroSpeed", 5f);
        PlayerPrefs.SetFloat("MaxHP", 100f);
        PlayerPrefs.SetFloat("RateOfBullet", 0.5f);
        PlayerPrefs.SetFloat("HeroDamage", 10f);
        PlayerPrefs.SetFloat("SpeedProjectile", 10f);
        PlayerPrefs.SetFloat("DistanceProjectile", 5f);
        PlayerPrefs.SetFloat("CountProjectile", 1f);
        textCountOfPoints.text = Convert.ToString(levelSystem.level.Point);
    }

    private void Awake()
    {
        textCountOfPoints = GameObject.Find("CountOfPoints").GetComponent<TMP_Text>();
        levelSystem = GameObject.FindWithTag("Player").GetComponent<LevelSystem>();
    }

    public void ProductUpgrade() {

        float count = PlayerPrefs.GetFloat(skill);
        

        if (levelSystem.level.Point > 0 && currentUpgrade < upgradeLimit) {
            PlayerPrefs.SetFloat(skill, count + value);
            levelSystem.level.Point--;
            currentUpgrade++;
            textCountOfPoints.text = Convert.ToString(levelSystem.level.Point);
            if (currentUpgrade == upgradeLimit) 
            {
                levelSkillText.text = "MAX";
            } else
            {
                levelSkillText.text = Convert.ToString(currentUpgrade);
            }
            
        }
        //Debug.Log(currentUpgrade);
        //Debug.Log(levelSystem.level.Point); 
    }
}
