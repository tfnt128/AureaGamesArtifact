using System;
using System.Collections;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private GameObject destroyEffect;
    private bool _isPlayerMoving = false;
    private SpriteRenderer _playerSprite;

    private void Start()
    {
        _playerSprite = GetComponent<SpriteRenderer>();
    }

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

        var pieceType = UnitManager.Instance.playerData.scriptableUnit.Piece;

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
            case PieceType.Knight:
                isValidMove = MovementsManager.Instance.IsKnightMovement(currentPos, targetPos);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        Tile targetTile = GridManager.Instance.GetTileAtPosition(targetPos);

        if (isValidMove && targetTile != null)
        {
            if (targetTile.HasEnemy())
            {
                DestroyEnemy(targetTile);
            }
            else
            {
                MovePiece(targetPos);
            }
        }
        else
        {
            Debug.Log("Invalid Movement.");
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

    private void DestroyEnemy(Tile targetTile)
    {
        if (targetTile != null && targetTile.HasEnemy())
        {
            GameObject enemy = targetTile.GetEnemy();
            Sprite enemySprite = GetEnemySprite(enemy);

            UnitManager.Instance.playerData.scriptableUnit.Piece = targetTile.GetCurrentPieceType();

            StartCoroutine(DestroyAndEffectTimer(enemy, targetTile.transform, enemySprite));
            
            targetTile.SetEnemy(null, PieceType.Empty);
        }

        MovePiece(targetTile.transform.position);
    }

    private Sprite GetEnemySprite(GameObject enemy)
    {
        Transform firstChild = enemy.transform.GetChild(0);
        return firstChild.GetComponent<SpriteRenderer>().sprite;
    }

    IEnumerator DestroyAndEffectTimer(GameObject enemy, Transform effectPos, Sprite playerNewSprite)
    {
        yield return new WaitForSeconds(0.75f);
        _playerSprite.sprite = playerNewSprite;
        Instantiate(destroyEffect, effectPos.position, Quaternion.identity);
        
        Destroy(enemy);
    }
}
