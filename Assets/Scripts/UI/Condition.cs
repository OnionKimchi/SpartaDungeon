using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Condition : MonoBehaviour
{
    public float curValue;//���� ��
    public float startValue;//���� ��
    public float maxValue;//�ִ� ��
    public float minValue;//�ּ� ��
    public float passiveValue;//�нú� ��

    public Image uiBar;//UI ��


    public Func<float> externalValueGetter;//�ܺο��� ���� �������� ��������Ʈ, ���������� ��� �ܺο��� ���� �����;� �ϹǷ� ���
    void Start()
    {
        curValue = startValue;//���� ���� ���� ������ �ʱ�ȭ
    }

    // Update is called once per frame
    void Update()
    {
        float valueToShow = externalValueGetter != null ? externalValueGetter() : curValue;//�ܺο��� ���� �������� �Լ��� ������ �� ���� ����ϰ�, ������ ���� ���� ���
        uiBar.fillAmount = valueToShow / maxValue;//UI ���� ä�� ���� ���� ���� �ִ� ������ ����
    }

    public void Add(float value)//�ִ밪�� �ּҰ� ���̷�
    {
        curValue += value;
        curValue = Mathf.Clamp(curValue, minValue, maxValue);//���� ���� value�� ���ϰ�, �ּҰ��� �ִ밪 ���̷� ����
    }
}
