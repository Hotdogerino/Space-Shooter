using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_manager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    public static int score = 0;
    [SerializeField]
    private Image _livesImage;
    [SerializeField]
    private Sprite[] _livesSprites;
    [SerializeField]
    private Text _gameoverText;
    [SerializeField]
    private Text _restartText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _scoreText.text = "Score:" + score;

    }
   public void LivesUpdateVisual(int CurrentLives)
    {
        _livesImage.sprite = _livesSprites[CurrentLives];
    }
    public void GameOver()
    {
        _restartText.gameObject.SetActive(true);
        _gameoverText.gameObject.SetActive(true);
        score = 0;
        StartCoroutine(GameOverFlicking());
    }
    IEnumerator GameOverFlicking()
    {
        while (true)
        {
            _gameoverText.text = "Game over";
            yield return new WaitForSeconds(1);
            _gameoverText.text = "";
            yield return new WaitForSeconds(1);

        }
    }
}
