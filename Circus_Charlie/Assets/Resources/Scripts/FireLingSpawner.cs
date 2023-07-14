using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLingSpawner : MonoBehaviour
{

    //pp.545

    //불꽃링 프리팹으로 집어넣기
    public GameObject fireLingPrefab;
    //링 번갈아 사용
    private int count = 2;
    //생성 시간
    public float timeBetSpawnMin = 4.0f;
    public float timeBetSpawnMax = 5.5f;
    private float timeBetSpawn;

    private GameObject[] fireLings;

    //사용할 현재 순번
    private int currentIndex = 0;

    //리소스 숨겨둘 좌표
    private Vector2 poolPosition = new Vector2(0, -10f);
    private float lastSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        fireLings = new GameObject[count];

        for (int i = 0; i < count; i++)
        {
            //링을 풀에 저장
            fireLings[i] = Instantiate(fireLingPrefab, poolPosition, Quaternion.identity);
        }

        lastSpawnTime = 0f;
        timeBetSpawn = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (lastSpawnTime + timeBetSpawn <= Time.time && PlayerController.isDead == false
            && GameManager.clickRight == false)
        {
            lastSpawnTime = Time.time;
            timeBetSpawn = UnityEngine.Random.Range(timeBetSpawnMin, timeBetSpawnMax);

            //다음 불꽃링 불러오기
            float xPos = 6.36f;

            fireLings[currentIndex].SetActive(false);
            fireLings[currentIndex].SetActive(true);

            //재이동을 위해 링을 뒤로 밀기
            fireLings[currentIndex].transform.position = new Vector2(xPos, 0f);
            currentIndex += 1;

            if (currentIndex >= count)
            {
                currentIndex = 0;
            }
        }
    }
}
