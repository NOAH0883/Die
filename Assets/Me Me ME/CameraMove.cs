using System;
using System.Collections;
using TMPro;
using Unity.Cinemachine;
using Unity.Hierarchy;
using UnityEngine;
using Random = UnityEngine.Random;

public class CameraMove : MonoBehaviour
{

    [SerializeField] CinemachineCamera[] cameras; // an array for all the cinemachine cameras in the scene
    int cameraIndex; // a int for the current camera active
    private float floorsFallen; // a float to store how many floor the player has fallen 


    [SerializeField] string[] fishQuotes; // an array of all the fish quotes
    public int randomNumber; // a int to store a random number - used to show a random quote
    [SerializeField] TextMeshProUGUI quotesDisplay;// reference to the text ui to desplay the quotes


    private Coroutine quotesTimerCoroutine; // a coroutine for displaying the fish quotes
    private Coroutine startQuote; // coroutine for starting quote


    
    void Start()
    {
        quotesDisplay.text = null; // reset the text to display nothing 
        cameraIndex = 0; // reset the camera index
        cameras[cameraIndex].Priority = 1; // sets the first camera as active

        startQuote = StartCoroutine(StartQuote());

    }


    public void MoveCamUp()// when the player triggers the collider at top of the screen
    {
        cameraIndex++; // inceases cameraIndex by one 
        cameras[cameraIndex].Priority = 1; // sets the next camera as active
        cameras[cameraIndex - 1].Priority = 0; // sets the previous camera to not active
        
    }

    
    
    public void MoveCamDown()// when the player triggers the collider at the top of the screen 
    {
        cameraIndex--; // decreases the cameraIndex by one
        cameras[cameraIndex].Priority = 1; // sets the ext camera as active (below)
        cameras[cameraIndex + 1].Priority = 0; // sets the previous camera to not active


        if (floorsFallen == 2) // checks if the player has fallen 2 floors 
        {
            floorsFallen = 0; // resets the floors fallen value
            quotesTimerCoroutine = StartCoroutine(DisplayQuotes()); // starts the displayQoutes coroutine
        }
        else // if the player has not fallen 2 floors 
        {
            floorsFallen++; // incease floorsFallen float by one
        }

        
    }



    IEnumerator StartQuote()
    {
        quotesDisplay.text = fishQuotes[0]; // sets fish quote on textMeshPro to the first quote
        yield return new WaitForSeconds(5f); // wait 5 seconds before continuing coroutine

        quotesDisplay.text = null; //sets TextMeshPro text to nothing
        StopCoroutine(startQuote); //ends coroutine
    }



    IEnumerator DisplayQuotes()
    {

        Debug.Log("Coroutine started");

        randomNumber = Random.Range(0, fishQuotes.Length - 1); // sets randomNumber int to a random number between 0 and the fishQuotes array minus one 
        quotesDisplay.text = fishQuotes[randomNumber]; // displays the random fishQuote using the textmeshpro on the canvas ui

        yield return new WaitForSeconds(5f);//waits 5 seconds before continuing the coroutine
        
        Debug.Log("waited 5 secs");
        quotesDisplay.text = null; // sets the fishQuote text to nothing - doesnt desplay anything(off)
       
        StopCoroutine(quotesTimerCoroutine);// ends coroutine
    }




    //falling quotes plan

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
