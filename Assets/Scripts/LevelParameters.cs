using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelParameters : MonoBehaviour
{
    public int levelIndex;
    public int[] plantTable;



    private List<int[]> listLevel = new List<int[]>();



    void Start()
    {
        DontDestroyOnLoad(gameObject);

        listLevel.Add(new int[] { 7 });
        listLevel.Add(new int[] { 0, 3, 3, 0, 3, 3, 2, 3, 3, 2, 3, 3, 2, 3, 3, 3, 3, 2 });
        listLevel.Add(new int[] { 0, 3, 3, 2, 3, 3, 2, 3, 3, 2, 3, 3, 6, 6, 3, 6, 6, 2 });
        listLevel.Add(new int[] { 0, 3, 3, 6, 3, 3, 3, 3, 2, 2, 2, 0, 6, 6, 3, 6, 6, 2 });
        listLevel.Add(new int[] { 0, 3, 4, 0, 3, 0, 2, 3, 0, 2, 5, 0, 8, 0, 4, 6, 7, 2 });
        listLevel.Add(new int[] { 0, 3, 0, 5, 0, 3, 4, 3, 0, 2, 3, 0, 6, 0, 3, 7, 8, 2 });
    }

    public void LoadGame(int level)
	{
        levelIndex = level;
        plantTable = listLevel[level];
        Debug.Log(plantTable[0]);
        SceneManager.LoadScene("Game");
	}

}
