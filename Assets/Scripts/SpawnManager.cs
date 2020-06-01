using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _PowerupContainer;
    [SerializeField]
    private GameObject _EnemyPrefab;
    [SerializeField]
    private GameObject _Enemy2Prefab;
    [SerializeField]
    private GameObject _EnemyContainer;
    [SerializeField]
    private float seconds = 3f;
    [SerializeField]
    private bool _stopSpawning = false;
    [SerializeField]
    private float secondsForPowerup1 = 3f;
    [SerializeField]
    private float secondsForPowerup2 = 10f;
    [SerializeField]
    private GameObject[] powerups;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForEnemy(seconds));
        StartCoroutine(WaitForPowerup(secondsForPowerup1, secondsForPowerup2));
    }
    void Update()
    {

    }
    void InstantiatesEnemy()
    {
            GameObject newEnemy = Instantiate(_EnemyPrefab, new Vector3(Random.Range(-9, 9), 7.5f, transform.position.z), Quaternion.identity);
        GameObject newEnemy2 = Instantiate(_Enemy2Prefab, new Vector3(Random.Range(-9, 9), 7.5f, transform.position.z), Quaternion.identity);
        newEnemy.transform.parent = _EnemyContainer.transform;
        newEnemy2.transform.parent = _EnemyContainer.transform;
    }
    IEnumerator WaitForEnemy(float seconds)
    {
        while (_stopSpawning==false)
        {
            print(Time.time);
            yield return new WaitForSeconds(seconds);
            InstantiatesEnemy();
        }
    }
    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
    void InstantiatesPowerup()
    {
        int randomPowerUp = Random.Range(0, 3);
        GameObject newPowerup = Instantiate(powerups[randomPowerUp], new Vector3(Random.Range(-9, 9), 8 + 0.8f, transform.position.z), Quaternion.identity);
        newPowerup.transform.parent = _PowerupContainer.transform;
    }
    IEnumerator WaitForPowerup(float secondsForPowerup1, float secondsForPowerup2)
    {
        while (_stopSpawning == false)
        {
            print(Time.time);
            yield return new WaitForSeconds(Random.Range(secondsForPowerup1, secondsForPowerup2));
            InstantiatesPowerup();
        }
    }
}
