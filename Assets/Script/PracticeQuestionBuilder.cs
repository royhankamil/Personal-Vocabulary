using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum AnswerOption
{
    A = 0,
    B,
    C,
    D
}

public class PracticeQuestionBuilder : MonoBehaviour
{
    [SerializeField] private VocabularyManager vocabularyManager;
    [SerializeField]
    private TextMeshProUGUI questionText, answerOptionA,
                answerOptionB, answerOptionC, answerOptionD;
    [SerializeField] Button[] answersButton;
    [SerializeField] int[] indexAnswer;
    AnswerOption randomAnswerPosition;

    private enum TypeOfQuestion
    {
        Meaning,
        Synonym,
        ExampleSentence
    }



    void Start()
    {
        StartQuestioning();
    }


    private void ResetButton()
    {
        for (int i = 0; i < answersButton.Length; i++)
        {
            answersButton[i].GetComponent<Image>().color = Color.white;
        }

        answerOptionA.text = "";
        answerOptionB.text = "";
        answerOptionC.text = "";    
        answerOptionD.text = "";
    }


    public void StartQuestioning()
    {
        int wordDataIndex = Random.Range(0, vocabularyManager.VocabularyList.Count - 1);
        int randomTypeOfQuestion = Random.Range(0, 3);
        randomAnswerPosition = (AnswerOption)Random.Range(0, 4);
        TypeOfQuestion questionType = (TypeOfQuestion)randomTypeOfQuestion;
        WordData wordData = vocabularyManager.GetVocabulary(wordDataIndex);
        ResetButton();
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

        if (randomAnswerPosition == AnswerOption.A)
        {
            while (answerOptionA.text == "" )
            {
                answerOptionA.text = GetRandomWrongAnswer(questionType);
                if (questionType == TypeOfQuestion.Meaning)
                    answerOptionA.text = MinimizeString(wordData.Meaning);
                else if (questionType == TypeOfQuestion.Synonym)
                    answerOptionA.text = wordData.Synonym;
                else // ExampleSentence
                    answerOptionA.text = wordData.Examples_Sentence;
                // Fill other options with random meanings
            }
        }

        else
        {
            // string randomAnswerPosition = GetRandomWrongAnswer(questionType);
            // while (randomAnswerPosition == answerOptionB.text)
            // {
            //     randomAnswerPosition = GetRandomWrongAnswer(questionType);
            // }
            answerOptionA.text = GetRandomWrongAnswer(questionType);
        }

        if (randomAnswerPosition == AnswerOption.B)
        {
            while (answerOptionB.text == "")
            {
                answerOptionB.text = GetRandomWrongAnswer(questionType);
                if (questionType == TypeOfQuestion.Meaning)
                    answerOptionB.text = MinimizeString(wordData.Meaning);
                else if (questionType == TypeOfQuestion.Synonym)
                    answerOptionB.text = wordData.Synonym;
                else // ExampleSentence
                    answerOptionB.text = wordData.Examples_Sentence;
                // Fill other options with random meanings
            }
        }

        else
        {
            // string randomAnswerPosition = GetRandomWrongAnswer(questionType);
            // while (randomAnswerPosition == answerOptionB.text)
            // {
            //     randomAnswerPosition = GetRandomWrongAnswer(questionType);
            // }
            answerOptionB.text = GetRandomWrongAnswer(questionType);
        }

        if (randomAnswerPosition == AnswerOption.C)
        {
            while(answerOptionC.text == "")
            {
                answerOptionC.text = GetRandomWrongAnswer(questionType);
                if (questionType == TypeOfQuestion.Meaning)
                    answerOptionC.text = MinimizeString(wordData.Meaning);
                else if (questionType == TypeOfQuestion.Synonym)
                    answerOptionC.text = wordData.Synonym;
                else // ExampleSentence
                    answerOptionC.text = wordData.Examples_Sentence;
                // Fill other options with random meanings
            }
        }

        else
        {
            answerOptionC.text = GetRandomWrongAnswer(questionType);
        }

        if (randomAnswerPosition == AnswerOption.D)
        {
            while (answerOptionD.text == "")
            {

                if (questionType == TypeOfQuestion.Meaning)
                    answerOptionD.text = MinimizeString(wordData.Meaning);
                else if (questionType == TypeOfQuestion.Synonym)
                    answerOptionD.text = wordData.Synonym;
                else // ExampleSentence
                    answerOptionD.text = wordData.Examples_Sentence;
                // Fill other options with random meanings
            }
        }

        else
        {
            answerOptionD.text = GetRandomWrongAnswer(questionType);
        }
    }

    string GetRandomWrongAnswer(TypeOfQuestion questionType)
    {
        int randomIndex = Random.Range(0, vocabularyManager.VocabularyList.Count - 1);
        string returnAnswer;
        if (questionType == TypeOfQuestion.Meaning)
            returnAnswer = MinimizeString(vocabularyManager.VocabularyList[randomIndex].Meaning);
        else if (questionType == TypeOfQuestion.Synonym)
            returnAnswer = vocabularyManager.VocabularyList[randomIndex].Synonym; // Assuming Synonyms is a property in WordData
        else // ExampleSentence
            returnAnswer = vocabularyManager.VocabularyList[randomIndex].Examples_Sentence;
        if (returnAnswer == answerOptionA.text || returnAnswer == answerOptionB.text ||
            returnAnswer == answerOptionC.text || returnAnswer == answerOptionD.text || returnAnswer == "")
        {
            return GetRandomWrongAnswer(questionType);
        }
        else
        {
            return returnAnswer;
        }
    }

    // to split the string into smaller parts by sentences
    string MinimizeString(string input)
    {
        string[] splitInput = input.Split('.');
        int random = Random.Range(0, splitInput.Length - 2);
        return splitInput[random];
    }

    void Update()
    {

    }

    public void CheckAnswer(int answerIndex)
    {
        if (randomAnswerPosition == (AnswerOption) answerIndex)
        {
            Debug.Log("Correct Answer!");
            answersButton[answerIndex].GetComponent<Image>().color = Color.green;
            Invoke("StartQuestioning", 1.8f);
        }
        else
        {
            Debug.Log("Wrong Answer!");
            answersButton[answerIndex].GetComponent<Image>().color = Color.red;
        }
    }
}
