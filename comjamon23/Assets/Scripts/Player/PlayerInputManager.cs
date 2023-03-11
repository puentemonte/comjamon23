using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{

    #region parameters
    bool pressedSpace;
    #endregion

    #region properties
    private float _horizontalInput;
    private float _verticalInput;
    #endregion

    #region references
    private PlayerMovementController _myPlayerMovementController;
    private ShootComponent _shootComponent;
    #endregion

    #region methods
    public float HInput()
    {
        return _horizontalInput;
    }

    public float VInput()
    {
        return _verticalInput;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _myPlayerMovementController = GetComponent<PlayerMovementController>();
        _shootComponent = GetComponent<ShootComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        // GetAxisRaw para que el movimiento no sea smooth
        _verticalInput = Input.GetAxisRaw("Vertical");
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        Vector3 movementInput = new Vector3(_horizontalInput, _verticalInput, 0);
        _myPlayerMovementController.SetMovementDirection(movementInput);

        if (Input.GetKeyDown(KeyCode.Space) && !pressedSpace)
        {
            pressedSpace = true;
            _shootComponent.setFire(true);
        }

        if (Input.GetKeyUp(KeyCode.Space) && pressedSpace)
        {
            pressedSpace = false;
            _shootComponent.setFire(false);
        }
    }
}
