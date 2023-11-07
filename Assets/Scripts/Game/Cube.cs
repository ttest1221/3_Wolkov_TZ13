using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private GameManager _gameManager;
    private void Awake()
    {
        _gameManager = FindAnyObjectByType<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Exit")
            _gameManager.GameOver(true);
    }
}
