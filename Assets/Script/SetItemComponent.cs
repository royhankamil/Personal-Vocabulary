using TMPro;
using UnityEngine;

public class SetItemComponent : MonoBehaviour
{
    public TextMeshProUGUI wordTxt;
    public TextMeshProUGUI meaningTxt;
    public TextMeshProUGUI exampleTxt;

    public void SetItem(string word, string meaning, string example)
    {
        wordTxt.text = word;
        meaningTxt.text = meaning;
        exampleTxt.text = example;
    }
}
