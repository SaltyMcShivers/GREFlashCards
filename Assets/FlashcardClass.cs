using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;

[System.Serializable]
public struct FlashcardCollection
{
    public WordClass[] Words;
}

public class FlashcardClass : MonoBehaviour {
    public FlashcardCollection words;
    List<WordClass> testWords;
    public CardDisplayScript displayScript;
    public Text progressDisplay;

    public WordClass newestWord;

    int currentPosition;
	// Use this for initialization
	void Start () {
        //GetWordsFromJSON();
        ShuffleList();
	}

    void GetWordsFromJSON()
    {
        if (Application.platform != RuntimePlatform.Android)
        {
            words = JsonUtility.FromJson<FlashcardCollection>(File.ReadAllText(Application.dataPath + "/Resources/Words.json"));
        }
    }

    void ShuffleList()
    {
        testWords = new List<WordClass>();
        for (int i = 0; i < words.Words.Length; i++)
        {
            testWords.Insert(Mathf.FloorToInt(Random.Range(0, testWords.Count)), words.Words[i]);
        }
        currentPosition = 0;
        DisplayWord();
    }

    public void CreateNewCard()
    {
        words = JsonUtility.FromJson<FlashcardCollection>(File.ReadAllText(Application.dataPath + "/Resources/Words.json"));
        List<WordClass> wordList = new List<WordClass>();
        for (int i = 0; i < words.Words.Length; i++)
        {
            wordList.Add(words.Words[i]);
        }
        wordList.Add(newestWord);
        words.Words = wordList.ToArray();
        string newJSON = JsonUtility.ToJson(words, true);
        File.WriteAllText(Application.dataPath + "/Resources/Words.json", newJSON);
        newestWord = new WordClass();
    }

    public void RemoveCard()
    {
        words = JsonUtility.FromJson<FlashcardCollection>(File.ReadAllText(Application.dataPath + "/Resources/Words.json"));
        List<WordClass> wordList = new List<WordClass>();
        bool wordFound = false;
        for (int i = 0; i < words.Words.Length; i++)
        {
            if (!wordFound)
            {
                if (newestWord.word == words.Words[i].word)
                {
                    wordFound = true;
                    continue;
                }
            }
            wordList.Add(words.Words[i]);
        }
        words.Words = wordList.ToArray();
        string newJSON = JsonUtility.ToJson(words, true);
        File.WriteAllText(Application.dataPath + "/Resources/Words.json", newJSON);
        newestWord = new WordClass();
    }

    public void CreateNewCard(string word, string newDef, string newEx, string newKey, string newPro, string[] newSym)
    {
        WordClass newWord = new WordClass(word, newDef, newEx, newKey, newPro, newSym);
        List<WordClass> wordList = new List<WordClass>();
        for (int i = 0; i < words.Words.Length; i++)
        {
            wordList.Add(words.Words[i]);
        }
        wordList.Add(newWord);
        words.Words = wordList.ToArray();
        string newJSON = JsonUtility.ToJson(words, true);
        File.WriteAllText(Application.dataPath + "/Resources/NewWords.json", newJSON);
    }

    public void Itterate(int direction)
    {
        currentPosition += direction;
        if (currentPosition < 0 || currentPosition >= testWords.Count)
        {
            ShuffleList();
        }
        DisplayWord();
    }

    public void DisplayWord()
    {
        progressDisplay.text = (currentPosition + 1).ToString() + " of " + testWords.Count.ToString();
        displayScript.SetUpCard(testWords[currentPosition]);
    }
}
