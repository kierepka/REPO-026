using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum VisualState
{
    Looking = 1,
    Focus = 2,
    Observe = 3,
    Immerse = 4
    
}

public class GameManager : MonoBehaviour
{
    [SerializeField] private VisualState _visualState = VisualState.Looking;

    public void ChangeState(VisualState _newState)
    {
        //if
        if (_visualState == _newState) return;
        
    }
    
}
