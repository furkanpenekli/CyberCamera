using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFrame : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
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
