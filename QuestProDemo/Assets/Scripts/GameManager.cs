using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum VisualState
{
    Looking = 1,
    Focus = 2,
    Enjoy = 3
    
}

public class GameManager : MonoBehaviour
{
    [SerializeField] private VisualState _visualState = VisualState.Looking;
    [SerializeField] private OVRManager _ovrManager;
    public UnityEvent onVisualStateChange;
    public OVRInput.Controller controller;
    public bool _turnOffFOVSounds = false;
    private float _TriggerAxis;
    private float _GrabAxis;
    [SerializeField] private GameObject _fovCone;
    [SerializeField] private FOVTrigger _fovTrigger;

    public AudioSource _onFocus = null;
    private bool audioPlayed = false;

    [SerializeField] private GameObject[] _RayController;

    public void ChangeState(VisualState _newState)
    {
        //if the current state is the same as the new state, there's no need to change state
        if (_visualState == _newState) return;

        _visualState = _newState;
        onVisualStateChange.Invoke();

        if (_newState == VisualState.Looking) Looking_Start();
        if (_newState == VisualState.Focus) Focus_Start();
        if (_newState == VisualState.Enjoy) Enjoy_Start();
    }

    private void Enjoy_Start()
    {
        foreach (var controllers in _RayController)
        {
            controllers.SetActive(false);
        }
    }

    private void Focus_Start()
    {
        
        _fovCone.SetActive(false);
        AudioSource[] allAudioSources = UnityEngine.Object.FindObjectsOfType<AudioSource>();
        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.Pause();
            
        }
        
        foreach (var controllers in _RayController)
        {
            controllers.SetActive(true);
        }
        

        
        
        
    }

    private void Looking_Start()
    {
        foreach (var controllers in _RayController)
        {
            controllers.SetActive(false);
        }
    }

    private void Update()
    {
        OVRInput.Update();
        
        //Grab
       // _TriggerAxis = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, controller);
        _GrabAxis = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, controller);
        if(OVRInput.Get(OVRInput.Button.One, controller)) Debug.Log("button down");

        if (_GrabAxis >= 0.95)
        {
            ChangeState(VisualState.Focus);
            
        } else if (_GrabAxis < 0.95)
        {
            ChangeState(VisualState.Looking);
        }
        
        //On Trigger Enter, from another script change this state to enjoy

        if (_visualState == VisualState.Looking) Looking_Update();
        if (_visualState == VisualState.Focus) Focus_Update();
        if (_visualState == VisualState.Enjoy) Enjoy_Update();
    }

    private void Enjoy_Update()
    {
        _turnOffFOVSounds = false;
        _fovCone.SetActive(true);
        // Turn on particles. Change mouse click input to transform position of triggered object

    }
    

    private void Focus_Update()
    {

        //haptic feedback
        //lower volume of all audio sources
        //increase volume of focused object's

    }

    IEnumerator Focus_Update_Routine()
    {
        foreach (var audio in _fovTrigger.audioSources)
        {
            audio.Stop();
        }

        yield return new WaitForEndOfFrame();
        
        _fovCone.SetActive(false);
    }

    private void Looking_Update()
    {
         
        _fovCone.SetActive(true);
       
    }
}
