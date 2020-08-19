using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{

    //　スタートボタンを押したら実行する
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void EndGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
    }
}