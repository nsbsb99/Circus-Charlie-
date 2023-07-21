using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScriptOrder : MonoBehaviour
{
    public string sortingLayerName;
    public int sortingOrder;
    public TMP_Text miterNumberText;

    // Start is called before the first frame update
    void Start()
    {
        //������ �����ϵ��� ���̾� ����
        MeshRenderer mesh = GetComponent<MeshRenderer>();
        mesh.sortingLayerName = sortingLayerName;
        mesh.sortingOrder = sortingOrder;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
