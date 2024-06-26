using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private const string UNLOCKED_LEVELS_KEY = "UnlockedLevels";
    private const string COMPLETED_LEVELS_KEY = "CompletedLevels";
    
    // Unlock a level
    public static void UnlockLevel(int levelIndex) 
    {
        string unlockedLevels = PlayerPrefs.GetString(UNLOCKED_LEVELS_KEY, "");
        if (!unlockedLevels.Contains(levelIndex.ToString()))
        {
            unlockedLevels += levelIndex + ",";
            PlayerPrefs.SetString(UNLOCKED_LEVELS_KEY, unlockedLevels);
        }
    }

    // Check if a level is unlocked
    public static bool IsLevelUnlocked(int levelIndex)
    {
        string unlockedLevels = PlayerPrefs.GetString(UNLOCKED_LEVELS_KEY, "");
        return unlockedLevels.Contains(levelIndex.ToString());
    }

    // Complete a level and unlock the next level
    public static void CompleteLevel(int levelIndex)
    {
        string completedLevels = PlayerPrefs.GetString(COMPLETED_LEVELS_KEY, "");
        if (!completedLevels.Contains(levelIndex.ToString()))
        {
            completedLevels += levelIndex + ",";
            PlayerPrefs.SetString(COMPLETED_LEVELS_KEY, completedLevels);

            // Unlock the next level
            int nextLevelIndex = levelIndex + 1;
            UnlockLevel(nextLevelIndex);
        }
    }
}
