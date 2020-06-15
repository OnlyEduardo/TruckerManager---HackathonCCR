using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private string ActualSceneName;

    void Start()
    {
        ActualSceneName = SceneManager.GetActiveScene().name;
    }

    public static void LoadStaticScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void Voltar()
    {
        switch (ActualSceneName)
        {

            default:
                SceneManager.LoadScene("TelaInicial");
                break;
        }
    }
}
