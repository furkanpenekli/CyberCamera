using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalCode : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && QuestManager.instance.GetAmountQuestByName("Anahtar").isCompleted)
        {
            // Oyun bittiğinde aktif sahneyi tekrar yükle
            RestartCurrentScene();
        }
    }

    private void RestartCurrentScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
