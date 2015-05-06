using UnityEngine;
using System.Collections;
using System.IO;

 public class Scenes : MonoBehaviour
{
    ArrayList Text = new ArrayList();

    public ArrayList GetActText(int ActNumber, int SceneNumber)
    {
        // First of all we need to find the file
        // And for that we need the name

        var filename = "Act" + ActNumber.ToString() + "Scene" + SceneNumber.ToString() + "Text.txt";

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

    public void LoadScene(int ActNumber, int SceneNumber)
    {
        Application.LoadLevel("Act" + ActNumber.ToString() + "Scene" + SceneNumber.ToString());
    }

    public void TransitionToScene(int ActNumber, int SceneNumber)
    {

    }
}
