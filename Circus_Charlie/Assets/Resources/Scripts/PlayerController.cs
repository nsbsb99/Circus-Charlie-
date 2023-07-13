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
        //사망 시 종료
        if(isDead == true)
        {
            return;
        }

        //점프를 위한 코드 
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

        //땅에 닿아 있지 않음을 알려 점프 상태로 변경 
        animator.SetBool("Grounded", isGrounded);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //점프 카운트 초기화
        if (0.7f < collision.contacts[0].normal.y)
        {
            //땅에 다시 붙으면 땅에 닿았음을 알리고 점프카운트 초기화
            isGrounded = true;
            jumpCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
