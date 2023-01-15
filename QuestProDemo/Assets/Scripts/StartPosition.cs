using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPosition : MonoBehaviour
{
    [SerializeField] private GameObject _startingPositionAnchor;
    // Start is called before the first frame update
    void Awake()
    {
        transform.position = _startingPositionAnchor.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
