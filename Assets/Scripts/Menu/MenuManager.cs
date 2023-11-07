using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private GameObject _levelSelect;
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _winMenu;
    [SerializeField] private Button[] _levels;

    public List<bool> levelsUnlocked = new List<bool>(4);
    private List<bool> _buttonSetted = new List<bool>(4) { false, false, false, false };
    private void Awake()
    {
        _levelSelect.SetActive(false);
        _winMenu.SetActive(false);
        LevelsUpdate();
        _gameManager.HideGame();
        
    }
    public void ShowMain()
    {
        _winMenu.SetActive(false);
        _mainMenu.SetActive(true);
    }
    public void ShowWin()
    {
        _levelSelect.SetActive(false);
        _winMenu.SetActive(true);
    }
    public void SelectLevels()
    {
        _levelSelect.SetActive(true);
        _mainMenu.SetActive(false);
    }
    public void UnlockLevel(int id)
    {
        levelsUnlocked[id] = true;
        LevelsUpdate();
    }
    public void LevelsUpdate()
    {
        for (int i = 0; i < _levels.Length; i++)
        {
            Button localbutton = _levels[i];
            if (_buttonSetted[i] == false)
            {
                if (levelsUnlocked[i] == true)
                {
                    localbutton.onClick.AddListener(() => NewGameClick(localbutton));
                    _levels[i].transform.GetComponent<Image>().color = Color.green;
                    _buttonSetted[i] = true;
                }
                else
                    _levels[i].transform.GetComponent<Image>().color = Color.gray;
            }
            
        }
    }
    public void NewGameClick(Button button)
    {
        int levelId = int.Parse(button.transform.GetChild(1).name);
        _gameManager.ShowGame(levelId);
    }
}
