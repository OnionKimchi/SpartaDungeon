using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IInteractable
{
    public string GetInteractPrompt();//��ȣ�ۿ� ������Ʈ�� ��ȯ�ϴ� �޼���
    public void OnInteract();//��ȣ�ۿ� �޼���

}
public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemData itemData;// ������ �����͸� ����

    public string GetInteractPrompt()
    {
        return $"{itemData.itemName}\n{itemData.itemDescription}";//������ �̸��� ������ ���ڿ��� ��ȯ
    }

    public void OnInteract()//��ȣ�ۿ� �޼���, �÷��̾� ��ǲ Ŭ������ �ߵ�
    {
        if (itemData.itemType == ItemType.consumable)
        {
            CharacterManager.Instance.Player.itemData = itemData;//������ �����͸� �÷��̾��� ������ �����Ϳ� �Ҵ�
            CharacterManager.Instance.Player.addItem?.Invoke();//������ �߰� ��������Ʈ ȣ��
            Destroy(gameObject);//��ȣ�ۿ� �� ������Ʈ ����
        }
        else // �Ҹ�ǰ�� �ƴϸ� �������� ���� �ʰ� ��ũ���� UI�� Ȱ��ȭ
        {
            // "ObjectDescription" ������Ʈ�� ã�� Ȱ��ȭ
            GameObject descriptionObj = GameObject.Find("ObjectDescription");
            if (descriptionObj != null)
            {
                descriptionObj.SetActive(true);
                Time.timeScale = 0;//���� �Ͻ� ����

                // ObjectDescriptionUI ��ũ��Ʈ�� �پ� �ִٸ� ���� ����
                var descUI = descriptionObj.GetComponent<ObjectDescriptionUI>();
                if (descUI != null)
                {
                    descUI.SetDescription(itemData.itemName, itemData.itemDescription);
                }
            }
        }
    }
}
