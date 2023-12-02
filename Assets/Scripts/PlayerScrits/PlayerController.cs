using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    private Vector3 moveVector;


    public Transform WeaponHolder;

    // �������� ������ ������������ �������
    public Vector2 weaponOffset = new Vector2(0.5f, 0.5f);

    // ���������� ��������� �������� ������
    public float weaponMoveSpeed = 5f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.y = Input.GetAxis("Vertical");

        transform.position += moveVector * speed * Time.deltaTime;




        //-----------------------------------------------------------------------------------

       
        // ��������� ������� ������� � ������� �����������
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // ���������� ����������� ������� ������������ WeaponHolder
        Vector3 direction = cursorPosition - transform.position;
        direction.Normalize();

        // ���������� ���� �������� � ���������� ��� � WeaponHolder
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        WeaponHolder.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        



    }
}
