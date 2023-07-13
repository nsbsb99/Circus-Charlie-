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
        //백그라운드 왼쪽 이동 
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        //GameManager 생성 후 화면 뒤로 감기 만들기.
    }
}
