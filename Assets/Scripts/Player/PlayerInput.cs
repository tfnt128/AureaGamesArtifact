using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private void Start()
    {
        throw new NotImplementedException();
    }

    private bool _isPlayerMoving = false;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 rayPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(rayPosition, Vector2.zero);
            
            if (hit.collider != null)
            {
                Tile clickedTile = hit.collider.GetComponent<Tile>();
                if (clickedTile != null)
                {
                    MovePlayerToTile(clickedTile);
                }
            }
        }
    }

    private void MovePlayerToTile(Tile clickedTile)
    {
        if (_isPlayerMoving) return;

        _isPlayerMoving = true;

        Vector3 currentPos = gameObject.transform.position;
        Vector3 targetPos = clickedTile.transform.position;

        var pieceType = UnitManager.Instance.PlayerData.scriptableUnit.Piece;

        bool isValidMove = false;

        switch (pieceType)
        {
            case PieceType.Queen:
                isValidMove = MovementsManager.Instance.IsQueenMovement(currentPos, targetPos);
                break;
            case PieceType.Bishop:
                isValidMove = MovementsManager.Instance.IsBishopMovement(currentPos, targetPos);
                break;
            case PieceType.Rook:
                isValidMove = MovementsManager.Instance.IsRookMovement(currentPos, targetPos);
                break;
            case PieceType.Pawn:
                isValidMove = MovementsManager.Instance.IsPawnMovement(currentPos, targetPos);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        if (isValidMove)
        {
            MovePiece(targetPos);
        }
        else
        {
            Debug.Log("Movement Out of Bounds.");
            _isPlayerMoving = false; 
        }
    }


    private void MovePiece(Vector3 targetPos)
    {
        _isPlayerMoving = true; 
        
        LeanTween.move(gameObject, targetPos, 1.0f)
            .setEase(LeanTweenType.easeOutQuad) 
            .setOnComplete(() => 
            {
                _isPlayerMoving = false;
            });
    }
}
