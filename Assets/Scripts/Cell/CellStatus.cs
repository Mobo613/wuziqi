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
		public ECellStatus.Status status;

        private void Start()
        {
			status = ECellStatus.Status.None;
        }
    }
}
