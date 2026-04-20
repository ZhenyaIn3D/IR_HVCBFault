using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

[Serializable]
public class Step {
    public string infoPanelText;
    public string stepName;
    public VideoClip infoVideoClip;
    public Sprite[] infoSprites;
    public UserInputType userInputType;
    public UnityAction OnYesClicked;
    public UnityAction OnNoClicked;
}

[CreateAssetMenu(fileName = "DataBase", menuName = "SO", order = 0)]
public class DataBaseSO : ScriptableObject {
    [SerializeField] public List<Step> steps;
}
