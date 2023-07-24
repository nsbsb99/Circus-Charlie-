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
            //불꽃링 왼쪽으로
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        if (PlayerController.isDead == false && GameManager.clickRight == true)
        {
            //오른쪽 마우스 버튼 클릭 시 오른쪽으로
            transform.Translate(Vector2.right * (speed / 2) * Time.deltaTime);
        }
    }
}
