using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wuziqi.Cell
{
	/// <summary>
	/// 棋盘点击
	/// </summary>
	public class CellClick : MonoBehaviour
	{
        private void OnMouseDown()
        {
            print("Position: ( " + this.transform.position.x + " , " + this.transform.position.y + " )");
        }
    }
}
