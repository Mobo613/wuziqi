using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wuziqi.Player;
using Wuziqi.Manager;
using Wuziqi.UI;
using System;

namespace Wuziqi.Cell
{
	/// <summary>
	/// 棋盘点击
	/// </summary>
	public class CellClick : MonoBehaviour
	{
        private CellStatus cellStatus;
        private PlayerStatus playerStatus;
        private SpriteRenderer spriteRenderer;
        private GameManager gameManager;
        private bool canPlay;

        private void Start()
        {
            cellStatus = GetComponent<CellStatus>();
            playerStatus = FindObjectOfType<PlayerStatus>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            gameManager = FindObjectOfType<GameManager>();
        }
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(
                    new Vector2
                    (Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                    Camera.main.ScreenToWorldPoint(Input.mousePosition).y),
                    Vector2.zero);
                // 如果棋盘为空，才允许点击
                try {
                    if (hit.collider.gameObject.GetComponent<CellStatus>().status == ECellStatus.Status.None)
                    {
                        PlayChess(hit.collider);
                        gameManager.SendMessage("Check", hit.collider.gameObject.GetComponent<CellStatus>());
                        playerStatus.SendMessage("ChangePlayer", true);
                        CanPlay(canPlay);
                    }
                }
                catch(NullReferenceException ex)
                {
                    return;
                }
            }
        }
        /*private void OnMouseDown()
        {
            print(isContinue);
            if (cellStatus.status == ECellStatus.Status.None && isContinue == true)
            {
                PlayChess();
                gameManager.SendMessage("Check", cellStatus);
                playerStatus.SendMessage("ChangePlayer", true);
                isContinue = CanPlay(canPlay);
            }
        }*/

        private void PlayChess()
        {
            // 如果是黑棋，就将点击的棋盘变为黑色，并将棋盘状态置为黑色
            if (PlayerStatus.player == EPlayerStatus.Player.Black)
            {
                cellStatus.status = ECellStatus.Status.Black;
                spriteRenderer.color = new Color(0, 0, 0);
            }
            // 如果是白棋，就将点击的棋盘变为白色，并将棋盘状态置为白色
            else
            {
                cellStatus.status = ECellStatus.Status.White;
                spriteRenderer.color = new Color(255, 255, 255);
            }
        }

        private void PlayChess(Collider2D collider)
        {
            // 如果是黑棋，就将点击的棋盘变为黑色，并将棋盘状态置为黑色
            if (PlayerStatus.player == EPlayerStatus.Player.Black)
            {
                collider.gameObject.GetComponent<CellStatus>().status = ECellStatus.Status.Black;
                print(collider.gameObject.GetComponent<CellStatus>().status);
                collider.gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);
            }
            // 如果是白棋，就将点击的棋盘变为白色，并将棋盘状态置为白色
            else
            {
                collider.gameObject.GetComponent<CellStatus>().status = ECellStatus.Status.White;
                collider.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
            }
        }

        private bool CanPlay(bool canPlay)
        {
            if (canPlay == false)
                this.enabled = false;
            return canPlay;
        }
    }
}
