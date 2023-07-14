using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //���� ���� �� ������ UI
    public GameObject gameOverUI;
    //��� UI �ؽ�Ʈ ����
    public TMP_Text bonusScoreText;
    public TMP_Text stageText;

    private int bonusScore = 5000;
    private float timer = 0f;

    private void Awake()
    {
        //���ӸŴ��� ����
        if (instance == null)
        {
            instance = this;
        }

        //�ߺ� �� ���ӸŴ��� �ϳ� �ı�
        else
        {
            Debug.LogWarning("�̹� ���ӸŴ����� �����մϴ�!");
            Destroy(gameObject);
        }

        Debug.Assert(GameManager.instance != null);

        //���������� �ؽ�Ʈ ���
        if(SceneManager.GetActiveScene().name == "Scene_One")
        {
            stageText.text = "STAGE-0" + 1;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //Ÿ�̸Ӹ� ����� 1�ʸ��� 
        timer += Time.deltaTime;

        if(timer >= 1f)
        {
            timer -= 1f;
            AddScore();
        }
    }


    public void AddScore()
    {
        //1�ʴ� Bonus Score 10 �谨
        if(PlayerController.isDead == false)
        {
            bonusScore -= 10;
   
            bonusScoreText.text = "-" + bonusScore;
        }
    }

    public void OnplayerDead()
    {
        gameOverUI.SetActive(true);
    }
}
