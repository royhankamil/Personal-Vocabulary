using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Jobs;

[System.Serializable]
public class WordData
{
    public string Word;
    public string Meaning;
    public string Part_of_Speech;
    public string Examples_Sentence;
    public string Synonym;
    public string Topic;
    public string To_Indonesian;
}
public class VocabularyManager : MonoBehaviour
{

    // Word,Meaning,Part_of_Speech,Examples_Sentence, Synonym, Topic, To_Indonesian
    public GameObject itemPrefab;
    public Transform contentPanel;
    public List<WordData> VocabularyList = new List<WordData>();
    private string filepath;

    void Start()
    {
        filepath = Path.Combine(Application.streamingAssetsPath, "PERSONAL_VOCABULARY_SYSTEM.csv");

        LoadCSV();

        ShowSample();
    }

    public WordData GetRandomWord()
    {
        if (VocabularyList.Count == 0)
        {
            Debug.Log("Vocabulary list is empty.");
            return null;
        }

        int randomIndex = Random.Range(0, VocabularyList.Count);
        var randomWord = VocabularyList[randomIndex];
        Debug.Log($"Random Word: {randomWord.Word}, Meaning: {randomWord.Meaning}, Example: {randomWord.Examples_Sentence}");

        return randomWord;
    }

    public WordData GetVocabulary(int index)
    {
        if (index < 0 || index >= VocabularyList.Count)
        {
            Debug.Log("Index out of range.");
            return null;
        }

        return VocabularyList[index];
    }

    void ShowSample()
    {
        if (VocabularyList.Count > 0)
        {
            var sample = VocabularyList[0];
            Debug.Log($"Sample Word: {sample.Word}, Meaning: {sample.Meaning}, Example: {sample.Examples_Sentence}");
        }
        else
        {
            Debug.Log("Vocabulary list is empty.");
        }
        Debug.Log(filepath);
    }

    public void ShowVocabularyList()
    {
        for (int i = 0; i < 10; i++)
        {
            WordData word = VocabularyList[i];
            Debug.Log($"{i + 1}. {word.Word} - {word.Meaning} (Example: {word.Examples_Sentence})");

            GameObject item = Instantiate(itemPrefab, contentPanel);
            SetItemComponent itemComp = item.GetComponent<SetItemComponent>();
            itemComp.SetItem(word.Word, word.Meaning, word.Examples_Sentence);
        }
    }

    public void LoadCSV()
    {
        VocabularyList.Clear();
        if (!File.Exists(filepath))
        {
            Debug.LogError("CSV not found, creating new one.");
            File.WriteAllText(filepath, "Word,Meaning,Part_of_Speech,Examples_Sentence,Synonym,Topic,To_Indonesian\n");
            return;
        }

        string[] lines = File.ReadAllLines(filepath);
        for (int i = 1; i < lines.Length; i++) // skip header
        {
            string[] cols = lines[i].Split(',');
            if (cols.Length >= 7)
            {
                VocabularyList.Add(new WordData
                {
                    Word = cols[0],
                    Meaning = cols[1],
                    Part_of_Speech = cols[2],
                    Examples_Sentence = cols.Length > 3 ? cols[3] : "",
                    Synonym = cols.Length > 4 ? cols[4] : "",
                    Topic = cols.Length > 5 ? cols[5] : "",
                    To_Indonesian = cols.Length > 6 ? cols[6] : ""
                });
            }
        }



        Debug.Log("Loaded " + VocabularyList.Count + " words.");
    }

    public void SaveCSV()
    {
        List<string> lines = new List<string>
        {
            "Word,Meaning,Part_of_Speech,Examples_Sentence,Synonym,Topic,To_Indonesian"
        };
        foreach (var w in VocabularyList)
        {
            lines.Add($"{w.Word},{w.Meaning},{w.Examples_Sentence}, {w.Part_of_Speech}, {w.Synonym}, {w.Topic}, {w.To_Indonesian}");
        }
        File.WriteAllLines(filepath, lines);
        Debug.Log("CSV saved!");
    }

    public void AddWord(string word, string meaning, string Examples_Sentence, string Part_of_Speech = "", string Synonym = "", string Topic = "", string To_Indonesian = "")
    {
        VocabularyList.Add(new WordData { Word = word, Meaning = meaning, Examples_Sentence = Examples_Sentence, Part_of_Speech = Part_of_Speech, Synonym = Synonym, Topic = Topic, To_Indonesian = To_Indonesian });
        SaveCSV();
    }
}
