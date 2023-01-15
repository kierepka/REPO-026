using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum VisualState
{
    Looking = 1,
    Focus = 2,
    Observe = 3,
    Enjoy = 4
    
}

public class GameManager : MonoBehaviour
{
    [SerializeField] private VisualState _visualState = VisualState.Looking;
    [SerializeField] private OVRManager _ovrManager;
    public UnityEvent onVisualStateChange;
    public OVRInput.Controller controller;
    [SerializeField] private float _TriggerAxis;
    public void ChangeState(VisualState _newState)
    {
        //if the current state is the same as the new state, there's no need to change state
        if (_visualState == _newState) return;

        _visualState = _newState;
        onVisualStateChange.Invoke();

    }

    private void Update()
    {
        OVRInput.Update();
        _TriggerAxis = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, controller);
        
       // OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, controller);
        
       
        
        if (_visualState == VisualState.Looking) Looking_Update();
        if (_visualState == VisualState.Focus) Focus_Update();
        if (_visualState == VisualState.Observe) Observe_Update();
        if (_visualState == VisualState.Enjoy) Enjoy_Update();
    }

    private void Enjoy_Update()
    {
       
    }

    private void Observe_Update()
    {
        
    }

    private void Focus_Update()
    {
        
    }

    private void Looking_Update()
    {
       
    }
}
