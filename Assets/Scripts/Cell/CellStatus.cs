using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wuziqi.Cell
{
	/// <summary>
	/// 棋盘状态
	/// </summary>
	public class CellStatus : MonoBehaviour
	{
		[Tooltip("棋盘状态")]
		public ECellStatus.Status status;

        private void Start()
        {
			// 开始将棋盘全部设置为空
			status = ECellStatus.Status.None;
        }
    }
}
