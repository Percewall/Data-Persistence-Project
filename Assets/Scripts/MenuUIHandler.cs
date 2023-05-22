using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] InputField inputName;
    [SerializeField] TextMeshProUGUI scoreText;    
    public string playerName;

    private void Start()
    {        
        if (MainManager.Instance != null)
        {
            scoreText.text = "Best Score : " + MainManager.Instance.maxPointsName + " : " + MainManager.Instance.maxPoints;
            inputName.text = MainManager.Instance.lastName;
        }
    }

    public void StartNew()
    { 
        SavePlayerName();
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {        
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }

    public void SavePlayerName()
    {
        MainManager.Instance.lastName = inputName.text.ToString();
        MainManager.Instance.SaveData(0);
    }
}
