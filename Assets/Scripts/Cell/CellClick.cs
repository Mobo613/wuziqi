using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wuziqi.Player;

namespace Wuziqi.Cell
{
	/// <summary>
	/// 棋盘点击
	/// </summary>
	public class CellClick : MonoBehaviour
	{
        private CellStatus cellStatus;
        private PlayerStatus playerStatus;
        private void Start()
        {
            cellStatus = GetComponent<CellStatus>();
            playerStatus = FindObjectOfType<PlayerStatus>();
        }
        private void OnMouseDown()
        {
            print("Position: ( " + this.transform.position.x + " , " + this.transform.position.y + " )");
            print("CellStatus: " + cellStatus.status);

            playerStatus.changePlayer();
            print("Player: " + playerStatus.player);
        }
    }
}
