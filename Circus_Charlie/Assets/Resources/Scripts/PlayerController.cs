using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEditor.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRigid = default;
    private float jumpForce = 350f;
    private int jumpCount = 0;
    private bool isGrounded = false;
    public static bool isDead = false;
    private Animator animator;
    public static int playerHP = 4;
    private bool playerNotHere = false;

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
        //플레이어 죽음시 스크립트 종료
        if(isDead == true)
        {
            return;
        }

        //플레이어가 화면 밖으로 밀려날 시 죽음 처리
        if (this.transform.position.x < -8)
        {
            playerNotHere = true;
            Die();
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        //만약 불에 닿았고 아직 죽지 않았다면
        if(other.tag == "Fire" && isDead == false)
        {
            //플레이어 HP 하나 깎기
            playerHP--;
       
            FindObjectOfType<WhatPlayerHP>().RemovePlayerHP();
        }

        //만약 불을 건너뛰었고 아직 죽지 않았다면
        if(other.tag == "Score" && isDead == false)
        {
            //점수 200점 획득
            GameManager.playerScore += 200;
        }

        //HP가 0이하라면 죽음 전달
        if(playerHP <=0)
        {
            isDead = true;
            Die();
        }
    }

    private void Die()
    {
        if(playerNotHere == true)
        {
            isDead = true;
        }

        //플레이어의 HP가 0이거나 카메라 밖으로 벗어났다면
        if (isDead == true)
        {
            animator.SetTrigger("Die");

            playerRigid.velocity = Vector2.zero;

           
            //게임매니저에 플레이어의 게임오버 전달
            GameManager.instance.OnplayerDead(); //NullReferenceException 오류
            //2. FindObjectOfType<GameManager>().OnplayerDead();  
        }

    }

}
