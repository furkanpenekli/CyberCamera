using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFrame : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Oyuncu Kamera Alanına Girdi!");

            if (!other.GetComponent<Hideable>().GetHidden())
            {
                Debug.Log("Yandın");

                // Sahneyi tekrar başlat
                RestartCurrentScene();
            }
        }
    }

    private void RestartCurrentScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
