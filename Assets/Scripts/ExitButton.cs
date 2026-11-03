using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void ExitGameButton()
    {
#if  UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif        
    }
}
