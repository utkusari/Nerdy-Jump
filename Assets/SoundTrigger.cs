using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{

    public AudioClip gameOver;
    public AudioClip bounce;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.relativeVelocity.y >= 0f){
            if (collision.gameObject.tag == "Platform"){
                audioSource.PlayOneShot(bounce, 0.5f);
            }
            if (collision.gameObject.tag == "Deadzone"){
                audioSource.PlayOneShot(gameOver, 0.5f);
            }
        }
    }
}
