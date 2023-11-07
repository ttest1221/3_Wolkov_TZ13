using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _gamePrototype;
    [SerializeField] private GameObject _gameScreen;
    [SerializeField] private GameObject _menuScreen;
    [SerializeField] private CubeMove _cubeMove;
    [SerializeField] private MenuManager _menuManager;
    private GameObject game;
    private int _currentLevel;

    public void ShowGame(int level)
    {
        _gameScreen.SetActive(true);
        _menuScreen.SetActive(false);
        _currentLevel = level+1;
        game = Instantiate(_gamePrototype[level], new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
        _cubeMove._cube = FindAnyObjectByType<Cube>();
    }
    public void HideGame()
    {
        _gameScreen.SetActive(false);
        _menuScreen.SetActive(true);
    }
    
    public void GameOver(bool isCompleted)
    {
        Destroy(game);
        if(isCompleted == true && _currentLevel < _menuManager.levelsUnlocked.Count)
            _menuManager.UnlockLevel(_currentLevel);
        if (_currentLevel == _menuManager.levelsUnlocked.Count)
            _menuManager.ShowWin();
        HideGame();
    }
    
}
