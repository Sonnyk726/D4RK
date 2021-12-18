using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VHS;

public class PlayerWeapons : MonoBehaviour
{
    [Header("Animation")]
    public Animator _playerAnimController;
    float _myCurrentSpeed;

    [Header("Weapons")]
    public GameObject[] _playerWeapons;
    public AnimationClip[] _weaponFireAnimations;
    GameObject _myCurrentWeapon;
    private bool _canSwitchWeapon;
    int _weaponIndex;

    // Start is called before the first frame update
    void Start()
    {
        _myCurrentWeapon = _playerWeapons[0];

        if (!_playerAnimController)
        {
            _playerAnimController = gameObject.GetComponent<Animator>();
        }
    }

    void Update()
    {
        _myCurrentSpeed = GetComponent<FirstPersonController>().m_currentSpeed;
        _playerAnimController.SetFloat("PlayerSpeed", _myCurrentSpeed);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            {
                StartCoroutine(Fire(_weaponIndex));
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            {
                SecondaryWeapon();
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && _playerWeapons.Length > 1 && _canSwitchWeapon)
        {
            {
                SwitchWeapon(3); //Need to improve this
            }
        }
    }

    public void SwitchWeapon(int _weapon)
    {
        _weaponIndex = _weapon;
        _playerAnimController.SetTrigger("Switch");

        //Show Crosshair
    }

    public void SecondaryWeapon()
    {
        {
            _weaponIndex = 2;
            //Show Crosshair

            Debug.Log("Secondary Weapon");
        }
    }

    public IEnumerator Fire(int weaponIndex)
    {
        _canSwitchWeapon = false;
        Debug.Log("Fired");
        //Instantiate a bullet and VFX
        //Play Audio
        //Apply Recoil

        yield return new WaitForSeconds(_weaponFireAnimations[weaponIndex].length);
    }
}
