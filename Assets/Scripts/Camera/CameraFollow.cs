using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerTransform;
    private string playerTag;
    private float speedCamera = 3;

    private void Awake()
    {
        playerTag = "Player";
        playerTransform = GameObject.FindGameObjectWithTag(playerTag).transform;

        transform.position = new Vector3()
        {
            x = playerTransform.position.x,
            y = playerTransform.position.y,
            z = playerTransform.position.z - 10,
        };
    }

    private void Update()
    {
        
        if (playerTransform != null)
        {
            //Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);



            //Vector3 target = new Vector3()
            //{
            //    x = (playerTransform.position.x + cursorPosition.x) / 2f,
            //    y = (playerTransform.position.y + cursorPosition.y) / 2f,
            //    z = playerTransform.position.z - 10,
            //};

            Vector3 target = new Vector3()
            {
                x = playerTransform.position.x,
                y = playerTransform.position.y,
                z = playerTransform.position.z - 10,
            };

            //if (target.x - cursorPosition.x > 3)
            //{
            //    target.x = playerTransform.position.x + 3;
            //}
            //if (target.x - cursorPosition.x < -3)
            //{
            //    cursorPosition.x = playerTransform.position.x - 3;
            //}
            //if (target.y - cursorPosition.y < -3)
            //{
            //    cursorPosition.y = playerTransform.position.y - 3;
            //}
            //if (target.y - cursorPosition.y > 3)
            //{
            //    cursorPosition.y = playerTransform.position.y + 3;
            //}

            Vector3 pos = Vector3.Lerp(transform.position, target, speedCamera * Time.deltaTime);
            transform.position = pos;

        }
    }

}
