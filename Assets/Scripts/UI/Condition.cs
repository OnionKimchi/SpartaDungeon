using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Condition : MonoBehaviour
{
    public float curValue;//현재 값
    public float startValue;//시작 값
    public float maxValue;//최대 값
    public float minValue;//최소 값
    public float passiveValue;//패시브 값

    public Image uiBar;//UI 바
    void Start()
    {
        curValue = startValue;//현재 값을 시작 값으로 초기화
    }

    // Update is called once per frame
    void Update()
    {
        //ui 업데이트
        uiBar.fillAmount = GetPercentage(); //UI 바의 fillAmount를 현재 값으로 설정
    }

    float GetPercentage()
    { 
        return curValue / maxValue; //현재 값과 최대 값을 나누어 비율을 계산
    }

    public void Add(float value)//최대값과 최소값 사이로
    {
        curValue += Mathf.Clamp(value, minValue, maxValue);//현재 값에 value를 더하고, 최소값과 최대값 사이로 제한
    }
}
