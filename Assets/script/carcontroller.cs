using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carcontroller : MonoBehaviour
{
    public float moveSpeed;
    bool faceLeft, firsttab;

  

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.isGameStarted)
        {
            Move();
            CheckInput();
        }
        if(transform.position.y<=-2)
        {
            GameManager.Instance.GameOver();
        }
        
    }
    void Move()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }//move
    void CheckInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ChangeDir();
        }
    }// checkinput
    void ChangeDir()
    {
        if (faceLeft)
        {
            faceLeft = false;
            transform.rotation = Quaternion.Euler(0,90,0);
        }
        else
        {
            faceLeft = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
