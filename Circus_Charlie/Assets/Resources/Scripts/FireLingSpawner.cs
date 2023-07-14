using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLingSpawner : MonoBehaviour
{

    //pp.545

    //�Ҳɸ� ���������� ����ֱ�
    public GameObject fireLingPrefab;
    //�� ������ ���
    private int count = 2;
    //���� �ð�
    public float timeBetSpawnMin = 4.0f;
    public float timeBetSpawnMax = 5.5f;
    private float timeBetSpawn;

    private GameObject[] fireLings;

    //����� ���� ����
    private int currentIndex = 0;

    //���ҽ� ���ܵ� ��ǥ
    private Vector2 poolPosition = new Vector2(0, -10f);
    private float lastSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        fireLings = new GameObject[count];

        for (int i = 0; i < count; i++)
        {
            //���� Ǯ�� ����
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

            //���� �Ҳɸ� �ҷ�����
            float xPos = 6.36f;

            fireLings[currentIndex].SetActive(false);
            fireLings[currentIndex].SetActive(true);

            //���̵��� ���� ���� �ڷ� �б�
            fireLings[currentIndex].transform.position = new Vector2(xPos, 0f);
            currentIndex += 1;

            if (currentIndex >= count)
            {
                currentIndex = 0;
            }
        }
    }
}
