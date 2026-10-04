using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTeleporter : MonoBehaviour
{
    [SerializeField] private string targetSceneName;
    private bool isTeleporting;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isTeleporting || !collision.CompareTag("Player")) return;

        if (string.IsNullOrWhiteSpace(targetSceneName))
        {
            Debug.LogWarning($"{name} needs a target scene name before it can teleport.", this);
            return;
        }

        isTeleporting = true;
        SceneManager.LoadScene(targetSceneName);
    }
}
