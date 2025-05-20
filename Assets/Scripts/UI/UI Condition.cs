using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICondition : MonoBehaviour
{
    public Condition health;//체력
    public Condition stamina;//스태미나

    // Start is called before the first frame update
    void Start()
    {
        CharacterManager.Instance.Player.condition.uiCondition = this;//UICondition 클래스의 인스턴스를 PlayerCondition 클래스의 uiCondition 변수에 할당
    }
}
