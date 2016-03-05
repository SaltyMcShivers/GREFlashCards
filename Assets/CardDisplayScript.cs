using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class CardDisplayScript : MonoBehaviour {
    public List<Text> titleDisplays;
    public Text pronounceDisplay;
    public Text hintDisplay;
    public Text defDisplay;
    public Text sentenceDisplay;
    public Transform synDisplay;
    public GameObject synPrefab;
	// Use this for initialization

    public void SetUpCard(WordClass Word)
    {
        while (synDisplay.childCount > 0)
        {
            Transform currentChild = synDisplay.GetChild(0);
            currentChild.SetParent(null);
            Destroy(currentChild.gameObject);
        }
        foreach (Text title in titleDisplays)
        {
            title.text = Word.word;
        }
        pronounceDisplay.text = "[" + Word.pronunciation + "]";
        hintDisplay.text = "(" + Word.hintPhrase + ")";
        hintDisplay.gameObject.SetActive(false);
        defDisplay.text = Word.definition;
        sentenceDisplay.text = Word.exampleSentence;
        foreach (string syn in Word.synonyms)
        {
            GameObject newChild = Instantiate(synPrefab) as GameObject;
            newChild.GetComponent<Text>().text = syn;
            newChild.transform.SetParent(synDisplay);
        }
    }

    public void ToggleHint()
    {
        hintDisplay.gameObject.SetActive(!hintDisplay.gameObject.activeSelf);
    }
}
