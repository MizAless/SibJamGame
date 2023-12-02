using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    [SerializeField] private TMP_Text text_level;

    public string skill;
    public int upgradeLimit;
    public float value;
    public LevelSystem levelSystem;
    int currentUpgrade = 1;

    void Start()
    {
        PlayerPrefs.SetFloat("HeroSpeed", 5);
    }

    private void Awake()
    {;
        levelSystem = GameObject.FindWithTag("Player").GetComponent<LevelSystem>();
    }

    public void ProductUpgrade() {

        float count = PlayerPrefs.GetFloat(skill);
        

        if (levelSystem.level.Point > 0 && currentUpgrade < upgradeLimit) {
            PlayerPrefs.SetFloat(skill, count + value);
            levelSystem.level.Point--;
            currentUpgrade++;
            if(currentUpgrade == upgradeLimit) 
            {
                text_level.text = "MAX";
            } else
            {
                text_level.text = Convert.ToString(currentUpgrade);
            }
            
        }
        Debug.Log(currentUpgrade);
        Debug.Log(levelSystem.level.Point); 
    }
}
