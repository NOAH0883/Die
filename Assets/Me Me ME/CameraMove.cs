using System;
using TMPro;
using Unity.Cinemachine;
using Unity.Hierarchy;
using UnityEngine;
using Random = UnityEngine.Random;

public class CameraMove : MonoBehaviour
{

    [SerializeField] CinemachineCamera[] cameras;
    int cameraIndex;

    [SerializeField] string[] fishQuotes;
    public int randomNumber;
    private float floorsFallen;
    [SerializeField] TextMeshProUGUI quotesDisplay;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        cameraIndex = 0;
        cameras[cameraIndex].Priority = 1;
        Debug.Log(fishQuotes.Length);
    }

    private void Update()
    {
        quotesDisplay.text = fishQuotes[randomNumber];
    }

    public void MoveCamUp()
    {
        
        cameraIndex++;
        cameras[cameraIndex].Priority = 1;
        cameras[cameraIndex - 1].Priority = 1;
        
    }

    public void MoveCamDown()
    {
            cameraIndex--;
            cameras[cameraIndex].Priority = 1;
            cameras[cameraIndex + 1].Priority = 0;
  

        if(floorsFallen == 2)
        {   
            DisplayQuote();
            floorsFallen = 0;
            
        }
        else
        {
            floorsFallen++;
        }

        //falling quotes

        //string array quotes 
        //int randomNumber
        //int fallenFloors
        //int fallenFloorsMax???
        //reference to canvas and textMeshPro
        //float quoteShowTimer
        //float quoteTimeMax???


        // when you fall a level increase fallenFloors
        
        //if fallenFoors is equal to or greater than fallenFloorsMax
        //get a  random number from 0 to amount of quotes
        
        //display the random quote with canvas and textMeshPro 
        //text on - text off baised of timer
        //reset fallenFloors
    }

    private void DisplayQuote()
    {
        
        randomNumber = Random.Range(0, fishQuotes.Length-1);
          
    }
}
