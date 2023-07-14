using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    private float width;

    private void Awake()
    {
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        width = boxCollider.size.x; //'8' ����

        //Debug.LogFormat("��� ������: {0}", width);
    }

    // Update is called once per frame
    void Update()
    {
      if(transform.position.x <= -(width * 1.5) && PlayerController.isDead == false)
        {
            //Debug.Log("��׶��� �Ѱ� �ʰ�");

            Reposition();
        }
    }

    private void Reposition()
    {
        Vector2 offset = new Vector2 (width * 4f, 0);
        //transform.position�� Vector3 �����̶� Vector2���� ����ȯ�� �ʿ��ϴ�.
        transform.position = (Vector2) transform.position + offset;
    }
}
