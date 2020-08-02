using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject scoreObject;

    [SerializeField]
    private GameObject backObject;

    [SerializeField]
    private GameObject gameOverPanel;

    [SerializeField]
    private Text finalScore;

    void OnEnable()
    {        
        GameManager.instance.OnScoreUpdate += GameManager_OnScoreUpdate;
        UpdateUIScoreText();
        FindObjectOfType<RunForward>().OnDeath += RunForward_OnDeath;

        gameOverPanel.SetActive(false);
        scoreObject.SetActive(true);
        backObject.SetActive(true);
    }

    private void RunForward_OnDeath(object sender, EventArgs e)
    {
        StartCoroutine(Death());
    }

    private IEnumerator Death()
    {
        scoreObject.SetActive(false);
        backObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        gameOverPanel.SetActive(true);
        finalScore.text = GameManager.instance.GetScore().ToString();
    }

    private void GameManager_OnScoreUpdate(object sender, EventArgs e)
    {
        UpdateUIScoreText();
    }

    private void UpdateUIScoreText()
    {
        scoreObject.GetComponentInChildren<Text>().text = GameManager.instance.GetScore().ToString();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
