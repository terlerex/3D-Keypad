using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class KeypadInteraction : MonoBehaviour
{
    public KeypadParametre squareParametre;

    private void Start()
    {
        ResetCodeValue();
    }
    
    private void OnMouseDown()
    {
        var value = gameObject.name;
        squareParametre.codeValue += value;
        Debug.Log(squareParametre.codeValue);
        
        CheckCode();
        MaxCodeValue();
        StartCoroutine(ColorAnim());
    }

    /// <summary>
    /// Check if the code is correct
    /// </summary>
    private void CheckCode()
    {
        if (squareParametre.codeValue != null)
        {
            if(squareParametre.codeValue.Length == squareParametre.keypadCode.Length)
                Debug.Log(squareParametre.codeValue == squareParametre.keypadCode ? StartCoroutine(ColorAnimSuccess()) : StartCoroutine(ColorAnimError()));
        }
    }
    /// <summary>
    /// Reset the code value
    /// </summary>
    void ResetCodeValue()
    {
        squareParametre.codeValue = null;
    }
    
    /// <summary>
    /// Check if the code value is equal to the code length
    /// </summary>
    void MaxCodeValue()
    {
        squareParametre.codeValue = squareParametre.codeValue.Length >= squareParametre.keypadCode.Length ? null : squareParametre.codeValue;
    }
    
    IEnumerator ColorAnim()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.green;
        yield return new WaitForSeconds(0.15f);
        gameObject.GetComponent<Renderer>().material.color = Color.white;
    }
    
    IEnumerator ColorAnimError()
    {
        var Key = GameObject.FindGameObjectsWithTag("Keycap");
        foreach (var t in Key) {
            t.GetComponent<Renderer>().material.color = Color.red; }
        yield return new WaitForSeconds(0.3f);
        foreach (var t in Key) {
            t.GetComponent<Renderer>().material.color = Color.white; }
    }
    
    IEnumerator ColorAnimSuccess()
    {
        var Key = GameObject.FindGameObjectsWithTag("Keycap");
        foreach (var t in Key) {
            t.GetComponent<Renderer>().material.color = Color.green; }
        yield return new WaitForSeconds(0.3f);
        foreach (var t in Key) {
            t.GetComponent<Renderer>().material.color = Color.white; }
    }
}
