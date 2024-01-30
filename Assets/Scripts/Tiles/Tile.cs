using System;
using UnityEngine;
using UnityEngine.Events;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color _white, _black;
    [SerializeField] private SpriteRenderer _spRenderer;
    [SerializeField] private GameObject _highlight;
    private Color _thisTileColor;
    
    public UnityEvent<Vector2> OnTileClick = new UnityEvent<Vector2>();
    private Vector2 tilePosition;

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
        LeanTween.cancel(_highlight);
        
        if (_thisTileColor == _black)
            _highlight.LeanAlpha(0.55f, 0.1f);
        else
            _highlight.LeanAlpha(0.7f, 0.1f);
    }

    void OnMouseExit()
    {
        LeanTween.cancel(_highlight);
        
        _highlight.LeanAlpha(0f, 0.5f);
    }

    private void OnMouseDown()
    {
        OnTileClick.Invoke(tilePosition);
    }
}