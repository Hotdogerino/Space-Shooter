using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private float _speed = 7f;
    private Animator _anim;
    private Player player;
    private AudioSource _explosionSource;
    [SerializeField]
    private AudioClip _explosionClip;
    // Update is called once per frame
    void Start()
    {
        _explosionSource = GetComponent<AudioSource>();
        _anim = GetComponent<Animator>();
        if (_anim == null)
        {
            Debug.LogError("Anim is NULL");
        }
        _explosionSource.clip = _explosionClip;

    }
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y <= -4.5)
        {
            transform.position = new Vector3(Random.Range(-9, 9), 8, transform.position.z);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //other.transform.GetComponent<Player>().Damage();        //this is good, but it can be better if its checked if its a null to avoid null exception errors
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.Damage();
            }
            _anim.SetTrigger("OnEnemyDeath");
            _speed = 0;
            gameObject.GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject, 2.8f);
            _explosionSource.Play();

        }
        else if (other.CompareTag("Laser"))
        {

            UI_manager.score += 10;
            _anim.SetTrigger("OnEnemyDeath");
            _speed = 0;
            gameObject.GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject, 2.8f);
            _explosionSource.Play();
        }

        Debug.Log("hit:" + other.transform.name);
    }
}
