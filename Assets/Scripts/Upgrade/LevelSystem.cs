using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Level
{

    private TMP_Text textCountOfPoints;
    private TMP_Text textLevelIndicator;

    public int ValueLvl { get; private set; }
    public int Expirience { get; private set; }

    public int NeedExpLvl { get; private set; }

    public int ExpOnLvl { get; private set; }

    public int Point { get; set; }
    private int LastValueLvl;


    public Level(int value, int expirience, int needExpLvl)
    {
        ValueLvl = value;
        Expirience = expirience;
        NeedExpLvl = needExpLvl;
        Point = value;
        LastValueLvl = value;
    }

    private void AddPoint()
    {
        Point++;
        textCountOfPoints = GameObject.Find("CountOfPoints").GetComponent<TMP_Text>();
        textCountOfPoints.text = Convert.ToString("Points: " + Point);
    }

    private void AddLevel()
    {

        textLevelIndicator = GameObject.Find("IndicatorLevelText").GetComponent<TMP_Text>();
        textLevelIndicator.text = Convert.ToString("Level: " + Point);
    }

    public void AddExp(int exp)
    {
        Expirience += exp;
        ValueLvl = Expirience / NeedExpLvl;
        ExpOnLvl = Expirience % NeedExpLvl;
        for(int i = ValueLvl - LastValueLvl; i > 0; i--)
        {
            AddPoint();
            AddLevel();
        }
        LastValueLvl = ValueLvl;
    }


}

public class LevelSystem : MonoBehaviour
{
    public Level level;
    //public GameObject Indikator;
    public GameObject Fire;
    public Image LineXpImage;
    //public Animator CamAnimator;

    // Start is called before the first frame update
    void Awake()
    {
        level = new Level(1, 0, 500);
        
    }

    public void UpdateXPBarValue()
    {
        float coef = (float)level.ExpOnLvl / (float)level.NeedExpLvl;
        LineXpImage.fillAmount = coef;
    }

    // Update is called once per frame
    void Update()
    {
        //Indikator.transform.localScale = new Vector3(1, (float)level.ExpOnLvl / (float)level.NeedExpLvl);
        //var em = Fire.GetComponent<ParticleSystem>().emission;
        //var rate = em.rateOverTime;
        //if (rate.constant < 150.0f)
        //{
        //    em.rateOverTime = level.ValueLvl * 2f;
        //    var shape = Fire.GetComponent<ParticleSystem>().shape;
        //    shape.radius = 0.3f + (float)level.ValueLvl * 0.012f;
        //}

        //if (level.ValueLvl > 100)
        //{
        //    CamAnimator.SetBool("IsShake", true);
        //}

       // LevelText.GetComponent<TextMesh>().text = "Level - " + level.ValueLvl.ToString();
        //Debug.Log(level.ValueLvl);
        //Debug.Log(level.Expirience);
    }
}


