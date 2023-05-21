using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[DefaultExecutionOrder(1000)]
public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public int maxPoints;
    public string playerName;

    private void Awake() 
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
    }

    [System.Serializable]
    class SaveDataUser
    {
        public int maxPoints;
        public string playerName;
    }

    public void SaveData(int m_Points, string name)
    {
        SaveDataUser data = new SaveDataUser();
        if (m_Points > maxPoints)
        {
            data.maxPoints = m_Points;
        }
        data.playerName = name;
        
        string json = JsonUtility.ToJson(data);
        
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveDataUser data = JsonUtility.FromJson<SaveDataUser>(json);

            maxPoints = data.maxPoints;
            playerName = data.playerName;
        }
    }


}
