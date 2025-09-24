using UnityEngine;
using UnityEngine.Events;

public class InputViewCube : MonoBehaviour
{
    private Raycaster _raycaster;
    private const int CommandPressButton = 0;

    public event UnityAction Click;

    private void OnEnable()
    {
        _raycaster.Find += Update;
    }

    private void OnDisable()
    {
        _raycaster.Find -= Update;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(CommandPressButton))
        {
            Click?.Invoke();
        }
    }
}
