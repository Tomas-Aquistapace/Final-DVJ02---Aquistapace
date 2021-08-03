using UnityEngine;

public class TankAnimation : MonoBehaviour
{
    [Header("Wheel Animation")]
    public GameObject[] wheels;
    [SerializeField] float speedRotation = 10f;

    [Header("Fire Animation")]
    public Animator animator;
    public GameObject shockWave;
    public Transform canyonTip;

    [Header("Move Animations")]
    public Animator moveAnimator;

    [Header("Loader Particles")]
    [SerializeField] GameObject[] radioLoader;
    [SerializeField] ParticleSystem[] bullSmokeInitial;
    [SerializeField] ParticleSystem[] bullSmokeLoader;
    [SerializeField] Gradient initialColor;
    [SerializeField] Gradient loadingColor;

    [Header("Destroy Effects")]
    [SerializeField] GameObject destroyParticle;
    [SerializeField] GameObject detroyedTank;

    void Start()
    {
        radioLoader[0].SetActive(true);
        radioLoader[1].SetActive(false);

        foreach (ParticleSystem bullParticle in bullSmokeInitial)
        {
            var col = bullParticle.colorOverLifetime;
            col.color = initialColor;
        }

        foreach (ParticleSystem bullParticle in bullSmokeLoader)
        {
            var col = bullParticle.colorOverLifetime;
            col.color = loadingColor;

            bullParticle.Stop(true);
        }
    }

    public void RotateWheels(float rotation)
    {
        if(rotation != 0)
        {
            foreach (GameObject wheel in wheels)
            {
                wheel.transform.Rotate(Vector3.right * rotation * speedRotation * Time.deltaTime);
            }
        }
    }

    public void FireAnimation()
    {
        animator.SetTrigger("Fire");

        GameObject particle = Instantiate(shockWave, canyonTip.position, canyonTip.rotation);
        Destroy(particle, 1f);
    }

    public void ActivateDeadAnim()
    {
        GameObject explosion = Instantiate(destroyParticle, transform.position, transform.rotation);
        Destroy(explosion, 5f);

        GameObject newTank = Instantiate(detroyedTank, transform.position, transform.rotation);
        this.gameObject.SetActive(false);
    }

    public void MissileLoader(bool state)
    {
        if (state)
        {
            radioLoader[0].SetActive(true);
            radioLoader[1].SetActive(false);
        }
        else
        {
            radioLoader[0].SetActive(false);
            radioLoader[1].SetActive(true);
        }
    }

    public void BullStrokeLoader(bool itsCharged)
    {
        if (itsCharged)
        {
            foreach (ParticleSystem bullParticle in bullSmokeInitial)
            {
                var col = bullParticle.colorOverLifetime;
                col.color = initialColor;

                bullParticle.Play(true);
            }

            foreach (ParticleSystem bullParticle in bullSmokeLoader)
            {
                var col = bullParticle.colorOverLifetime;
                col.color = loadingColor;

                bullParticle.Stop(true);
            }
        }
        else
        {
            foreach (ParticleSystem bullParticle in bullSmokeInitial)
            {
                var col = bullParticle.colorOverLifetime;
                col.color = initialColor;

                bullParticle.Stop(true);
            }

            foreach (ParticleSystem bullParticle in bullSmokeLoader)
            {
                var col = bullParticle.colorOverLifetime;
                col.color = loadingColor;

                bullParticle.Play(true);
            }
        }
    }
}
