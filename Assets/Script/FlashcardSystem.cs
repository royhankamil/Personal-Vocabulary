using TMPro;
using UnityEngine;

public class FlashcardSystem : MonoBehaviour
{
    public TextMeshProUGUI wordText;
    public TextMeshProUGUI meaningText;
    public VocabularyManager vocabularyManager;

    private WordData currentWord;

    private void Start() {
        currentWord = vocabularyManager.GetRandomWord();
        if (currentWord != null) {
            wordText.text = currentWord.Word;
            meaningText.text = currentWord.Meaning;
        }
    }
}
