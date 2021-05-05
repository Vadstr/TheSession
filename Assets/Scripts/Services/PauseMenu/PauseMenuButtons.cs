using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuButtons : MonoBehaviour
{
    public GameObject Player;
    public void ContinueGame()
    {
        DebugScript.UnPause();
    }
    
    public void SaveGame()
    {
        SavePlayerData.CoordinateOnScene = Player.transform.position;
        SavePlayerData.LocationID = SceneManager.GetActiveScene().buildIndex;
        new SaveSerializable().SaveGame();
    }
    
    public void ExitToMenu()
    {
        DebugScript.UnPause();
        SceneManager.LoadScene(0);
    }
}
