using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors.Visuals;

public class Gun : XRGrabInteractable
{
    public float range = 100f;
    public GameObject hand;
    public GameObject gunFireEffect;
    private ShootingRangeScore shootingRangeScore;
    public GameObject backLight;
    public GameObject targetSpawner;
    public XRInteractorLineVisual rayInteractorLine;
    public float ClipSize = 6;
    public AudioClip shootSound;
    public AudioClip emptyClipSound;
    public AudioClip reloadSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        shootingRangeScore = ShootingRangeScore.instance;
    }

    protected override void OnActivated(ActivateEventArgs args)
    {

        Shoot();
    }


    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        targetSpawner.SetActive(true);
        backLight.SetActive(true);
    }


    void Shoot()
    {
        if (ClipSize > 0)
        {
            gunFireEffect.SetActive(false);
            gunFireEffect.SetActive(true);
            audioSource.PlayOneShot(shootSound);
            ClipSize--;
        }
        else
        {
            audioSource.PlayOneShot(emptyClipSound);
            return;
        }
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, range))
        {
            if (hit.collider.CompareTag("Green"))
            {
                shootingRangeScore.UpdateDoubleScore();
                Destroy(hit.collider.gameObject);
            }
            else if (hit.collider.CompareTag("Red"))
            {
                shootingRangeScore.UpdateScoreText();
                Destroy(hit.collider.gameObject);
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Clip"))
        {
            audioSource.PlayOneShot(reloadSound);
            ClipSize = 6;
            Destroy(other.gameObject);
        }
    }
}
