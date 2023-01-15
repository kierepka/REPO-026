using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVTrigger : MonoBehaviour
{
    //public AudioClip audioClip;
    public List<AudioSource> audioSources = new List<AudioSource>();

    void OnTriggerEnter(Collider other)
    {

        AudioSource audio = other.gameObject.GetComponent<AudioSource>();
        if (audio != null)
        {
            Debug.Log($"{other.gameObject.name} playing" );
            if (!audio.isPlaying)
            {
                audio.Play();
            }
        }
        
        
        //
        // if (other.gameObject.CompareTag("Objects"))
        // {
        //     Debug.Log(other.gameObject.name);
        //     
        //     AudioSource[] sources = other.gameObject.GetComponentsInChildren<AudioSource>();
        //     for (int i = 0; i < sources.Length; i++)
        //     {
        //         if (sources[i].isPlaying)continue;
        //         sources[i].Play();
        //     }
        // }
           
    }

    void OnTriggerExit(Collider other)
    {
        // if (other.gameObject.CompareTag("Objects"))
        // {
        //     AudioSource[] sources = other.gameObject.GetComponentsInChildren<AudioSource>();
        //     for (int i = 0; i < sources.Length; i++)
        //     {
        //         
        //         if (!sources[i].isPlaying)
        //         {
        //             //audioSource.clip = audioClip;
        //             sources[i].Stop();
        //         }
        //     }
        //     
        // }
        
        AudioSource audio = other.gameObject.GetComponent<AudioSource>();
        if (audio != null)
        { 
            Debug.Log($"{other.gameObject.name} stops playing" );
            if (audio.isPlaying)
            {
                audio.Stop();
            }
        }
        
        
        
    }

    void Update()
    {
        
    }
}
