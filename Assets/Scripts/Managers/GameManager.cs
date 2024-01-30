using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState gameState;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ChangeState(GameState.GenerateGrid);
    }

    public void ChangeState(GameState newState)
    {
        gameState = newState;
        switch (newState)
        {
            case GameState.GenerateGrid:
                GridManager.Instance.GenerateGrid();
                break;
            case GameState.SpawnPlayer:
                UnitManager.Instance.SpawnPlayer();
                break;
            case GameState.SpawnObstacles:
                UnitManager.Instance.SpawnObstacles();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState));
        }
    }
}

public enum GameState
{
    GenerateGrid = 0,
    SpawnPlayer = 1,
    SpawnObstacles = 2
}
