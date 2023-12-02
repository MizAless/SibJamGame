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
    int currentUpgrade = 1;

    void Start()
    {
        PlayerPrefs.SetFloat("HeroSpeed", 5);
        textCountOfPoints.text = Convert.ToString("Points: " + levelSystem.level.Point);
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
            textCountOfPoints.text = Convert.ToString("Points: " + levelSystem.level.Point);
            if (currentUpgrade == upgradeLimit) 
            {
                levelSkillText.text = "MAX";
            } else
            {
                levelSkillText.text = Convert.ToString(currentUpgrade);
            }
            
        }
        Debug.Log(currentUpgrade);
        Debug.Log(levelSystem.level.Point); 
    }
}
