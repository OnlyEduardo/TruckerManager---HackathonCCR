using UnityEngine;

public class AbaOcultaController : MonoBehaviour
{
    public GameObject AbaOculta;

    public void OpenAba()
    {
        AbaOculta.SetActive(true);
    }

    public void CloseAba()
    {
        AbaOculta.SetActive(false);
    }

    public void CloseApp()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
         Application.Quit();
        #endif
    }
}
