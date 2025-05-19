using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    public UICondition uiCondition;//UICondition ��ũ��Ʈ�� �ν��Ͻ�
    Condition health { get { return uiCondition.health; } }//uiCondition�� health �Ӽ�
    Condition stamina { get { return uiCondition.stamina; } }//uiCondition�� stamina �Ӽ�

    // Update is called once per frame
    void Update()
    {
        health.Add(health.passiveValue * Time.deltaTime);//health�� ���� ���� �нú� ���� �ð� �� ����
        stamina.Add(stamina.passiveValue * Time.deltaTime);//stamina�� ���� ���� �нú� ���� �ð� �� ����
    }
}
