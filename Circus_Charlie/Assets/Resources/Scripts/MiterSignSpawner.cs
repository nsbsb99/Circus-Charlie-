using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiterSignSpawner : MonoBehaviour
{

    public GameObject miterSignObject;

    //두 개 표지 번갈아 사용
    private int count = 2;

    //생성 시간  
    private float timeBetSpawn = 4f;

    private GameObject[] miterSigns;

    //사용할 현재 순번
    private int currentIndex = 0;

    //리소스 숨겨둘 좌표
    private Vector2 poolPosition = new Vector2(0f, -15f);

    private float lastSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        miterSigns = new GameObject[count];

        for (int i = 0; i < count; i++)
        {
            //풀에 두 개 저장
            miterSigns[i] = Instantiate(miterSignObject, poolPosition, Quaternion.identity);
            //miterSign 오브젝트가 캔버스의 자식 오브젝트임을 명시 
            //miterSigns[i].transform.SetParent(transform, false);
        }


        //시작 시 마지막 스폰 시점 초기화
        lastSpawnTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //게임 내 시간이 마지막 스폰 시점 + 스폰 주기 시점을 넘어갔다면
        if (lastSpawnTime + timeBetSpawn <= Time.time && PlayerController.isDead == false)
        {
            //마지막 스폰 시점 갱신
            lastSpawnTime = Time.time;

            //다시 활성화시킬 x좌표
            float xPos = 10f;
            float yPos = -4.2f;


            miterSigns[currentIndex].SetActive(false);
            miterSigns[currentIndex].SetActive(true);

            //재이동을 위해 뒤로 밀기
            miterSigns[currentIndex].transform.position = new Vector2(xPos, yPos);

            Debug.Assert(miterSigns[currentIndex]);

            currentIndex += 1;

            if (currentIndex >= count)
            {
                currentIndex = 0;
            }
        }
    }
}
