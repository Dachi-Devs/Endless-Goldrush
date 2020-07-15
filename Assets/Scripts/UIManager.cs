using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.OnScoreUpdate += GameManager_OnScoreUpdate;
        UpdateUIScoreText();
    }

    private void GameManager_OnScoreUpdate(object sender, System.EventArgs e)
    {
        UpdateUIScoreText();
    }

    private void UpdateUIScoreText()
    {
        scoreText.text = GameManager.instance.GetScore().ToString();
    }

}
