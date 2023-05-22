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

    private void Start()
    {        
        if (MainManager.Instance != null)
        {
            scoreText.text = "Best Score : " + MainManager.Instance.playerName + " : " + MainManager.Instance.maxPoints;
            inputName.text = MainManager.Instance.playerName;
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
        string playerName = inputName.text.ToString();
        MainManager.Instance.playerName = playerName;
        MainManager.Instance.SaveData(0);
    }
}
