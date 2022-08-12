using UnityEngine;
internal class PlayerCamera : MonoBehaviour
{
    private Transform player, cam;
    private Vector3 offset;
    private readonly float camSpeed = 15;

    internal void Init(Transform _p)
    {
        cam = new GameObject("Camera").AddComponent<Camera>().transform;
        player = _p;

        //offset, change values to set natural offset for camera
        offset = new Vector3(0, 5, -10);

        cam.position = player.position + offset;
    }
    private void FixedUpdate()
    {

        cam.position = Vector3.Lerp(cam.position, player.position + offset, camSpeed * Time.deltaTime);

    }
}

