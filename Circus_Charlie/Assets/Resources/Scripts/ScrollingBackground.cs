using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    private float speed = 3f;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameOver == false)
        {
            //��׶��� ���� �̵� 
            transform.Translate(Vector2.left * speed * Time.deltaTime);

            //GameManager ���� �� ȭ�� �ڷ� ���� �����.
        }
    }
}
