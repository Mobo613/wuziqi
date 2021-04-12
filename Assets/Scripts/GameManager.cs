using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wuziqi.Cell;

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

		[Tooltip("获胜条件")]
		public int condition = 3;

		[Tooltip("棋盘间距")]
		public float distance = 1;

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
		public bool isWin(CellStatus cellStatus, GameObject obj)
        {
			int hengCount = 0;
			int shuCount = 0;
			int leftCount = 0;
			int rightCount = 0;

			float _x = obj.transform.position.x;
			float _y = obj.transform.position.y;
			float findX = _x;
			float findY = _y;

			List<GameObject> objList = new List<GameObject>();
			List<GameObject> findList = new List<GameObject>();

			foreach(var cell in cells)
            {
				if (cell.GetComponent<CellStatus>().status == cellStatus.status)
					objList.Add(cell);
            }
			
			/*横*/
			// 右边 x + 
			findX = _x;
			findY = _y;
			findList.Add(obj);
            while(true)
            {
				GameObject findobj = objList.Find(
					delegate (GameObject cell)
					{
						return cell.transform.position.x == findX+distance && cell.transform.position.y == findY;
					});
				if (findobj == null)
					break;
				findList.Add(findobj);
				findX += distance;

			}
			// 左边 x -
			findX = _x;
			findY = _y;
			while (true)
			{
				GameObject findobj = objList.Find(
					delegate (GameObject cell)
					{
						return cell.transform.position.x == findX - distance && cell.transform.position.y == findY;
					});
				if (findobj == null)
					break;
				findList.Add(findobj);
				findX -= distance;
			}
			hengCount = findList.Count;
			// 清空findList
			findList.Clear();

			/*竖*/
			// 上
			findX = _x;
			findY = _y;
			findList.Add(obj);
			while (true)
			{
				GameObject findobj = objList.Find(
					delegate (GameObject cell)
					{
						return cell.transform.position.x == findX && cell.transform.position.y == findY + distance;
					});
				if (findobj == null)
					break;
				findList.Add(findobj);
				findY += distance;
			}
			// 下
			findX = _x;
			findY = _y;
			while (true)
			{
				GameObject findobj = objList.Find(
					delegate (GameObject cell)
					{
						return cell.transform.position.x == findX && cell.transform.position.y == findY - distance;
					});
				if (findobj == null)
					break;
				findList.Add(findobj);
				findY -= distance;
			}
			shuCount = findList.Count;
			// 清空findList
			findList.Clear();

			/*斜率小于0*/
			// 左上
			findX = _x;
			findY = _y;
			findList.Add(obj);
			while (true)
			{
				GameObject findobj = objList.Find(
					delegate (GameObject cell)
					{
						return cell.transform.position.x == findX - distance && cell.transform.position.y == findY + distance;
					});
				if (findobj == null)
					break;
				findList.Add(findobj);
				findX -= distance;
				findY += distance;
			}
			// 右下
			findX = _x;
			findY = _y;
			while (true)
			{
				GameObject findobj = objList.Find(
					delegate (GameObject cell)
					{
						return cell.transform.position.x == findX + distance && cell.transform.position.y == findY - distance;
					});
				if (findobj == null)
					break;
				findList.Add(findobj);
				findX += distance;
				findY -= distance;
			}
			rightCount = findList.Count;
			// 清空findList
			findList.Clear();


			/*斜率大于0*/
			// 右上
			findX = _x;
			findY = _y;
			findList.Add(obj);
			while (true)
			{
				GameObject findobj = objList.Find(
					delegate (GameObject cell)
					{
						return cell.transform.position.x == findX + distance && cell.transform.position.y == findY + distance;
					});
				if (findobj == null)
					break;
				findList.Add(findobj);
				findX += distance;
				findY += distance;
			}
			// 左下
			findX = _x;
			findY = _y;
			while (true)
			{
				GameObject findobj = objList.Find(
					delegate (GameObject cell)
					{
						return cell.transform.position.x == findX - distance && cell.transform.position.y == findY - distance;
					});
				if (findobj == null)
					break;
				findList.Add(findobj);
				findX -= distance;
				findY -= distance;
			}
			leftCount = findList.Count;
			// 清空findList
			findList.Clear();

			if(hengCount == condition || shuCount == condition || rightCount == condition || leftCount == condition)
            {
				return true;
            }
            else
            {
				return false;
            }
		}
    }
}
