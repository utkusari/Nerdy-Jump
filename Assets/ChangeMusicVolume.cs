using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMusicVolume : MonoBehaviour
{
    
    public Slider volume;
    public AudioSource themeMusic;

    // Update is called once per frame
    void Update()
    {
        themeMusic.volume = volume.value;
    }
}
