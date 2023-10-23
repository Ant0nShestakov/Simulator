using UnityEngine;

public class PlayerAimManager : MonoBehaviour
{
    [SerializeField] private Transform _cameraPosition;
    [SerializeField] private float sensetivity = 1;
    [SerializeField] private float _vClampMax;
    [SerializeField] private float _vClampMin;

    private float _hInput;
    private float _vInput;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        _hInput += Input.GetAxis("Mouse X") * sensetivity;
        _vInput += Input.GetAxis("Mouse Y") * sensetivity;

        _vInput = Mathf.Clamp(_vInput, _vClampMin, _vClampMax);
    }

    private void LateUpdate()
    {
        _cameraPosition.localEulerAngles = new Vector3(-_vInput, _cameraPosition.localEulerAngles.y, _cameraPosition.localEulerAngles.z);
        this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, _hInput, transform.eulerAngles.z);
    }
}
