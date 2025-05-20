using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campfire : MonoBehaviour
{
    public int damage; // ������
    public float damageRate;// ������ �ִ� �ӵ�

    List<IDamageable> things = new List<IDamageable>();//���ظ� ���� �� �ִ� ��ü ����Ʈ
    void Start()
    {
        InvokeRepeating("DealDamage", 0, damageRate);//������ �ð� �������� DealDamage �޼��� ȣ��
        //�κ�ũ�������� ������ �ð� �������� �޼��带 ȣ���ϴ� ����Ƽ�� ���� �޼���(������ �޼���, ��� �ð�, �ݺ� �ֱ�)
    }

    void DealDamage()
    {
        for (int i = 0; i < things.Count; i++)
        {
            things[i].TakePhysicalDamage(damage);//����Ʈ�� �ִ� ��ü�� ������ �ֱ�
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(other.TryGetComponent(out IDamageable damageable))//IDamageable �������̽��� ������ ��ü���� Ȯ��
            {
                things.Add(damageable);//����Ʈ�� �߰�
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.TryGetComponent(out IDamageable damageable))//IDamageable �������̽��� ������ ��ü���� Ȯ��
            {
                things.Remove(damageable);//����Ʈ���� ����
            }
        }
    }
}
