using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private List<Vector3> points;
    [SerializeField] private float speed;
    [SerializeField] private float waitTime;

    private bool isWaiting = false;

    private void Update()
    {
        MovePlatform();
    }

    private void MovePlatform()
    {
        if (points.Count == 0 || isWaiting) return;

        float distance = Vector3.Distance(transform.position, points[0]);

        if (distance < 0.01f)
        {
            StartCoroutine(WaitAtPoint());
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, points[0], speed * Time.deltaTime);
        }
    }

    private IEnumerator WaitAtPoint()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
        points.Add(points[0]);
        points.RemoveAt(0);
        isWaiting = false;
    }

    // ÇÃ·§Æû À§¿¡ µé¾î¿Ã ¶§
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform); // ÇÃ·§ÆûÀÇ ÀÚ½ÄÀ¸·Î ¼³Á¤
        }
    }

    // ÇÃ·§Æû¿¡¼­ ¹þ¾î³¯ ¶§
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null); // ´Ù½Ã ºÎ¸ð¸¦ ÇØÁ¦
        }
    }
}
