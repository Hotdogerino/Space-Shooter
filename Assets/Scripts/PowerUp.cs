using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    [SerializeField]
    private float _speed = 3f;
    [SerializeField]
    private int PowerupID;
    [SerializeField]
    private AudioClip _audioClip;
    //private Player _player;        find EW
    // Start is called before the first frame update
    //void Start()
    //{
    //    // _player = GameObject.Find("Player").GetComponent<Player>();             it uses find EWEEWEWWWWWWWWWWWWWWWWWWEWEWWWEDwe

    //}
    private void Start()
    {


    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y <= -4.5)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.transform.GetComponent<Player>();
            if (player != null)
            {
                AudioSource.PlayClipAtPoint(_audioClip, transform.position);
                if (PowerupID == 0)
                {
                    player.TripleShotIsNowActive();

                }
                else if (PowerupID == 1)
                {
                    player.SpeedIsNowActive();

                }
                else if (PowerupID == 2)
                {
                    player.ShieldIsNowActive();

                }
            }
            else
            {
                Debug.LogError("Player is null");
            }

            Destroy(gameObject);
        }
    }
}
