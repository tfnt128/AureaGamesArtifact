using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState CurrentGameState { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ChangeState(GameState.GenerateGrid);
    }

    public void ChangeState(GameState newState = GameState.None)
    {
        if (newState != GameState.None)
            CurrentGameState = newState;

        switch (CurrentGameState)
        {
            case GameState.GenerateGrid:
                GridManager.Instance.GenerateGrid();
                break;
            case GameState.SpawnPlayer:
                UnitManager.Instance.SpawnPlayer();
                break;
            case GameState.SpawnEnemies:
                UnitManager.Instance.SpawnEnemies();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(CurrentGameState));
        }
    }
}

public enum GameState
{
    None = -1,
    GenerateGrid = 0,
    SpawnPlayer = 1,
    SpawnEnemies = 2
}