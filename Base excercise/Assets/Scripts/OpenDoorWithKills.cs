using UnityEngine;

public class OpenDoorWithKills : MonoBehaviour
{
    public static OpenDoorWithKills instance;
    public int enemiesKilled = 0;
    public int enemiesToKill = 13;
    public int enemiesToKillForVictory = 16;
    public GameObject door;
    public Canvas VictoryCanvas;

    private void Start()
    {
        VictoryCanvas.gameObject.SetActive(false);
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (enemiesKilled >= enemiesToKill)
        {
            // Trigger door opening animation or destroy door object
            Destroy(door);
        }
        if(enemiesKilled >= enemiesToKillForVictory)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            VictoryCanvas.gameObject.SetActive(true);
        }
    }
    public void KillEnemy()
    {
        enemiesKilled++;
    }
}
