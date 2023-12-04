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
        Point = 0;
        LastValueLvl = value;
    }

    private void AddPoint()
    {
        Point++;
        textCountOfPoints = GameObject.Find("CountOfPoints").GetComponent<TMP_Text>();
        textCountOfPoints.text = Convert.ToString(Point);
    }

    private void AddLevel()
    {

        textLevelIndicator = GameObject.Find("IndicatorLevelText").GetComponent<TMP_Text>();
        textLevelIndicator.text = Convert.ToString("Level: " + ValueLvl);
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
    public float XpLineSpeed = 0.5f;
    //public Animator CamAnimator;

    private float ExpBuffer;
    private float PartExp;

    private int RageLevel = 0;
    //private float nextTime;

    // Start is called before the first frame update
    void Awake()
    {
        level = new Level(1, 1500, 1500);
        LineXpImage.fillAmount = 0;
    }

    public void AddExp(int exp)
    {
        level.AddExp(exp);
        ExpBuffer += exp;
        PartExp = ExpBuffer * XpLineSpeed;
    }

    public void UpdateXPBarValue()
    {
        float coef = (float)level.ExpOnLvl / (float)level.NeedExpLvl;
        LineXpImage.fillAmount = coef;
    }

    public void SmoothUpdateIndikator()
    {
        var deltaTime = Time.deltaTime;
        if (ExpBuffer > 0)
        {
            ExpBuffer -= PartExp * deltaTime;
            var coef = PartExp * deltaTime / (float)level.NeedExpLvl;
            LineXpImage.fillAmount += coef;
            if (LineXpImage.fillAmount >= 1) LineXpImage.fillAmount = LineXpImage.fillAmount % 1f;
        }
        
    }

    public void FireIntens()
    {
        RageLevel = (int)(ExpBuffer % 2000f);
        if (RageLevel > 5) RageLevel = 5;

        var em = Fire.GetComponent<ParticleSystem>().emission;
        //var rate = em.rateOverTime;
        em.rateOverTime = RageLevel * 20f;
        var shape = Fire.GetComponent<ParticleSystem>().shape;
        shape.radius = 0.3f + RageLevel * 0.2f;
        

        //if (level.ValueLvl > 100)
        //{
        //    CamAnimator.SetBool("IsShake", true);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        SmoothUpdateIndikator();
        FireIntens();
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


