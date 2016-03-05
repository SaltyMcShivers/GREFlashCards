using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

[CustomEditor(typeof(FlashcardClass))]
public class FlashcardScriptEditor : Editor
{

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if(GUILayout.Button("Create Flashcard")){
            FlashcardClass myScript = (FlashcardClass)target;
            myScript.CreateNewCard();
        }
        if (GUILayout.Button("Remove Flashcard"))
        {
            FlashcardClass myScript = (FlashcardClass)target;
            myScript.RemoveCard();
        }
    }
}
