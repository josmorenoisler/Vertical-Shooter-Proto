using UnityEngine;

namespace VerticalShooter
{
    public class ParallaxController : MonoBehaviour
    {
        [SerializeField] Transform[] backgrounds;   // Array of background layers
        [SerializeField] float smoothing = 10f;     // Smoothness of the parallax effect
        [SerializeField] float multiplier = 12f;    // Parallax effect increment per layer

        Transform cam;          // Main camera reference
        Vector3 previousCamPos; // Position of the camera in the previous frame

        void Awake()
        {
            cam = Camera.main.transform;
        }

        void Start()
        {
            previousCamPos =  cam.position;
        }

        void Update()
        {
            // Iterate through each background layer
            for (int i = 0; i < backgrounds.Length; i++)
            {
                float parallax = (previousCamPos.y - cam.position.y) * (i * multiplier);
                float targetY = backgrounds[i].position.y + parallax;

                Vector3 targetPosition = new Vector3(backgrounds[i].position.x, targetY, backgrounds[i].position.z);

                backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, targetPosition, smoothing * Time.deltaTime);
            }

            previousCamPos = cam.position;
        }
    }
}
