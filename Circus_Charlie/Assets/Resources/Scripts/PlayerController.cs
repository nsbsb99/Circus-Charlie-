using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region ���� ���� ����
    //���� ����
    private Rigidbody2D playerRigid = default;
    private float jumpForce = 350f;
    private int jumpCount = 0;
    private bool isGrounded = false;
    //���� ����
    public static bool isDead = false;
    //�ִϸ��̼�
    private Animator animator;
    //�÷��̾�HP
    public static int playerHP = 4;
    //�÷��̾ �з����� ���� ó��
    private bool playerNotHere = false;
    //�� ���� ��� ����
    [HideInInspector] public static bool gotGoal = false;
    //������ ��׶��� ���� ����
    private bool finishGoal = false;
    //�ð� ���������� �ð�
    private float stopTime = 0f;

    private float speed = 2.5f;
    #endregion

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
        if (isDead == true)
        {
            return;
        }

        //�÷��̾ ȭ�� ������ �з��� �� ���� ó��
        if (this.transform.position.x < -8)
        {
            playerNotHere = true;
            Die();
        }

        //������ ��׶��忡 ���� �� 
        //���������� �̵� 
        if (GameManager.instance.lastGoal == true && transform.localPosition.x < 230)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        //�� �������� 3�ʰ� �����ٸ�
        if(finishGoal == true && stopTime >= 3f)
        {
            GameManager.instance.GotGoal();
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

        //���� ����ְ� �� �ٴٶ��ٸ� ���� ����������
        if (isDead == false && collision.transform.tag == "Goal")
        {
            stopTime += Time.deltaTime;

            gotGoal = true;
            finishGoal = true;
            animator.SetBool("Goal", finishGoal);

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //���� �ҿ� ��Ұ� ���� ���� �ʾҴٸ�
        if (other.tag == "Fire" && isDead == false)
        {
            //�÷��̾� HP �ϳ� ���
            playerHP--;

            FindObjectOfType<WhatPlayerHP>().RemovePlayerHP();
        }

        //���� ���� �ǳʶپ��� ���� ���� �ʾҴٸ�
        if (other.tag == "Score" && isDead == false)
        {
            //���� 200�� ȹ��
            GameManager.playerScore += 200;
        }

        //HP�� 0���϶�� ���� ����
        if (playerHP <= 0)
        {
            isDead = true;
            Die();
        }
    }

    private void Die()
    {
        if (playerNotHere == true)
        {
            isDead = true;
        }

        //�÷��̾��� HP�� 0�̰ų� ī�޶� ������ ����ٸ�
        if (isDead == true)
        {
            animator.SetTrigger("Die");

            playerRigid.velocity = Vector2.zero;

            //���ӸŴ����� �÷��̾��� ���ӿ��� ����
            GameManager.instance.OnplayerDead();
        }

    }

}
