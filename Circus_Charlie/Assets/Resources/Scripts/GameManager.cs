using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameOver = false;
    public Text scoreText;
    //게임 오버 시 내보낼 UI
    public GameObject gameoverUI;

    private int score = 0;

    private void Awake()
    {
        //게임매니저 배정
        if (instance == null)
        {
            instance = this;
        }

        //중복 시 게임매니저 하나 파괴
        else
        {
            Debug.LogWarning("이미 게임매니저가 존재합니다!");
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //게임 오버를 체크하고 다음 게임을 시작할 수 있도록 하는 처리 
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
