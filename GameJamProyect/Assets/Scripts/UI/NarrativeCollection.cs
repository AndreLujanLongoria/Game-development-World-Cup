﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class NarrativeCollection : MonoBehaviour
{
    [SerializeField] List<TextEvent> roomEvents;
    [SerializeField] List<TextEvent> objectsEvents;
    [SerializeField] GameObject uiHolder;
    [SerializeField] Text text;
    [SerializeField] float textTime;

    List<TextEvent> eventsSelected;

    public void Start()
    {
        uiHolder.SetActive(false);
    }
    public void ShowText(int index,NarrativeEvent typeNarrative)
    {
        uiHolder.SetActive(true);
        eventsSelected = typeNarrative == NarrativeEvent.ROOM ? roomEvents : objectsEvents;
        StartCoroutine(ChangueText(index));
    }
    public void ShowText(string name, NarrativeEvent typeNarrative)
    {
        uiHolder.SetActive(true);
        eventsSelected = typeNarrative == NarrativeEvent.ROOM ? roomEvents : objectsEvents;
        StartCoroutine(ChangueText(name));
    }
    IEnumerator ChangueText(int index)
    {
        text.text = eventsSelected[index].text;
        yield return new WaitForSeconds(textTime);
        uiHolder.SetActive(false);
    }

    IEnumerator ChangueText(string name)
    {
        foreach (var item in eventsSelected)
        {
            if (item.name == name)
            {
                text.text = item.text;
                break;
            }
        }
       
        yield return new WaitForSeconds(textTime);
        uiHolder.SetActive(false);
    }
}

public enum NarrativeEvent { ROOM,OBJECT}