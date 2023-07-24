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
    //���� ��� �÷��̾� ���ھ�
    public static int playerScore = 0;
    //�÷��̾ �ڷ� �̵���Ű���� Ȯ��
    public static bool clickRight = false;
    //��� ���� ���� ���� miter ���ϱ�
    public static int loopNumber = 0;


    //���� ���� �� ������ UI
    public GameObject gameOverUI;
    //��� UI �ؽ�Ʈ ����
    public TMP_Text bonusScoreText;
    public TMP_Text stageText;
    public TMP_Text scoreNumberText;

    private int bonusScore = 5000;
    private float timer = 0f;

    [HideInInspector] public bool lastGoal = false;

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


    }

    private void Start()
    {
        //���������� �ؽ�Ʈ ���
        if(SceneManager.GetActiveScene().name == "Scene_One")
        {
            stageText.text = "STAGE-0" + 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //������ ��׶��� ���� �� 
        if(GameObject.Find("LastGoal").transform.position.x <= 0)
        {
            lastGoal = true;
        }

        //Ÿ�̸Ӹ� ����� 1�ʸ��� ���ʽ� ���ھ� ���
        timer += Time.deltaTime;

        if(timer >= 1f)
        {
            timer -= 1f;
            BonusScore();
        }

        string whatScore = playerScore.ToString("D6");
        scoreNumberText.text = "-" + whatScore;

        //���� �����
        if(Input.GetMouseButton(1)) 
        {
            clickRight = true;
        }

        //������
        if(!Input.GetMouseButton(1))
        {
            clickRight=false;
        }
        
        //���� �÷��̾ ������ ��׶����� ������ ��´ٸ� 
        if(PlayerController.gotGoal == true)
        {
            Time.timeScale = 0f; //��� ���� ���� 
        }
    }


    public void BonusScore()
    {  
        if(PlayerController.isDead == false)
        {
            //1�ʴ� Bonus Score 10 �谨
            bonusScore -= 10;
            bonusScoreText.text = "-" + bonusScore;
        }

    }

    public void OnplayerDead()
    {
        gameOverUI.SetActive(true);
    }
}
