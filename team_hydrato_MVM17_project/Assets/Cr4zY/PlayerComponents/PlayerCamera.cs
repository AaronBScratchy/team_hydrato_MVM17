using System;
using UnityEngine;
using UnityEngine.InputSystem;
internal class PlayerCamera : MonoBehaviour
{
    private Transform cam;
    [SerializeField] private Vector3 offset;
    private readonly float camSpeed = 15;

    internal void Init()
    {
        cam = new GameObject("Camera").AddComponent<Camera>().transform;

        cam.GetComponent<Camera>().orthographic = true;
        cam.gameObject.AddComponent<FMODUnity.StudioListener>();

        cam.position = transform.position + offset;

    }

    //Camera moves towards position of player + offset, lerp allows for smoothed delay
    private void FixedUpdate()
    {

        cam.position = Vector3.Lerp(cam.position, transform.position + offset, camSpeed * Time.deltaTime);

    }



    public void QuitGame(InputAction.CallbackContext obj)
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}

