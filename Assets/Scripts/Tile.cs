using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color _white, _black;
    [SerializeField] private SpriteRenderer _spRenderer;
    [SerializeField] private GameObject _highlight;

    public void InitiateColors(bool isBlack)
    {
        _spRenderer.color = isBlack ? _black : _white;
    }

    void OnMouseEnter()
    {
        _highlight.SetActive(true);
    }

    void OnMouseExit()
    {
        _highlight.SetActive(false);
    }
}
