using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Level
{

    private TMP_Text textCountOfPoints;

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

    public void LevelUp()
    {
        ValueLvl++;
    }

    private void AddPoint()
    {
        Point++;
        textCountOfPoints = GameObject.Find("CountOfPoints").GetComponent<TMP_Text>();
        textCountOfPoints.text = Convert.ToString("Points: " + Point);
    }

    public void AddExp(int exp)
    {
        Expirience += exp;
        ValueLvl = Expirience / NeedExpLvl;
        ExpOnLvl = Expirience % NeedExpLvl;
        for(int i = ValueLvl - LastValueLvl; i > 0; i--)
        {
            AddPoint();
        }
        LastValueLvl = ValueLvl;
    }


}

public class LevelSystem : MonoBehaviour
{
    public Level level;
    //public GameObject Indikator;
    //public GameObject Fire;
    //public GameObject LevelText;
    //public Animator CamAnimator;

    // Start is called before the first frame update
    void Awake()
    {
        level = new Level(0, 0, 500);
        
    }

    // Update is called once per frame
    void Update()
    {
        //level.AddExp((int)(UnityEngine.Random.Range(0, 5000) * Time.deltaTime));
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

        //LevelText.GetComponent<TextMesh>().text = "Level - " + level.ValueLvl.ToString();
        Debug.Log(level.ValueLvl);
        Debug.Log(level.Expirience);
    }
}

//public class LevelSystem : MonoBehaviour
//{
//    //private Level level;
//    //public GameObject Indikator;
//    //public GameObject Fire;
//    //public GameObject LevelText;
//    //public Animator CamAnimator;

//    // Start is called before the first frame update
//    void Start()
//    {
//        level = new Level(0, 0, 500);   
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        level.AddExp((int)(Random.Range(0, 3000) * Time.deltaTime));
//        Indikator.transform.localScale = new Vector3(1, (float)level.ExpOnLvl / (float)level.NeedExpLvl);
//        var em = Fire.GetComponent<ParticleSystem>().emission;
//        var rate = em.rateOverTime;
//        if (rate.constant < 150.0f)
//        {
//            em.rateOverTime = level.ValueLvl * 2f;
//            var shape = Fire.GetComponent<ParticleSystem>().shape;
//            shape.radius = 0.3f + (float)level.ValueLvl * 0.012f;
//        }

//        if (level.ValueLvl > 100)
//        {
//            CamAnimator.SetBool("IsShake", true);
//        }

//        LevelText.GetComponent<TextMesh>().text = "Level - " + level.ValueLvl.ToString();
//        print(level.ValueLvl);
//        print(level.Expirience);
//    }
//}


