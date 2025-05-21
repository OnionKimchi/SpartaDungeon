using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICondition : MonoBehaviour
{
    public Condition health;//체력
    public Condition jumpStack;//점프 스택

    void Start()
    {
        CharacterManager.Instance.Player.condition.uiCondition = this;//UICondition 클래스의 인스턴스를 PlayerCondition 클래스의 uiCondition 변수에 할당
        // PlayerController의 jumpStack 값을 UI에 연동                                                              
        var playerController = CharacterManager.Instance.Player.controller;
        jumpStack.externalValueGetter = () => playerController.jumpStack;
    }
}
