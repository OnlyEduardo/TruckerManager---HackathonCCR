using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class Alarmes : MonoBehaviour
{
    public AudioClip agua;
    public AudioClip alongar;
    public AudioSource audio;

    public Button AguaButton;
    public Button AlongaButton;

    // Agua
    public static bool wActive;
    public static int w_hours;
    public static int w_minutes;

    private static float w_frames;

    // Alongamento
    public static bool aActive;
    public static int a_hours;
    public static int a_minutes;

    private static float a_frames;

    private static string PATH = Path.Combine(Application.streamingAssetsPath, "Alarm.dat");

    private void Start()
    {
        audio = GetComponent<AudioSource>();

        if (File.Exists(PATH))
            LoadAlarm();
        else
        {
            wActive = false;
            aActive = false;
        }

        if (AguaButton != null)
        {
            AguaButton.image.color = wActive ? new Color(0, 255, 0) : new Color(255, 0, 0);
            AguaButton.GetComponentInChildren<Text>().text = wActive ? "Desativar" : "Ativar";
        }           
        if(AlongaButton != null)
        {
            AlongaButton.image.color = aActive ? new Color(0, 255, 0) : new Color(255, 0, 0);
            AlongaButton.GetComponentInChildren<Text>().text = aActive ? "Desativar" : "Ativar";
        }
           
    }

    public void AguaB()
    {
        wActive = !wActive;
        AguaButton.image.color = wActive ? new Color(0, 255, 0) : new Color(255, 0, 0);
        AguaButton.GetComponentInChildren<Text>().text = wActive ? "Desativar" : "Ativar";
        SaveAlarm();
    }

    public void AlongaB()
    {
        aActive = !aActive;
        AlongaButton.image.color = aActive ? new Color(0, 255, 0) : new Color(255, 0, 0);
        AlongaButton.GetComponentInChildren<Text>().text = aActive ? "Desativar" : "Ativar";
        SaveAlarm();
    }

    private void Update()
    {
        if (wActive)
        {
            if (w_frames < 1800)
            {
                w_frames += Time.deltaTime;
            }
            else
            {
                w_frames = 0;
                audio.PlayOneShot(agua);
            }
        }

        if (aActive)
        {
            if (a_frames < 3550)
            {
                a_frames += Time.deltaTime;
            }
            else
            {
                a_frames = 0;
                audio.PlayOneShot(alongar);
            }
        }
    }

    public void LoadAlarm()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(PATH, FileMode.Open);
        AlarmData data = (AlarmData)bf.Deserialize(file);
        Alarmes.wActive = data.wActive;
        Alarmes.aActive = data.aActive;
        file.Close();
    }

    public void SaveAlarm()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(PATH);
        AlarmData data = new AlarmData
        {
            wActive = Alarmes.wActive,
            aActive = Alarmes.aActive,
        };
        bf.Serialize(file, data);
        file.Close();
    }

    [Serializable]
    public class AlarmData
    {
        public bool wActive;
        public bool aActive;
    }
}
