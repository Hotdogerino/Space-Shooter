using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_menu : MonoBehaviour
{
    private AudioSource _mainMenuSource;
    private Scene scene;
    [SerializeField]
    private AudioClip _mainMenuClip;
    // Start is called before the first frame update
    private void Start()
    {
        _mainMenuSource = GetComponent<AudioSource>();
        _mainMenuClip = _mainMenuSource.clip;
    }
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
        
    }
    public void MainMenuMusic()
    {
        scene = SceneManager.GetActiveScene();
        if (scene.buildIndex == 0)
        {
            _mainMenuSource.Play();
        }
    }

}
