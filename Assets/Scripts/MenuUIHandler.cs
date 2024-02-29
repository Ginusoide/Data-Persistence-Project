using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bestScoreText;
    [SerializeField] TextMeshProUGUI inputPlayerName;

    // Start is called before the first frame update
    void Start()
    {
        if (RecordManager.Instance.BestScore > 0)
        {
            // Mostra il best record
            bestScoreText.gameObject.SetActive(true);
            bestScoreText.text = $"Best Score: {RecordManager.Instance.PlayerName} - {RecordManager.Instance.BestScore}";
        }

        // Debug.Log(Application.persistentDataPath);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        RecordManager.Instance.ActualPlayer = inputPlayerName.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        RecordManager.Instance.SaveScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
