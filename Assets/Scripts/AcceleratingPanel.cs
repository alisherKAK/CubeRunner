using UnityEngine;

public class AcceleratingPanel : MonoBehaviour
{
    [SerializeField]
    private float _acceleration, _accelerationTime;

    public float GetAcceleration()
    {
        return _acceleration;
    }
    public float GetAccelerationTime()
    {
        return _accelerationTime;
    }
}
