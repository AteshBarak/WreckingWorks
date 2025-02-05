using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Text levelText;

    private int fakeLevel = 1;

    private void Start()
    {
        if (PlayerPrefs.HasKey("FakeLevel"))
        {
            fakeLevel = PlayerPrefs.GetInt("FakeLevel");
        }
        else
        {
            PlayerPrefs.SetInt("FakeLevel", fakeLevel);
        }

        PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex);

        levelText.text = "Level " + fakeLevel;
    }

    public void NextLevel()
    {
        ChangeLevel();
    }

    private void ChangeLevel()
    {
        fakeLevel++;
        PlayerPrefs.SetInt("FakeLevel", fakeLevel);

        if (SceneManager.GetActiveScene().buildIndex == (SceneManager.sceneCountInBuildSettings - 1))
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
