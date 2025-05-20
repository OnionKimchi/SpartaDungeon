using System;
using UnityEngine;

public interface IDamageable
{
    void TakePhysicalDamage(int damage);//���ظ� �Դ� �޼���
}
public class PlayerCondition : MonoBehaviour, IDamageable
{
    public UICondition uiCondition;//UICondition ��ũ��Ʈ�� �ν��Ͻ�     
    Condition health { get { return uiCondition.health; } }//uiCondition�� health �Ӽ�
    Condition stamina { get { return uiCondition.stamina; } }//uiCondition�� stamina �Ӽ�

    public event Action onTakeDamage;//���ظ� �Ծ��� �� �߻��ϴ� �̺�Ʈ

    // Update is called once per frame
    void Update()
    {
        health.Add(health.passiveValue * Time.deltaTime);//health�� ���� ���� �нú� ���� �ð� �� ����
        stamina.Add(stamina.passiveValue * Time.deltaTime);//stamina�� ���� ���� �нú� ���� �ð� �� ����

        if (health.curValue <= 0)//health�� ���� ���� 0 ������ ��
        {
            Die();//���� ó�� �Լ� ȣ��
        }
    }

    void Die()
    {           
        //���� ó�� �߰� ����
    }

    public void TakePhysicalDamage(int damage)
    {
        health.Add(-damage);//health�� ���� ���� damage�� ����
        onTakeDamage?.Invoke();//���ظ� �Ծ��� �� �߻��ϴ� �̺�Ʈ ȣ��, ��������Ʈ�� �ؾ� Ȯ�强 ����
    }
}

