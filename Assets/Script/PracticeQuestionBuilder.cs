using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class PracticeQuestionBuilder : MonoBehaviour
{
    [SerializeField] private VocabularyManager vocabularyManager;
    [SerializeField]
    private TextMeshProUGUI questionText, answerOptionA,
                answerOptionB, answerOptionC, answerOptionD;
    int randomAnswerPosition;
                
    private enum TypeOfQuestion
    {
        Meaning,
        Synonym,
        ExampleSentence
    }


    void Start()
    {

    }

    public void StartQuestioning()
    {
        int wordDataIndex = Random.Range(0, vocabularyManager.VocabularyList.Count);
        int randomTypeOfQuestion = Random.Range(0, 3);
        randomAnswerPosition = Random.Range(0, 4);
        TypeOfQuestion questionType = (TypeOfQuestion)randomTypeOfQuestion;
        WordData wordData = vocabularyManager.GetVocabulary(wordDataIndex);
        switch (questionType)
        {
            case TypeOfQuestion.Meaning:
                questionText.text = $"What is the meaning of the word '{wordData.Word}'?";
                break;
            case TypeOfQuestion.Synonym:
                questionText.text = $"What is a synonym of the word '{wordData.Word}'?";
                break;
            case TypeOfQuestion.ExampleSentence:
                questionText.text = $"Which of the following sentences uses the word '{wordData.Word}' correctly?";
                break;
        }

        if (randomAnswerPosition == 0)
        {
            answerOptionA.text = wordData.Meaning;
            // Fill other options with random meanings
            
        }

        else
        {
            string randomAnswerPosition = GetRandomWrongAnswer(questionType);
            while (randomAnswerPosition == answerOptionB.text)
            {
                randomAnswerPosition = GetRandomWrongAnswer(questionType);
            }
            answerOptionB.text = GetRandomWrongAnswer(questionType);
        }

        if (randomAnswerPosition == 1)
        {
            answerOptionB.text = wordData.Meaning;
            // Fill other options with random meanings
        }
        
        else
        {
            string randomAnswerPosition = GetRandomWrongAnswer(questionType);
            while (randomAnswerPosition == answerOptionB.text)
            {
                randomAnswerPosition = GetRandomWrongAnswer(questionType);
            }
            answerOptionB.text = GetRandomWrongAnswer(questionType);
        }

        if (randomAnswerPosition == 2)
        {
            answerOptionC.text = wordData.Meaning;
            // Fill other options with random meanings
        }

        else
        {
            answerOptionC.text = GetRandomWrongAnswer(questionType);
        }

        if (randomAnswerPosition == 3)
        {
            answerOptionD.text = wordData.Meaning;
            // Fill other options with random meanings
        }

        else
        {
            answerOptionD.text = GetRandomWrongAnswer(questionType);
        }
    }
    
    string GetRandomWrongAnswer(TypeOfQuestion questionType)
    {
        int randomIndex = Random.Range(0, vocabularyManager.VocabularyList.Count);
        if (questionType == TypeOfQuestion.Meaning)
            return vocabularyManager.VocabularyList[randomIndex].Meaning;
        else if (questionType == TypeOfQuestion.Synonym)
            return vocabularyManager.VocabularyList[randomIndex].Synonym; // Assuming Synonyms is a property in WordData
        else // ExampleSentence
            return vocabularyManager.VocabularyList[randomIndex].Examples_Sentence;
    }

    void Update()
    {
        
    }

    public void CheckAnswer(int answerIndex)
    {
        if (answer == )
    }
}
