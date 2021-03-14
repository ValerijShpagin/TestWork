using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private Canvas _canvasGameOver;
    [SerializeField] private Player _player;
    [SerializeField] private SpawnerEnemy _spawnerEnemy;
    [SerializeField] StateGame _state;

    //---------------------------------------------------------------------------------------------

    private enum StateGame
    { 
        Start,
        GameOver
    }

    //---------------------------------------------------------------------------------------------

    private void Start()
    {
        _state = StateGame.Start;
        _canvasGameOver.gameObject.SetActive(false);
    }

    //---------------------------------------------------------------------------------------------

    private void Update()
    {
        CheckStatusGame();
    }

    //---------------------------------------------------------------------------------------------

    private void CheckStatusGame()
    {
        if (!_player)
        {
            _state = StateGame.GameOver;
            _spawnerEnemy.DestroyObjects();
            _canvasGameOver.gameObject.SetActive(true);
        }

        else
        {
            _state = StateGame.Start;
        }

    }

    //---------------------------------------------------------------------------------------------

    // TODO Exit
    private void ExitGame()
    {
        Application.Quit();
    }

    //---------------------------------------------------------------------------------------------

    public void Restart()
    {
        string nameScene =  SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(nameScene);
        
    }

    //---------------------------------------------------------------------------------------------
}
