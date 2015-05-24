using UnityEngine;
using System.Collections;
using System.IO;

public class Scenes : MonoBehaviour
{
    public int actNumber, sceneNumber;
    public bool containsText;

    ArrayList Text = new ArrayList();

    public ArrayList GetActText(string SceneName)
    {
        // First of all we need to find the file
        // And for that we need the name

        try
        {
            var filename = SceneName + "Text.txt";

            // Then we search through the entire asset folder

            var paths = Directory.GetFiles(Application.dataPath, filename, SearchOption.AllDirectories);

            // Tell the Streamreader which file to read

            var reader = new StreamReader(paths[0], System.Text.Encoding.Default);

            // Make sure the TextArray is empty

            Text.Clear();

            // Read and save every line of the file

            while (!reader.EndOfStream)
                Text.Add(reader.ReadLine());

            reader.Close();

            // Returns an array of characters which represent our scrolling text

            return Text;

        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
            return null;
        }
    }

    public void LoadNextScene()
    {
        int toLoad = Application.loadedLevel;
        toLoad++;

        Application.LoadLevel(toLoad);

        GameObject.Find("PermObject").GetComponent<FadingScript>().Begin(-1);
    }

    private IEnumerator CheckForText()
    {
        // If there exists a file for next level, display the text before loading

        GameObject.Find("PermObject").GetComponent<FadingScript>().Begin(1);

        if (GetActText(Application.loadedLevelName) != null)
            GameObject.Find("PermObject").GetComponent<ScrollingText>().Display(GetActText(Application.loadedLevelName));
        else
        {
            yield return new WaitForSeconds(2);

            LoadNextScene();
        }
    }

    public void TryNextScene()
    {
        StartCoroutine(CheckForText());
    }
}
