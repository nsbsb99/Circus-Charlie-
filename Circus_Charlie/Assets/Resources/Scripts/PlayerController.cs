using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D playerRigid = default;
    private float jumpForce = 370f;
    private int jumpCount = 0;
    private bool isGrounded = false;
    private bool isDead = false;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
        Debug.Assert(playerRigid != null);
        Debug.Assert(animator != null);
    }

    // Update is called once per frame
    void Update()
    {
        //��� �� ����
        if(isDead == true)
        {
            return;
        }

        //������ ���� �ڵ� 
        if (Input.GetMouseButtonDown(0) && jumpCount < 1)
        {
            jumpCount += 1;
            playerRigid.velocity = Vector2.zero;
            playerRigid.AddForce(new Vector2(0, jumpForce));
        }

        else if (Input.GetMouseButtonDown(0) && playerRigid.velocity.y > 0)
        {
            playerRigid.velocity = playerRigid.velocity * 0.2f;
        }

        //���� ��� ���� ������ �˷� ���� ���·� ���� 
        animator.SetBool("Grounded", isGrounded);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //���� ī��Ʈ �ʱ�ȭ
        if (0.7f < collision.contacts[0].normal.y)
        {
            //���� �ٽ� ������ ���� ������� �˸��� ����ī��Ʈ �ʱ�ȭ
            isGrounded = true;
            jumpCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
