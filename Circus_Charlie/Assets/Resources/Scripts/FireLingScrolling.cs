using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLingScrolling : MonoBehaviour
{
    private float speed = 4f;

    // Update is called once per frame
    public void Update()
    {
        if (PlayerController.isDead == false && GameManager.clickRight == false)
        {
            //�Ҳɸ� ��������
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        if (PlayerController.isDead == false && GameManager.clickRight == true)
        {
            //������ ���콺 ��ư Ŭ�� �� ����������
            transform.Translate(Vector2.right * (speed / 2) * Time.deltaTime);
        }
    }
}
