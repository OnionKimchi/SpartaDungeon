using System;
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


    public Func<float> externalValueGetter;//외부에서 값을 가져오는 델리게이트, 점프스택의 경우 외부에서 값을 가져와야 하므로 사용
    void Start()
    {
        curValue = startValue;//현재 값을 시작 값으로 초기화
    }

    // Update is called once per frame
    void Update()
    {
        float valueToShow = externalValueGetter != null ? externalValueGetter() : curValue;//외부에서 값을 가져오는 함수가 있으면 그 값을 사용하고, 없으면 현재 값을 사용
        uiBar.fillAmount = valueToShow / maxValue;//UI 바의 채움 양을 현재 값과 최대 값으로 설정
    }

    public void Add(float value)//최대값과 최소값 사이로
    {
        curValue += value;
        curValue = Mathf.Clamp(curValue, minValue, maxValue);//현재 값에 value를 더하고, 최소값과 최대값 사이로 제한
    }
}
