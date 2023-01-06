using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class collector : MonoBehaviour
{
    int kebabs = 0;
    int targets = 0;
    [SerializeField] AudioSource start_sound;
    [SerializeField] GameObject player_model;
    [SerializeField] GameObject hog_player;
    [SerializeField] Text kebabstext;
    [SerializeField] AudioSource collectionsound;
    [SerializeField] GameObject skibidi;
    [SerializeField] GameObject holodno;
    [SerializeField] GameObject brply;
    [SerializeField] GameObject muda;
    [SerializeField] GameObject pig1;
    [SerializeField] GameObject pig2;
    [SerializeField] GameObject pig3;
    [SerializeField] GameObject pig4;
    [SerializeField] GameObject pig5;
    [SerializeField] GameObject neswip;
    [SerializeField] GameObject genji;
    [SerializeField] AudioSource finish;
    //[SerializeField] AudioSource genjikill;
    //[SerializeField] AudioSource genjifinish;
    [SerializeField] GameObject podvaldoor;
    [SerializeField] GameObject bigroadhog;
    [SerializeField] AudioSource roadhog_laugh;
    private void Start()
    {
        hog_player.SetActive(false);
        start_sound.Play();
        skibidi.SetActive(false);
        muda.SetActive(false);
        holodno.SetActive(false);
        brply.SetActive(false);
        pig1.SetActive(false);
        pig2.SetActive(false);
        pig3.SetActive(false);
        pig4.SetActive(false);
        pig5.SetActive(false);
        neswip.SetActive(false);
        genji.SetActive(false);
        bigroadhog.SetActive(false);
    }

    IEnumerator stop()
    {
        finish.Play();
        yield return new WaitForSeconds(1);
        Application.Quit(0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("kebab"))
        {
            Destroy(other.gameObject);
            kebabs++;
            Debug.Log($"Kebabs: {kebabs}");
            kebabstext.text = $"Собрано кебабов: {kebabs}/13";

            collectionsound.Play();
            if (other.gameObject.name == "kebab (6)")
            {
                podvaldoor.SetActive(false);
            }
            if(other.gameObject.name == "kebab (4)")
            {
                holodno.SetActive(true);
            }
            if(other.gameObject.name == "kebab (8)")
            {
                brply.SetActive(true);
            }
            if (other.gameObject.name == "kebab (3)")
            {
                muda.SetActive(true);
            }
            if (other.gameObject.name == "kebab (2)")
            {
                pig1.SetActive(true);
                pig2.SetActive(true);
                pig3.SetActive(true);
                pig4.SetActive(true);
                pig5.SetActive(true);
            }
            if (other.gameObject.name == "kebab (7)")
            {
                neswip.SetActive(true);
            }


            if (kebabs == 13)
            {
                StartCoroutine(stop());
            }
        }

        if (other.gameObject.CompareTag("skibiditrig"))
        {
            skibidi.SetActive(true);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("dragonblade"))
        {
            Destroy(other.gameObject);
            player_model.SetActive(false);
            start_sound.Play();
            genji.SetActive(true);
            //genjistart.Play();
        }
        if (other.gameObject.CompareTag("genjitarget"))
        {
            Destroy(other.gameObject);
            targets++;
            if (targets == 4)
            {
                player_model.SetActive(true);
                genji.SetActive(false);
            }
        }
        if (other.gameObject.CompareTag("hogtriger"))
        {
            Destroy(other.gameObject);
            bigroadhog.SetActive(true);
            roadhog_laugh.Play();
        }
    }
}
