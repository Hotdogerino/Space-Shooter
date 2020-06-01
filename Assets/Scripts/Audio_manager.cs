using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_manager : MonoBehaviour
{
    [SerializeField]
    public AudioSource laserSource, explosionSource, powerupSource;
    [SerializeField]
    public AudioClip laserClip, explosionClip, powerupClip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayLaserAudio()
    {
        laserSource.PlayOneShot(laserClip);
    }
    public void PlayExplosionAudio()
    {
        explosionSource.PlayOneShot(explosionClip);
    }
    public void PlayPowerupAudio()
    {
        powerupSource.PlayOneShot(powerupClip);
    }

}
