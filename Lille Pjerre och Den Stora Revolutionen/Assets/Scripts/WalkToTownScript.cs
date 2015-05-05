using UnityEngine;
using System.Collections;

public class WalkToTownScript : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {

    }
}

public class WalkToTownQuest : Quest
{
    public QuestStep GetToJacques, TalkToJacques, GetToTown;

    public WalkToTownQuest()
        : base("Walk to town")
    {

    }


}
