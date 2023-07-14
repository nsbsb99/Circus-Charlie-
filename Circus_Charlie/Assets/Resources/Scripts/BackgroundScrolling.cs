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
            //��׶��� ���� �̵� 
            transform.Translate(Vector2.left * speed * Time.deltaTime);

            //GameManager ���� �� ȭ�� �ڷ� ���� �����.
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
