using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Text _gameOver;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && _gameOver.gameObject.activeSelf == true)
            SceneManager.LoadScene(1);//SceneManager.GetActiveScene().buildIndex);           //or whatever number your scene is
    }

}
