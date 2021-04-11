using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wuziqi.Cell;
using Wuziqi.Player;

namespace Wuziqi.Manager
{
	/// <summary>
	/// 游戏管理器
	/// </summary>
	public class GameManager : MonoBehaviour
	{
		/// <summary>
		/// 保存棋盘所有的格子
		/// </summary>
		private GameObject[] cells;

		private void Start()
		{
			cells = GameObject.FindGameObjectsWithTag("cell");
		}

		/// <summary>
		/// 检查是否所有格子都填满
		/// </summary>
		public bool isFull()
        {
			foreach(var cell in cells)
            {
				if(cell.GetComponent<CellStatus>().status == ECellStatus.Status.None)
                {
					return false;
                }
            }
			return true;
        }

		/// <summary>
		/// 检查是否获胜
		/// </summary>
		/// <returns></returns>
		public bool isWin(PlayerStatus player,  GameObject obj, int condition)
        {
			int hengCount = 0;
			int shuCount = 0;
			int leftCount = 0;
			int rightCount = 0;
			List<GameObject> objList = new List<GameObject>();
			ECellStatus.Status checkStatus;
			if (player.player == EPlayerStatus.Player.Black)
				checkStatus = ECellStatus.Status.Black;
			else
				checkStatus = ECellStatus.Status.White;

			// 通过检查横、竖、左斜、右斜来检查是否获胜
			foreach(var cell in cells)
            {
				if (cell.GetComponent<CellStatus>().status == checkStatus)
                {
					objList.Add(cell);
                }
            }
			foreach(var o in objList)
            {
				print(o.transform.position);
            }
			return true;
        }
    }
}
