using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JinziqiLoad : ALoadLevelButton
{
    public override void LoadLevel()
    {
        SceneManager.LoadScene("jingziqi");
    }
}
