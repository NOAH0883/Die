using Unity.Cinemachine;
using Unity.Hierarchy;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    [SerializeField] CinemachineCamera[] cameras;
    int cameraIndex;
    
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        cameraIndex = 0;
        cameras[cameraIndex].Priority = 1;
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
        
        //display the random quote with canvas and textMeshPro - for as long as timer
        //reset fallenFloors

    }
}
