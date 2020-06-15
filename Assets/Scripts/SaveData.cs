using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public GameObject registerButton;

    // Values
    public static string nome;
    public static string email;
    public static string senha;

    private static string PATH = Path.Combine(Application.streamingAssetsPath, "Save.dat");

    private void Awake()
    {
        if (File.Exists(PATH))
        {
            registerButton.SetActive(false);
            LoadUserData();
        }
    }

    public static void SaveUserData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(PATH);
        AppData data = new AppData
        {
            nome = SaveData.nome,
            email = SaveData.email,
            senha = SaveData.senha
        };
        bf.Serialize(file, data);
        file.Close();
    }

    public static void LoadUserData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(PATH, FileMode.Open);

        AppData data = (AppData)bf.Deserialize(file);
        SaveData.nome = data.nome;
        SaveData.email = data.email;
        SaveData.senha = data.senha;

        file.Close();
    }

    [Serializable]
    public class AppData
    {
        public string nome;
        public string email;
        public string senha;
    }
}
