using UnityEngine;

public class Rotator : MonoBehaviour
{
    [Header("Настройки вращения")]
    [SerializeField] private Vector3 rotationSpeed = new Vector3(0, 50, 0); // Скорость по осям X, Y, Z
    [SerializeField] private Space relativeTo = Space.Self; // Вращение относительно себя или мира

    void Update()
    {
        // Time.deltaTime делает вращение плавным и независимым от FPS
        transform.Rotate(rotationSpeed * Time.deltaTime, relativeTo);
    }
}
