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

        private void Start()
        {
			// 设置黑棋为先手
			player = EPlayerStatus.Player.Black;
        }

		public void changePlayer()
        {
			if (player == EPlayerStatus.Player.Black)
				player = EPlayerStatus.Player.White;
			else
				player = EPlayerStatus.Player.Black;
        }
    }
}
