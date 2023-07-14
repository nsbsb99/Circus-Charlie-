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
        //�÷��̾� ������ ��ũ��Ʈ ����
        if(isDead == true)
        {
            return;
        }

        //�÷��̾ ȭ�� ������ �з��� �� ���� ó��
        if (this.transform.position.x < -8)
        {
            playerNotHere = true;
            Die();
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        //���� �ҿ� ��Ұ� ���� ���� �ʾҴٸ�
        if(other.tag == "Fire" && isDead == false)
        {
            //�÷��̾� HP �ϳ� ���
            playerHP--;
       
            FindObjectOfType<WhatPlayerHP>().RemovePlayerHP();
        }

        //���� ���� �ǳʶپ��� ���� ���� �ʾҴٸ�
        if(other.tag == "Score" && isDead == false)
        {
            //���� 200�� ȹ��
            GameManager.playerScore += 200;
        }

        //HP�� 0���϶�� ���� ����
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

        //�÷��̾��� HP�� 0�̰ų� ī�޶� ������ ����ٸ�
        if (isDead == true)
        {
            animator.SetTrigger("Die");

            playerRigid.velocity = Vector2.zero;

           
            //���ӸŴ����� �÷��̾��� ���ӿ��� ����
            GameManager.instance.OnplayerDead(); //NullReferenceException ����
            //2. FindObjectOfType<GameManager>().OnplayerDead();  
        }

    }

}
