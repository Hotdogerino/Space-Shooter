using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private GameObject _button;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (_player.gameObject == null)
        {
            _button.SetActive(true);
        }
    }
    public void LoadMenu()
    {

            SceneManager.LoadScene(0);
        
    }
}
