using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wuziqi.Player;
using Wuziqi.Manager;

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
        private void Start()
        {
            cellStatus = GetComponent<CellStatus>();
            playerStatus = FindObjectOfType<PlayerStatus>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            gameManager = FindObjectOfType<GameManager>();
        }

        private void OnMouseDown()
        {
                print("Position: ( " + this.transform.position.x + " , " + this.transform.position.y + " )");
                print("Before CellStatus: " + cellStatus.status);
                print("Before Player: " + playerStatus.player);

            // 如果棋盘为空，才允许点击
            if(cellStatus.status == ECellStatus.Status.None)
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
                print("After CellStatus: " + cellStatus.status);
                print("isFull: " + gameManager.isFull());

                playerStatus.changePlayer();
                print("After Player: " + playerStatus.player);
            }
        }
    }
}
