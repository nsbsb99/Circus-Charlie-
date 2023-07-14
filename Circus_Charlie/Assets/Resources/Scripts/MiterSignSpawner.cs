using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiterSignSpawner : MonoBehaviour
{

    public GameObject miterSignObject;

    //�� �� ǥ�� ������ ���
    private int count = 2;

    //���� �ð�  
    private float timeBetSpawn = 4f;

    private GameObject[] miterSigns;

    //����� ���� ����
    private int currentIndex = 0;

    //���ҽ� ���ܵ� ��ǥ
    private Vector2 poolPosition = new Vector2(0f, -15f);

    private float lastSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        miterSigns = new GameObject[count];

        for (int i = 0; i < count; i++)
        {
            //Ǯ�� �� �� ����
            miterSigns[i] = Instantiate(miterSignObject, poolPosition, Quaternion.identity);
            //miterSign ������Ʈ�� ĵ������ �ڽ� ������Ʈ���� ��� 
            //miterSigns[i].transform.SetParent(transform, false);
        }


        //���� �� ������ ���� ���� �ʱ�ȭ
        lastSpawnTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //���� �� �ð��� ������ ���� ���� + ���� �ֱ� ������ �Ѿ�ٸ�
        if (lastSpawnTime + timeBetSpawn <= Time.time && PlayerController.isDead == false)
        {
            //������ ���� ���� ����
            lastSpawnTime = Time.time;

            //�ٽ� Ȱ��ȭ��ų x��ǥ
            float xPos = 10f;
            float yPos = -4.2f;


            miterSigns[currentIndex].SetActive(false);
            miterSigns[currentIndex].SetActive(true);

            //���̵��� ���� �ڷ� �б�
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
