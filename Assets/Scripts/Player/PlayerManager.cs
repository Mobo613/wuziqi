using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wuziqi.Player
{
    public class PlayerManager : MonoBehaviour
    {
        private GameObject blackPlayer;
        private GameObject whitePlayer;
        private EPlayerStatus.Player isOn;
        private bool startPlay = true;
        private void Start()
        {
            blackPlayer = GameObject.Find("Black");
            whitePlayer = GameObject.Find("White");
            isOn = EPlayerStatus.Player.Black;
            blackPlayer.GetComponent<PlayChess>().enabled = true;
            whitePlayer.GetComponent<PlayChess>().enabled = false;
        }

        private void ChangePlayer()
        {
            if (!continueChess(startPlay)) return;
            if(isOn == EPlayerStatus.Player.Black)
            {
                blackPlayer.GetComponent<PlayChess>().enabled = false;
                whitePlayer.GetComponent<PlayChess>().enabled = true;
                isOn = EPlayerStatus.Player.White;
            }
            else
            {
                blackPlayer.GetComponent<PlayChess>().enabled = true;
                whitePlayer.GetComponent<PlayChess>().enabled = false;
                isOn = EPlayerStatus.Player.Black;
            }
        }

        private bool continueChess(bool isContinue)
        {
            if(isContinue == false)
            {
                blackPlayer.SetActive(isContinue);
                whitePlayer.SetActive(isContinue);
            }
            return isContinue;
        }

        public string getPlayerName()
        {
            if (isOn == EPlayerStatus.Player.Black)
                return blackPlayer.GetComponent<PlayerStatus>().getPlayerName();
            else
                return whitePlayer.GetComponent<PlayerStatus>().getPlayerName();
        }
    }
}
