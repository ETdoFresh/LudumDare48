using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class RestartScene : ScriptableObject
{
    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
