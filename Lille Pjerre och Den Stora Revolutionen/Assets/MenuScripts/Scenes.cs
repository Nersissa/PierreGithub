using UnityEngine;
using System.Collections;
using System.IO;

class Scenes : MonoBehaviour
{
    static ArrayList Text = new ArrayList();

    public static ArrayList GetActText(int ActNumber)
    {
        // First of all we need to find the file
        // And for that we need the name

        var filename = "Act" + ActNumber.ToString() + "Text.txt";

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

    public static void LoadScene(string ActName)
    {
        Application.LoadLevel(ActName);
    }
}
