using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelParameters : MonoBehaviour
{
    private readonly List<int[]> listLevel = new();
    private float[] sunMultiplier;
    private int[] unlockedZombie;
    private bool[] spawnBrains;
    private string[] messages;

    void Start()
    {
        spawnBrains = new bool[] { true, true, true, true, true, true, true, true, false, true, true, true, false, true, true, true,true,true};
        unlockedZombie = new int[] { 0, 0, 1, 1, 2, 2, 3, 3, 3, 4, 5, 5, 5, 5, 5, 5,5,5};
        sunMultiplier = new float[] { 1f, 1f, 1.10f, 1.20f, 1.30f, 1.40f, 1.50f, 1.60f, 1f, 1.70f, 1.70f, 1.70f, 1f, 1.80f,1.80f,1.90f, 1.90f, 2f};

        listLevel.Add(new int[] { 0, 3, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0 ,0 ,0, 0 , 0 ,0, 0 ,0, 0,0 ,0 , 0,0,0,0,0,0,0,0,0,0,0,0,0, });
        listLevel.Add(new int[] { 3 });
        listLevel.Add(new int[] { 0, 0, 3 , 0, 0, 0, 0,0 ,0,0 ,0});
        listLevel.Add(new int[] { 0, 3, 0, 2, 2, 2, 2, 2, 2, 3,0, 0, 2, 2, 2, 2, 2 });
        listLevel.Add(new int[] { 0, 3, 0, 0,0,0,3,2,0,3,2,0,3,2,0,3,2,0,3,2,0 });
        listLevel.Add(new int[] { 0,0 ,12,12,12,12,12});
        listLevel.Add(new int[] { 0, 0, 2, 2, 3, 2, 2, 2,3,2,2,2,2,3,2,2,2,2,3});
        listLevel.Add(new int[] { 3,3,0,0,9,9,3,3,3,9,3,3,3,9 });
        listLevel.Add(new int[] { 3,3,2,0,12,0,9,0,2 });
        listLevel.Add(new int[] { 0,4,0,4,2,4,4,0,2,0,10,4,0,12,10,0 });
        listLevel.Add(new int[] { 0, 5,5,5,0,0,0,2,2,12,11,11,11,2,12,0 });
        listLevel.Add(new int[] { 0, 1, 0, 1,1,6,7,8,6,7,8 });
        listLevel.Add(new int[] { 3,2,12,1,4,8,0,5,0,2,12,10 });
        listLevel.Add(new int[] { 0, 0,1,1,6,6,6,7,8,0,0,1,1,2,2,2,2,2,0,0,0,0,0,12,12,12,12,12,1,1,1,10,11,10,11 });
        listLevel.Add(new int[] { 0, 0, 3, 1, 1, 9, 9, 2, 12, 0,1,0,1,7,8,2,2,12,7,8,0,1,10,11,0,1,3,4,5,3,4,5,0,1,0,6,2,12,7,8,0,0,1,1,10,11,9 });
        listLevel.Add(new int[] { 0, 0, 0, 10,11, 12, 12, 12, 12, 12, 0,0,0,3, 4, 5, 3, 4, 5, 3, 4, 5, 2,2,2});
        listLevel.Add(new int[] { 0, 0, 7, 7, 1, 0, 8, 8,0,0,2,2,2,12, 6, 6});
        listLevel.Add(new int[] { 0, 0, 0, 1, 1, 2, 12, 2, 12, 2, 4, 5, 4, 5, 4, 0, 1, 1, 1,0, 9, 9,12,2,12,2,12 });

        messages = new string[]
        {
            " ",
            "Be ready to deal with a lot of peashooter",
            "The BucketHead zombie is available : has a lot oh HP for his price",
            "Be ready to fight the nut ! This plant doesn't attack but has a lot of HP",
            "The sport zombie has low HP, but is really fast ! Ideal to take down an unprotect sunflower.",
            "This level is filled of Pears : a one-use plant that deal area damage",
            "Use the quaterback zombie : it costs a lot but he is fast and has so mush HP and damage",
            "Another level with many peashooter. Be careful with the triple-Peashooter : shoot on several lane",
            "This level is special : no brain come from the ground ! you'll have to use a lot of gravestones",
            "Press S to get RED Zombies. Can only spawn on red tombstone, take less damage from Red Plants",
            "Press Q to get BLUE Zombies. Take less damage from blue plants, more from red plants. The opposite of Red Zombies",
            "DOUBLE sunflower and peashooter : 2 times more efficient in a smaller area",
            "Another level with no bonus brains from the ground ! We need gravestones !",
            "You know everything of this game now. But are you really that strong ?",
            "you think the last level was hard ? Try this one",
            "If you're able to defeat this level, you really are the zombie's master !"
        };
    }

    public void LoadGame(int level)
	{
        Transporter.transporter.LoadGame(listLevel[level], unlockedZombie[level], messages[level], sunMultiplier[level],spawnBrains[level]);
	}
    

}
