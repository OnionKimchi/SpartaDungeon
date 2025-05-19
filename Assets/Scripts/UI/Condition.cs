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
    void Start()
    {
        curValue = startValue;//���� ���� ���� ������ �ʱ�ȭ
    }

    // Update is called once per frame
    void Update()
    {
        //ui ������Ʈ
        uiBar.fillAmount = GetPercentage(); //UI ���� fillAmount�� ���� ������ ����
    }

    float GetPercentage()
    { 
        return curValue / maxValue; //���� ���� �ִ� ���� ������ ������ ���
    }

    public void Add(float value)//�ִ밪�� �ּҰ� ���̷�
    {
        curValue += Mathf.Clamp(value, minValue, maxValue);//���� ���� value�� ���ϰ�, �ּҰ��� �ִ밪 ���̷� ����
    }
}
