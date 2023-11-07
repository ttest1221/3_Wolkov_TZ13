using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    
    private Transform _transform;
    private void Start()
    {
        _transform = GetComponent<Transform>();
        
    }
    private void Update()
    {
        _transform.Rotate(0,0, 40f * Time.deltaTime);
    }
    
}
