using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    public UICondition uiCondition;//UICondition 스크립트의 인스턴스
    Condition health { get { return uiCondition.health; } }//uiCondition의 health 속성
    Condition stamina { get { return uiCondition.stamina; } }//uiCondition의 stamina 속성

    // Update is called once per frame
    void Update()
    {
        health.Add(health.passiveValue * Time.deltaTime);//health의 현재 값에 패시브 값을 시간 당 더함
        stamina.Add(stamina.passiveValue * Time.deltaTime);//stamina의 현재 값에 패시브 값을 시간 당 더함
    }
}
