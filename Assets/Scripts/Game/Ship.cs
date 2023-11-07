using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    private GameManager _gameManager;
    private void Start()
    {
        _gameManager = FindAnyObjectByType<GameManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Cube")
            _gameManager.GameOver(false);
    }
}
