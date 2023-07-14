using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhatPlayerHP : MonoBehaviour
{
    private Image ImgPlayerHP;

    //불꽃에 닿을 시 HP 아이콘을 아래만큼 비우기
    private float emptyAmount = 0.254f;

    // Start is called before the first frame update
    public void RemovePlayerHP()
    {
        ImgPlayerHP = GameObject.Find("Life Icon").GetComponent<Image>(); //해결: nullReferenceException 오류
        //왜 this.GetComponent<Image>();로는 못 찾고
        //GameObject.Find("Life Icon").GetComponent<Image>();로는 찾는가?
        Debug.Assert(ImgPlayerHP != null); 

        ImgPlayerHP.fillAmount -= emptyAmount;
    }
}
