using System;
using UnityEngine;
using UnityEngine.Events;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color _white, _black;
    [SerializeField] private SpriteRenderer _spRenderer;
    [SerializeField] private GameObject _highlightObject;
    private Color _thisTileColor;
    private GameObject _enemy;
    private PieceType _currentPieceType;
    private Vector2 _tilePosition;

    public UnityEvent<Vector2> OnTileClick = new UnityEvent<Vector2>();

    private void Start()
    {
        _spRenderer.color = _thisTileColor;
    }

    public void GetColor(bool isBlack)
    {
        _thisTileColor = isBlack ? _black : _white;
    }

    void OnMouseEnter()
    {
        LeanTween.cancel(_highlightObject);

        if (_thisTileColor == _black)
            _highlightObject.LeanAlpha(0.55f, 0.1f);
        else
            _highlightObject.LeanAlpha(0.7f, 0.1f);
    }

    void OnMouseExit()
    {
        LeanTween.cancel(_highlightObject);
        _highlightObject.LeanAlpha(0f, 0.5f);
    }

    private void OnMouseDown()
    {
        OnTileClick.Invoke(_tilePosition);
    }

    public void SetEnemy(GameObject newEnemy, PieceType newPieceType)
    {
        _enemy = newEnemy;
        _currentPieceType = newPieceType;
    }

    public bool HasEnemy()
    {
        return _enemy != null;
    }

    public GameObject GetEnemy()
    {
        return _enemy;
    }

    public PieceType GetCurrentPieceType()
    {
        return _currentPieceType;
    }
}