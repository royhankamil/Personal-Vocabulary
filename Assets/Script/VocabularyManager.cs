using UnityEngine;

public class VocabularyManager : MonoBehaviour
{
    public class WordData
    {
        public string Word;
        public string Meaning; 
        public string Example;
    }

    public List<WordData> VocabularyList = new List<WordData>();
    private string filepath;

    void Start()
    {
        filepath;
        LoadVocabulary();
    }

    public void LoadCSV()
    {
        words.Clear();
        if (!File.Exists(filepath))
        {
            Debug.LogError("CSV not found, creating new one.");
            File.WriteAllText(filepath, "Word,Meaning,Example\n");
            return;
        }
    }
}
