using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICondition : MonoBehaviour
{
    public Condition health;//ü��
    public Condition stamina;//���¹̳�

    // Start is called before the first frame update
    void Start()
    {
        CharacterManager.Instance.Player.condition.uiCondition = this;//UICondition Ŭ������ �ν��Ͻ��� PlayerCondition Ŭ������ uiCondition ������ �Ҵ�
    }
}
