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
    public string maxPointsName;
    public string lastName;

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
        public string maxPointsName;
        public string lastName;
    }

    public void SaveData(int m_Points)
    {
        SaveDataUser data = new SaveDataUser();
        if (m_Points > maxPoints)
        {
            data.maxPoints = m_Points;
            data.maxPointsName = lastName;
        }        
        else 
        {
            data.maxPoints = maxPoints;
            data.maxPointsName = maxPointsName;
        }
        data.lastName = lastName;
                        
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
            maxPointsName = data.maxPointsName;
            lastName = data.lastName;
        }
    }


}
