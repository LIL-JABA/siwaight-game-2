using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class collector : MonoBehaviour
{
    int kebabs = 0;
    [SerializeField] Text kebabstext;
    [SerializeField] AudioSource collectionsound;
    [SerializeField] GameObject skibidi;
    [SerializeField] GameObject holodno;
    [SerializeField] GameObject brply;
    [SerializeField] GameObject muda;
    [SerializeField] GameObject dobdob;
    [SerializeField] GameObject pig1;
    [SerializeField] GameObject pig2;
    [SerializeField] GameObject pig3;
    [SerializeField] GameObject pig4;
    [SerializeField] GameObject pig5;
    [SerializeField] GameObject neswip;
    [SerializeField] AudioSource finish;
    private void Start()
    {
        skibidi.SetActive(false);
        muda.SetActive(false);
        dobdob.SetActive(false);
        holodno.SetActive(false);
        brply.SetActive(false);
        pig1.SetActive(false);
        pig2.SetActive(false);
        pig3.SetActive(false);
        pig4.SetActive(false);
        pig5.SetActive(false);
        neswip.SetActive(false);
    }

    IEnumerator stop()
    {
        finish.Play();
        yield return new WaitForSeconds(1);
        System.Random rnd = new System.Random();
        Application.Quit(rnd.Next() * -1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("kebab"))
        {
            Destroy(other.gameObject);
            kebabs++;
            Debug.Log($"Kebabs: {kebabs}");
            kebabstext.text = $"Собрано кебабов: {kebabs}/10";
            collectionsound.Play();

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


            if (kebabs == 10)
            {
                StartCoroutine(stop());
            }
        }

        if (other.gameObject.CompareTag("skibiditrig"))
        {
            skibidi.SetActive(true);
            Destroy(other.gameObject);
        }
    }
}
