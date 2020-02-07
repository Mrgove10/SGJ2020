using UnityEngine;

public class Manager : MonoBehaviour
{
    public int points;

    public int time = 250;
    
    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating(nameof(RemoveTime), 1.0f, 1.0f);
    }

    private void RemoveTime()
    {
        if(time > 0) {
            time -= 1;
        }
        else if(time <=0)
        {
            GameOver();
        }
    }
    
    public void GameOver()
    {
        Debug.Log("GAMEOVER");
    }
}