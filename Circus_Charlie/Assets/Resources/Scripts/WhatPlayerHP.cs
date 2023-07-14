using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhatPlayerHP : MonoBehaviour
{
    private Image ImgPlayerHP;

    //�Ҳɿ� ���� �� HP �������� �Ʒ���ŭ ����
    private float emptyAmount = 0.254f;

    // Start is called before the first frame update
    public void RemovePlayerHP()
    {
        ImgPlayerHP = GameObject.Find("Life Icon").GetComponent<Image>(); //�ذ�: nullReferenceException ����
        //�� this.GetComponent<Image>();�δ� �� ã��
        //GameObject.Find("Life Icon").GetComponent<Image>();�δ� ã�°�?
        Debug.Assert(ImgPlayerHP != null); 

        ImgPlayerHP.fillAmount -= emptyAmount;
    }
}
