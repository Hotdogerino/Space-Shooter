using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    [SerializeField]
    private Text _highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowHighScore()
    {
        _highScoreText.gameObject.SetActive(true);
        _highScoreText.text = "High Score:" + PlayerPrefs.GetInt("HighScore");
    }
}
