using System.Collections;
using UnityEngine;

public class CyberCamera : MonoBehaviour
{
    public SpriteRenderer[] spriteElements;
    public float interval = 0.5f;

    private int currentElementIndex = 0;
    private int direction = 1; // 1: Forward , -1: Back

    void Start()
    {
        StartCoroutine(ActivateSprites());
    }
    private Collider2D collider2D;
    IEnumerator ActivateSprites()
    {
        while (true)
        {
            SetActiveSprite(currentElementIndex);
            collider2D = spriteElements[currentElementIndex].GetComponent<Collider2D>();
            yield return new WaitForSeconds(interval);

            currentElementIndex += direction;

            //Change direction when reaching the end or beginning of the sequence
            if (currentElementIndex >= spriteElements.Length || currentElementIndex < 0)
            {
                direction *= -1;
                currentElementIndex += direction * 2;
            }
        }
    }

    private void SetActiveSprite(int index)
    {
        if (index >= 0 && index < spriteElements.Length)
        {
            for (int i = 0; i < spriteElements.Length; i++)
            {
                spriteElements[i].gameObject.SetActive(i == index);
            }
        }
        else
        {
            Debug.LogError("Invalid index " + index);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Trigger alanına giren nesnenin Player tag'ine sahip olup olmadığını kontrol et
        if (other.CompareTag("Player"))
        {
            Debug.Log("Oyuncu Kamera Alanına Girdi!");

            if (other.GetComponent<Hideable>().GetHidden())
            {
                Debug.Log("Gizlendin");
            }
            else if (!other.GetComponent<Hideable>().GetHidden())
            {
                Debug.Log("Yandın");
            }
        }
    }
}
