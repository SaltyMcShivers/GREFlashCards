using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public struct WordClass {
    public string word;
    public string definition;
    public string exampleSentence;
    public string hintPhrase;
    public string pronunciation;
    public string[] synonyms;

    public WordClass(WordClass newWord)
    {
        this.word = newWord.word;
        this.definition = newWord.definition;
        this.exampleSentence = newWord.exampleSentence;
        this.hintPhrase = newWord.hintPhrase;
        this.pronunciation = newWord.pronunciation;
        this.synonyms = newWord.synonyms;
    }

    public WordClass(string newWord, string newDef, string newEx, string newKey, string newPro, string[] newSym)
    {
        this.word = newWord;
        this.definition = newDef;
        this.exampleSentence = newEx;
        this.hintPhrase = newKey;
        this.pronunciation = newPro;
        this.synonyms = newSym;
    }
}
