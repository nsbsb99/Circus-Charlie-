using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    private float speed = 3f;

    // Update is called once per frame
    public void Update()
    {
        if (PlayerController.isDead == false && GameManager.clickRight == false)
        {
            //백그라운드 왼쪽 이동 
            transform.Translate(Vector2.left * speed * Time.deltaTime);

            //GameManager 생성 후 화면 뒤로 감기 만들기.
        }

        if(PlayerController.isDead == false && GameManager.clickRight == true)
        {
            WantBack();
        }
    }

    public void WantBack()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
