using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLobby : MonoBehaviour
{
    public void ExitGame()
    {
        SceneManager.LoadScene(0);
        Cursor.visible = true;
    }
}
