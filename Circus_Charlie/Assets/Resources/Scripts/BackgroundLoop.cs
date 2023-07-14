using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    private float width;

    private void Awake()
    {
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        width = boxCollider.size.x; //'8' 찍힘

        //Debug.LogFormat("배경 사이즈: {0}", width);
    }

    // Update is called once per frame
    void Update()
    {
      if(transform.position.x <= -(width * 1.5) && PlayerController.isDead == false)
        {
            //Debug.Log("백그라운드 한계 초과");

            Reposition();
        }
    }

    private void Reposition()
    {
        Vector2 offset = new Vector2 (width * 4f, 0);
        //transform.position은 Vector3 형식이라 Vector2로의 형변환이 필요하다.
        transform.position = (Vector2) transform.position + offset;
    }
}
