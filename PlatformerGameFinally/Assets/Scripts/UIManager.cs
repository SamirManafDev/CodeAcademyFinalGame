using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject gamePanel;
    [SerializeField] private TMP_Text coinText;
    [SerializeField] private TMP_Text starText;
    [SerializeField] GameObject restartPanel;
    [SerializeField] GameObject settingsPanel;
    [SerializeField] GameObject starOne;
    [SerializeField] GameObject starTwo;
    [SerializeField] GameObject starThree;
    [SerializeField] GameObject gameOver;
    [SerializeField] AudioClip UIClick;
    public static UIManager Instance { get; set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void OnEnable()
    {
        Time.timeScale = 0;
    }
    public void OnclickStart()
    {
        Time.timeScale = 1;
    }
    public void OpenGamePanel()
    {
        startPanel.SetActive(true);
    }
    public void CloseGamePanel()
    {
        startPanel.SetActive(false);
    }
    public void OpenGame1Panel()
    {
        startPanel.SetActive(true);
    }
    public void CloseGame1Panel()
    {
        startPanel.SetActive(false);
    }

    public void UpdateCoinValue(float _coins)
    {
        coinText.text = _coins.ToString();
    }
    public void UpdateStarValue(float star)
    {
        if (star == 1f)
        {
            starOne.SetActive(true);
        }
        else if (star == 2f)
        {
            starTwo.SetActive(true);
        }
        else if (star == 3f)
        {
            starThree.SetActive(true);
        }
        

    }
    public void OpenRestartPanel()
    {
       restartPanel.SetActive(true);
    }
    public void CloseRestartPanel()
    {
        restartPanel.SetActive(false);
    }
    public void OpenSettingsPanel()
    {
        settingsPanel.SetActive(true);
    }
    public void CloseSettingsPanel()
    {
        settingsPanel.SetActive(false);
    }
    public void ReStart()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
    public void GameOverOpen()
    {
        gameOver.SetActive(true);
        UnityEngine.Cursor.visible = true;
    }
    public void GameOverClose()
    {
        UnityEngine.Cursor.visible = false;
        gameOver.SetActive(false);
    }

    public void UISound()
    {
        GameObject.Find("UIClick Sound").GetComponent<AudioSource>().Play();
    }
}
