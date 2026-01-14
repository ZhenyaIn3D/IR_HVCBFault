using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Step {
    public string question;
    public string noAnswer;
    public string yesAnswer;
}

[CreateAssetMenu(fileName = "DataBase", menuName = "SO", order = 0)]
public class DataBaseSO : ScriptableObject {
    [SerializeField] public List<Step> steps;
}
