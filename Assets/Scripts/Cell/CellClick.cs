using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wuziqi.Player;
using Wuziqi.Manager;
using Wuziqi.UI;

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
        private ShowUI ui;
        private bool isFull;
        private bool isWin;
        private void Start()
        {
            cellStatus = GetComponent<CellStatus>();
            playerStatus = FindObjectOfType<PlayerStatus>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            gameManager = FindObjectOfType<GameManager>();
            ui = FindObjectOfType<ShowUI>();
        }

        private void OnMouseDown()
        {
            // 如果棋盘为空，才允许点击
            if (cellStatus.status == ECellStatus.Status.None)
            {
                PlayChess();
                Check();
                playerStatus.changePlayer();
            }
        }
        
        private void PlayChess()
        {
            // 如果是黑棋，就将点击的棋盘变为黑色，并将棋盘状态置为黑色
            if (playerStatus.player == EPlayerStatus.Player.Black)
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

        private void Check()
        {
            string str;
            isFull = gameManager.isFull();
            //isWin = gameManager.isWin(playerStatus, this.gameObject, 3);
            isWin = true;
            if (isWin)
            {
                str = PlayerName() + "胜";
                ui.SendMessage("ShowWin", str);
            }
            else
            {
                if (isFull)
                {
                    str = "平手";
                    ui.SendMessage("ShowWin", str);
                }
            }
        }

        private string PlayerName()
        {
            if (playerStatus.player == EPlayerStatus.Player.Black)
                return "黑棋";
            else
                return "白棋";
        }
    }
}
