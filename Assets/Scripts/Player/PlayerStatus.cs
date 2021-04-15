using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wuziqi.Player
{
	/// <summary>
	///	哪个玩家
	/// </summary>
	public class PlayerStatus : MonoBehaviour
	{
		[Tooltip("哪个玩家")]
		public EPlayerStatus.Player player;

		public Color getPlayerColor()
        {
			if (player == EPlayerStatus.Player.Black)
				return new Color(0, 0, 0);
			else
				return new Color(255, 255, 255);
        }

		public string getPlayerName()
		{
			if (player == EPlayerStatus.Player.Black)
				return "黑棋";
			else
				return "白棋";
		}
	}
}
