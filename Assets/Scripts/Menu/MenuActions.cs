using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuActions : MonoBehaviour
{
    public void Adventure()
    {
        SceneManager.LoadScene("Level1");
    }

    public void MiniGames() { }

    public void Puzzle() { }

    public void Survival() { }
}
