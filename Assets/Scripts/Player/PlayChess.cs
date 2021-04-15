using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wuziqi.Manager;
using System;
using Wuziqi.Cell;

namespace Wuziqi.Player
{
	/// <summary>
	/// 棋盘点击
	/// </summary>
	public class PlayChess : MonoBehaviour
	{
        private PlayerManager playerManager;
        private GameManager gameManager;
        private PlayerStatus player;

        private void Start()
        {
            gameManager = FindObjectOfType<GameManager>();
            playerManager = FindObjectOfType<PlayerManager>();
            player = GetComponent<PlayerStatus>();
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
                        Play(hit.collider);
                        gameManager.SendMessage("Check", hit.collider.gameObject.GetComponent<CellStatus>());
                        playerManager.SendMessage("ChangePlayer");
                    }
                }
                catch(NullReferenceException)
                {
                    return;
                }
            }
        }
        private void Play(Collider2D collider)
        {
            // 如果是黑棋，就将点击的棋盘变为黑色，并将棋盘状态置为黑色
            if (player.player == EPlayerStatus.Player.Black)
            {
                collider.gameObject.GetComponent<CellStatus>().status = ECellStatus.Status.Black;
                collider.gameObject.GetComponent<SpriteRenderer>().color = player.getPlayerColor();
            }
            // 如果是白棋，就将点击的棋盘变为白色，并将棋盘状态置为白色
            else
            {
                collider.gameObject.GetComponent<CellStatus>().status = ECellStatus.Status.White;
                collider.gameObject.GetComponent<SpriteRenderer>().color = player.getPlayerColor();
            }
        }
    }
}
