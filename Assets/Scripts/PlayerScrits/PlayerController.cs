using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //private float speed;
    //public float speed = PlayerPrefs.GetInt("HeroSpeed");
    public GameObject MenuPause;
    private Vector3 moveVector;
    private Animator animator;
    public AudioSource audioFootsteps;
    public Transform WeaponHolder;

    // —мещение оружи€ относительно курсора
    public Vector2 weaponOffset = new Vector2(0.5f, 0.5f);

    // ”правление скоростью движени€ оружи€
    public float weaponMoveSpeed = 5f;



    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().enabled = true;
        Time.timeScale = 1;
        //PlayerPrefs.DeleteAll();
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.y = Input.GetAxis("Vertical");

        transform.position += moveVector * PlayerPrefs.GetFloat("HeroSpeed") * Time.deltaTime;

        if (Input.GetKey("escape"))
        {
            MenuPause.SetActive(true);
        }


            if (moveVector.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            GameObject.Find("WeaponHolder").transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
            GameObject.Find("WeaponHolder").transform.localScale = new Vector3(-1, 1, 1);
        }

        if (moveVector.x != 0 || moveVector.y != 0)
        {
            animator.SetBool("IsWalking", true);
            if(audioFootsteps.isPlaying == false)
            {
                audioFootsteps.Play();
            }
            
        }
        else
        {
            animator.SetBool("IsWalking", false);
            if (audioFootsteps.isPlaying == true)
            {
                audioFootsteps.Stop();
            }
        }

        //-----------------------------------------------------------------------------------


        // ѕолучение позиции курсора в мировых координатах
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        // ¬ычисление направлени€ курсора относительно WeaponHolder
        Vector3 direction = cursorPosition - transform.position;
        direction.Normalize();

        // ¬ычисление угла поворота и применение его к WeaponHolder
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        WeaponHolder.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);




    }

}
