using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WuziqiLoad : ALoadLevelButton
{
    public override void LoadLevel()
    {
        SceneManager.LoadScene("wuziqi");
    }
}
