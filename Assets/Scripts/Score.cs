using UnityEngine;

public class Score : MonoBehaviour
{
    public int currentScore;
    public GameObject player;

    void OnGUI()
    {
        GUI.Label(new Rect(-24, 50, 100, 10), "Score: " + currentScore);
    }
}
