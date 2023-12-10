using UnityEngine;

public class Cam : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Trigger alanına giren nesnenin "Player" tag'ine sahip olup olmadığını kontrol et
        if (other.CompareTag("Player"))
        {
            Opacity opacityScript = other.GetComponent<Opacity>();

            // Eğer "Opacity" bileşeni varsa ve "Hide" tag'ine sahip bir nesnenin arkasında değilse ve concealment değeri false ise
            if (opacityScript != null && !other.CompareTag("Hide") && !opacityScript.concealment)
            {
                Debug.Log("Oyuncu Trigger Alanına Girdi! Bu, " +
                    gameObject.name + " game object'i altındaki bir trigger alanıdır.");
            }
            else
            {
                Debug.Log("Oyuncu Trigger Alanına Girdi, Ancak Hide Tag'li Alanın Arkasında veya Hide tag'ine sahip bir nesne concealment değeri true!");
            }
        }
    }
}
