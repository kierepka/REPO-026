using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusState : MonoBehaviour
{
  
    [SerializeField] private GameManager _gameManager;
    public void PassGameObject()
    {
        _gameManager._onFocus = this.gameObject.GetComponent<AudioSource>();
    }

    public void CancelGameObject()
    {
        if(_gameManager._onFocus != null) _gameManager._onFocus = null;
    }

    public void OnHaptics()
    {
        Debug.Log("On Haptics");
        StartCoroutine(onHaptics());
    }

    IEnumerator onHaptics()
    {
        OVRInput.SetControllerVibration(0.3f, 0.3f, _gameManager.controller);
        yield return new WaitForSeconds(0.35f);
        OVRInput.SetControllerVibration(0, 0, _gameManager.controller);
    }
    
    public void OffHaptics()
    {
        
    }
}
