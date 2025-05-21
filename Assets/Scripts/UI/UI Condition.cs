using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICondition : MonoBehaviour
{
    public Condition health;//ü��
    public Condition jumpStack;//���� ����

    void Start()
    {
        CharacterManager.Instance.Player.condition.uiCondition = this;//UICondition Ŭ������ �ν��Ͻ��� PlayerCondition Ŭ������ uiCondition ������ �Ҵ�
        // PlayerController�� jumpStack ���� UI�� ����                                                              
        var playerController = CharacterManager.Instance.Player.controller;
        jumpStack.externalValueGetter = () => playerController.jumpStack;
    }
}
