using UnityEngine;

public class GameData : MonoBehaviour
{
    #region Constants
    public const string VERTICAL_AXIS = "Vertical";
    public const string HORIZONTAL_AXIS = "Horizontal";
    public const string JUMP = "Jump";
    public const string FIRE = "Fire1";
    public const string RELOAD = "Fire2";
    #endregion

    public static GameData instance;
    
    public int currentScore = 0;
    public int currentRound = 0;

    public int hightScore;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }

    public void SaveData()
    {
        if (currentScore>hightScore)
        {
            PlayerPrefs.SetInt("Score", currentScore);
        }
    }

    public void LoadData()
    {
        hightScore = PlayerPrefs.GetInt("Score");
    }
}
