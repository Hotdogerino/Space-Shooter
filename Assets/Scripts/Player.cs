using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _fireRate = 0.5f;
    [SerializeField]
    private float _canFire = -1f;
    [SerializeField]
    public int _lives = 3;
    [SerializeField]
    private bool isTripleShotActive = false;
    [SerializeField]
    private GameObject _tripleLaserPrefab;
    [SerializeField]
    private bool isSpeedActive = false;
    [SerializeField]
    private bool isShieldActive = false;
    [SerializeField]
    private GameObject _ShieldVisual;
    [SerializeField]
    private GameObject _fireVisual;
    [SerializeField]
    private GameObject _fireVisual2;
    private SpawnManager _spawnManager;
    private float _speedPowerUp = 1f;
    private UI_manager _manager;
    private Animator _anim;
    private AudioSource laserSource, explosionSource, powerupSource;
    [SerializeField]
    private AudioClip laserClip, explosionClip, powerupClip;


    // Start is called before the first frame update
    void Start()
    {
        // Take the current position = new position (0,0,0);
        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("Spawn_manager").GetComponent<SpawnManager>();
        _manager = GameObject.Find("Canvas").GetComponent<UI_manager>();
        laserSource = GetComponent<AudioSource>();
        _anim = GetComponent<Animator>();
        if (_spawnManager == null)
        {
            Debug.LogError("SpawnManager is null");
        }
        if (_manager == null)
        {
            Debug.LogError("Manager is null");
        }
        if (laserSource == null)
        {
            Debug.LogError("audiosource is null");
        }
        else
        {
            laserSource.clip = laserClip;
            //explosionSource.clip = explosionClip;
            //powerupSource.clip = explosionClip;
        }
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            Shooting();
        }
    }
    void CalculateMovement()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");
        if (isSpeedActive == true)
        {
            _speedPowerUp += 0.005f;
        }
        else
        {
            _speedPowerUp = 1;
        }

        transform.Translate(Vector3.right * HorizontalInput * _speed * _speedPowerUp * Time.deltaTime);
        transform.Translate(Vector3.up * VerticalInput * _speed * _speedPowerUp * Time.deltaTime);
        //if (transform.position.y >= 0)
        //{
        //    transform.position = new Vector3(transform.position.x, 0, 0);

        //}
        //else if (transform.position.y <= -3.5f)
        //{
        //    transform.position = new Vector3(transform.position.x, -3.5f, 0);

        //}
        /// both work
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.5f, 0), 0);
        if (transform.position.x >= 11)
        {
            transform.position = new Vector3(-11, transform.position.y, transform.position.z);

        }
        else if (transform.position.x <= -11)
        {
            transform.position = new Vector3(-11, transform.position.y, transform.position.z);

        }
    }
    void Shooting()
    {
        _canFire = Time.time + _fireRate;
        if (isTripleShotActive == true)
        {
            Instantiate(_tripleLaserPrefab, new Vector3(transform.position.x - 1.35f, transform.position.y, transform.position.z), Quaternion.identity);
        }
        else
            Instantiate(_laserPrefab, new Vector3(transform.position.x, transform.position.y + 0.8f, transform.position.z), Quaternion.identity);
        laserSource.Play();
    }
    public void Damage()
    {
        if (isShieldActive == true)
        {
            isShieldActive = false;
            _ShieldVisual.SetActive(false);
            return;
        }
        _lives -= 1;
        _manager.LivesUpdateVisual(_lives);
        int randomFire = Random.Range(0, 2);
        if (_lives < 3 && randomFire == 1)
        {
            _fireVisual.SetActive(true);
        }
        if (_lives < 3 && randomFire == 0)
        {
            _fireVisual2.SetActive(true);
        }
        if (_lives < 2 && _fireVisual.activeSelf == true)
        {
            _fireVisual2.SetActive(true);
        }
        if (_lives < 2 && _fireVisual2.activeSelf == true)
        {
            _fireVisual.SetActive(true);
        }
        if (_lives < 1)
        {
            _spawnManager.OnPlayerDeath();
            Destroy(gameObject);
            _manager.GameOver();
        }
    }


    public IEnumerator PowerUpEnum(int ID)
    {
        if (ID == 0)
        {

            yield return new WaitForSeconds(5);
            isTripleShotActive = false;
        }
        else if (ID == 1)
        {

            yield return new WaitForSeconds(10);
            isSpeedActive = false;
        }
        else if (ID == 2)
        {

            yield return new WaitForSeconds(30);
            _ShieldVisual.SetActive(false);
            isShieldActive = false;

        }


    }
    public void SpeedIsNowActive()
    {
        isSpeedActive = true;
        StartCoroutine(PowerUpEnum(1));
    }
    public void ShieldIsNowActive()
    {
        isShieldActive = true;
        _ShieldVisual.SetActive(true);
        StartCoroutine(PowerUpEnum(2));
    }
    public void TripleShotIsNowActive()
    {
        isTripleShotActive = true;
        StartCoroutine(PowerUpEnum(0));
    }

}





