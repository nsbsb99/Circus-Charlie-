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

    //게임 오버 시 내보낼 UI
    public GameObject gameOverUI;
    //출력 UI 텍스트 지정
    public TMP_Text bonusScoreText;
    public TMP_Text stageText;

    private int bonusScore = 5000;
    private float timer = 0f;

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

        Debug.Assert(GameManager.instance != null);

        //스테이지별 텍스트 출력
        if(SceneManager.GetActiveScene().name == "Scene_One")
        {
            stageText.text = "STAGE-0" + 1;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //타이머를 만들어 1초마다 
        timer += Time.deltaTime;

        if(timer >= 1f)
        {
            timer -= 1f;
            AddScore();
        }
    }


    public void AddScore()
    {
        //1초당 Bonus Score 10 삭감
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
