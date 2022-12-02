using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeypadManager : MonoBehaviour
{
    public KeypadParametre SquareParametre;
    private int _instanceNumber;
    private void Start()
    {
        SpawnSquare();
    }

    void SpawnSquare()
    {
        var currentIndex = 0;
        
        for (int i = 0; i < SquareParametre.lstSquarePos.Count; i++)
        {
            GameObject square = Instantiate(SquareParametre.squarePrefab, SquareParametre.lstSquarePos[currentIndex], Quaternion.identity);
            TextMeshPro squareText = Instantiate(SquareParametre.squareTextPrefab, SquareParametre.lstSquarePos[currentIndex], Quaternion.identity);

            square.name = SquareParametre.squareValue[currentIndex];
            
            //Set text parametre
            squareText.text = SquareParametre.squareValue[currentIndex];
            squareText.GetComponent<TextMeshPro>().color = Color.red;
            squareText.transform.position = new Vector3(squareText.transform.position.x, squareText.transform.position.y, -0.5f);
            
            currentIndex = (currentIndex + 1) % SquareParametre.lstSquarePos.Count;
            
            _instanceNumber++;
        }
    }
}
