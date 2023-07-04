using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CharacterAiming : MonoBehaviour
{
    public float turnSpeed = 15;
    public Transform cameraLookAt;
    public AxisState xAxis;
    public AxisState yAxis;
    public bool isAiming;

    private Camera mainCamera;
    private Animator animator;
    private ActiveWeapon activeWeapon;
    private int isAimingParam = Animator.StringToHash("IsAiming");

    private void Awake()
    {
        mainCamera = Camera.main;
        animator = GetComponent<Animator>();
        activeWeapon = GetComponent<ActiveWeapon>();
    }

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        isAiming = Input.GetMouseButton(1);
        animator.SetBool(isAimingParam, isAiming);
        var weapon = activeWeapon.GetActiveWeapon();
        if (weapon)
        {
            weapon.weaponRecoil.recoilModifier = isAiming ? 0.3f : 1f;

            //if (isAiming)
            //{
            //    weapon.weaponRecoil.recoilModifier = 0.3f;
            //}
            //else
            //{
            //    weapon.weaponRecoil.recoilModifier = 1f;
            //}
        }
    }

    void FixedUpdate()
    {
        xAxis.Update(Time.fixedDeltaTime);
        yAxis.Update(Time.fixedDeltaTime);

        cameraLookAt.eulerAngles = new Vector3(yAxis.Value, xAxis.Value, 0);

        float yawCamera = mainCamera.transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yawCamera, 0), turnSpeed * Time.fixedDeltaTime);
    }
}
