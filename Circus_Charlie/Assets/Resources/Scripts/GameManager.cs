using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameOver = false;
    public Text scoreText;
    //���� ���� �� ������ UI
    public GameObject gameoverUI;

    private int score = 0;

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
    }

    // Update is called once per frame
    void Update()
    {
        //���� ������ üũ�ϰ� ���� ������ ������ �� �ֵ��� �ϴ� ó�� 
    }

    public void AddScore(int newScore)
    {
        if(!isGameOver)
        {
            score += newScore;
            scoreText.text = "-" + score;
        }
    }

    public void OnplayerDead()
    {
        isGameOver = true;
        gameoverUI.SetActive(true);
    }


}
