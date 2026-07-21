using Unity.Cinemachine;
using Unity.Hierarchy;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    [SerializeField] CinemachineCamera[] cameras;
    int cameraIndex;
    public int currentRoom;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentRoom = 0;
        cameraIndex = 0;
        cameras[cameraIndex].Priority = 1;
    }

    public void MoveCamUp()
    {
        //if(currentRoom == cameraIndex)
        //{
            cameraIndex++;
            cameras[cameraIndex].Priority = 1;
            cameras[cameraIndex - 1].Priority = 1;
        //}
        //else
        //{
            //currentRoom++;
        //}
        
        
       
    }

    public void MoveCamDown()
    {
        //if (currentRoom == cameraIndex)
        //{
            cameraIndex--;
            cameras[cameraIndex].Priority = 1;
            cameras[cameraIndex + 1].Priority = 0;
        //}
        //else
        //{
            //currentRoom--;
       // }



    }
}
