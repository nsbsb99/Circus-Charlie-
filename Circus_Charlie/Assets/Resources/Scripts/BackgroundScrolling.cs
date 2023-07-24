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
        if (PlayerController.isDead == false && GameManager.clickRight == false
            && GameManager.instance.lastGoal == false)
        {
            //백그라운드 왼쪽 이동 
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        if(PlayerController.isDead == false && GameManager.clickRight == true
            && GameManager.instance.lastGoal == false)
        {
            //만약 마우스 오른쪽 버튼을 누른다면 화면 다시 감기
            WantBack();
        }
    }

    public void WantBack()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
