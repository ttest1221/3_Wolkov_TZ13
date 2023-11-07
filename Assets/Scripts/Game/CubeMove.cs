using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    public Cube _cube;
    private void Update()
    {
        
    }
    private void OnMouseDrag()
    {
        if(_cube != null)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _cube.transform.position = Vector2.MoveTowards(_cube.transform.position, mousePosition, 3 * Time.deltaTime);
            Time.timeScale = 1f;
        }      
    }
    private void OnMouseUp()
    {
        Time.timeScale = 0.3f;
    }
}
