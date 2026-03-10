using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelMapManager : MonoBehaviour
{
    [Header("Level Buttons")]
    public Button levelNode1;
    public Button levelNode2;
    public Button levelNode3;
    public Button levelNode4;
    public Button levelNode5;

    [Header("Paths")]
    public Image path1;
    public Image path2;
    public Image path3Left;
    public Image path4Right;

    [Header("Colors")]
    public Color lockedColor = new Color(0.18f, 0.24f, 0.18f, 1f);
    public Color unlockedColor = new Color(0.30f, 0.69f, 0.31f, 1f);
    public Color completedColor = new Color(0.72f, 0.83f, 0.42f, 1f);

    public Color lockedPathColor = new Color(0.50f, 0.50f, 0.50f, 0.75f);
    public Color unlockedPathColor = new Color(0.80f, 0.95f, 0.75f, 1f);

    void Start()
    {
        PlayerPrefs.DeleteAll();
        UpdateLevelMap();
    }

    public void UpdateLevelMap()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        int completedLevel = PlayerPrefs.GetInt("CompletedLevel", 0);

        SetupLevelButton(levelNode1, 1, unlockedLevel, completedLevel);
        SetupLevelButton(levelNode2, 2, unlockedLevel, completedLevel);
        SetupLevelButton(levelNode3, 3, unlockedLevel, completedLevel);
        SetupLevelButton(levelNode4, 4, unlockedLevel, completedLevel);
        SetupLevelButton(levelNode5, 5, unlockedLevel, completedLevel);

        if (path1 != null)
            path1.color = unlockedLevel >= 2 ? unlockedPathColor : lockedPathColor;

        if (path2 != null)
            path2.color = unlockedLevel >= 3 ? unlockedPathColor : lockedPathColor;

        if (path3Left != null)
            path3Left.color = unlockedLevel >= 4 ? unlockedPathColor : lockedPathColor;

        if (path4Right != null)
            path4Right.color = unlockedLevel >= 5 ? unlockedPathColor : lockedPathColor;
    }

    private void SetupLevelButton(Button button, int levelNumber, int unlockedLevel, int completedLevel)
    {
        if (button == null) return;

        bool isUnlocked = levelNumber <= unlockedLevel;
        bool isCompleted = levelNumber <= completedLevel;

        button.interactable = isUnlocked;

        Image buttonImage = button.GetComponent<Image>();
        if (buttonImage != null)
        {
            if (isCompleted)
                buttonImage.color = completedColor;
            else if (isUnlocked)
                buttonImage.color = unlockedColor;
            else
                buttonImage.color = lockedColor;
        }

    
    }
}