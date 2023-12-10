using System;
using UnityEngine;

public class Opacity : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    [SerializeField]
    public bool concealment = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Color newColor = spriteRenderer.color;
            newColor.a = 0.5f;
            spriteRenderer.color = newColor;

            concealment = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            spriteRenderer.color = originalColor;
            concealment = false;
        }
    }
}
