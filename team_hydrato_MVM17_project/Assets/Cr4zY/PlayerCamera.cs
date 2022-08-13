using UnityEngine;
internal class PlayerCamera : MonoBehaviour
{
    private Transform player, cam;
    [SerializeField] private Vector3 offset;
    private readonly float camSpeed = 15;

    internal void Init(Transform _p)
    {
        cam = new GameObject("Camera").AddComponent<Camera>().transform;
        player = _p;

        cam.position = player.position + offset;
    }
    private void FixedUpdate()
    {

        cam.position = Vector3.Lerp(cam.position, player.position + offset, camSpeed * Time.deltaTime);

    }
}

