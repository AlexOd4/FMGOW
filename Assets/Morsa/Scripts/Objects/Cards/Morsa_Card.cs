using static Morsa_Glossary;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Scriptable Objects/Card")]
public class Morsa_Card : ScriptableObject
{
    [SerializeField] public string title;
    [SerializeField] public int id;
    [SerializeField] public string description;
    [SerializeField] public List<Property> uprightProperties;
    [SerializeField] public List<Property> flippedProperties;
    [SerializeField] public Sprite image;
}
