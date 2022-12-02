using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "New Square", menuName = "Square")]
public class KeypadParametre : ScriptableObject
{
    public List<Vector3> lstSquarePos;
    public List<string> squareValue;
    
    public GameObject squarePrefab;
    public TextMeshPro squareTextPrefab;
    
    [SerializeField] public string codeValue = "";
    [SerializeField] public string keypadCode = "";
}
