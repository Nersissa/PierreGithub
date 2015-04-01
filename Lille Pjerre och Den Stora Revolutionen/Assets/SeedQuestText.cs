using UnityEngine;
using System.Collections;

public class SeedQuestText : MonoBehaviour
{
    public bool TryingToSowWithoutSeeds = false;
    public bool PickedUpSeeds = false;
    public bool PickUpSeeds = true;

    private string pickupseeds = "Welcome! Your first mission is to pick up the seeds to your left! \n Good Luck!";
    private string pickedupseeds = "Now when you have picked up your seeds, start sowing them on the fieldish-looking thing to your right! \n Good Luck!";
    private string tryingtosowwithoutseeds = "You can't sow yet, you haven't picked up the seeds! \n It's to your left!";

    private float textTimer = 10;

    void OnGUI()
    {
        if (TryingToSowWithoutSeeds)
            ShowText(tryingtosowwithoutseeds, ref TryingToSowWithoutSeeds);

        if (PickedUpSeeds)
            ShowText(pickedupseeds, ref PickedUpSeeds);

        if (PickUpSeeds)
            ShowText(pickupseeds, ref PickUpSeeds);
    }

    void ShowText(string text, ref bool inputBool)
    {
        textTimer -= Time.deltaTime;

        GUILayout.BeginArea(new Rect(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 4, 200, 50));
        GUILayout.Label(text);

        GUILayout.EndArea();

        if (textTimer <= 0)
        {
            inputBool = false;
            textTimer = 10;
        }
    }
}
