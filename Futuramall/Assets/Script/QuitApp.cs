using UnityEngine;

public class GameExitHandler : MonoBehaviour
{
    public void QuitGame()
    {
#if UNITY_EDITOR
        // Stop play mode if running in the editor
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Quit application when built
        Application.Quit();
#endif
    }
}
