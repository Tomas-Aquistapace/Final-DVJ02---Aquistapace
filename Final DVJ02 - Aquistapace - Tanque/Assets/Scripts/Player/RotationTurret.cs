using UnityEngine;

public class RotationTurret : MonoBehaviour
{
    [Header("Reticle")]
    public Transform reticleTrans;
    public Vector3 reticleAltitude;
    public LayerMask particularLayer;

    [Header("Rotation Turret")]
    public float speedRotation = 10f;
    public Transform turret;

    private new Camera camera;
    private Vector3 destinyRot;
    private Vector3 turretLookDir;

    PlayerStats player;

    void Start()
    {
        player = GetComponent<PlayerStats>();
        camera = GameObject.FindObjectOfType<Camera>();

        turretLookDir = reticleTrans.position - turret.position;
        turretLookDir.y = 0f;
    }

    void Update()
    {
        UpdateReticle();
        RotateTurret();
    }

    void UpdateReticle()
    {
        Ray mouseRay = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(mouseRay, out hit, 100, particularLayer))
        {
            reticleTrans.position = hit.point + reticleAltitude;
        }
    }

    void RotateTurret()
    {
        if (Input.GetMouseButton(0) && player.pState == PlayerStats.State.Playing)
        {
            turretLookDir = reticleTrans.position - turret.position;
            turretLookDir.y = 0f;
        }

        destinyRot = Vector3.Lerp(destinyRot, turretLookDir, Time.deltaTime * speedRotation);
        turret.rotation = Quaternion.LookRotation(destinyRot);
    }
}