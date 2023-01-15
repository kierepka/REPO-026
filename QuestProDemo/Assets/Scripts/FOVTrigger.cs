using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVTrigger : MonoBehaviour
{
    public List<AudioSource> audioSources = new List<AudioSource>();
    [SerializeField] private GameManager _gameManager;
    private bool _soundsOff;
    void OnTriggerEnter(Collider other)
    {

        AudioSource audio = other.gameObject.GetComponent<AudioSource>();
        if (audio != null)
        {
            if (!audio.isPlaying)
            {
                audio.Play();
                audioSources.Add(audio);
            }
        }
        
           
    }

    void OnTriggerExit(Collider other)
    {

        AudioSource audio = other.gameObject.GetComponent<AudioSource>();
        if (audio != null)
        { 
            if (audio.isPlaying)
            {
                audio.Stop();
                audioSources.Remove(audio);
            }
        }

    }

    
}
