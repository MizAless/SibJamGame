using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public string skill;
    int point = 10;

    public void productUpgrade() {
        if(point > 0) {
            int count = PlayerPrefs.GetInt(skill);
            PlayerPrefs.SetInt(skill, count + 1);
            point--;
        }
        Debug.Log(PlayerPrefs.GetInt(skill));
    }
}
