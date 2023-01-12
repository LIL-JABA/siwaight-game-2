using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class collector : MonoBehaviour
{
    int targets = 0;
    [SerializeField] GameObject player_model;
    [SerializeField] GameObject hog_player;
    [SerializeField] GameObject genji;

    [SerializeField] Text kebabstext;

    [SerializeField] AudioSource collectionsound;
    [SerializeField] AudioSource finish;
    [SerializeField] AudioSource start_sound;
    [SerializeField] AudioSource roadhog_laugh;

    GameObject followpig, flyingpigs, skibidi, holodno, brply, muda, neswip, podvaldoor, bigroadhog;

    private void Start()
    {
        kebabstext.text = $"Собрано кебабов: {GlobalVarStorage.kebabs}/{GlobalVarStorage.maxKebabs}";

        followpig = getobj("followpig");
        flyingpigs = getobj("flyingpigs");
        skibidi = getobj("skibidiplay");
        holodno = getobj("holodnoplay");
        brply = getobj("brplyplay");
        muda = getobj("mudaplay");
        neswip = getobj("neswipplay");
        podvaldoor = getobj("podvaldoor");
        bigroadhog = getobj("bigroadhog");

        List<GameObject> gameobjects = new List<GameObject>() { followpig, flyingpigs, skibidi, 
            holodno, brply, muda, neswip, podvaldoor, bigroadhog, genji, hog_player };

        foreach (GameObject obj in gameobjects)
        {
            if (obj != null && this.gameObject.name == "player") obj.SetActive(false);
        }
        start_sound.Play();
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
            GlobalVarStorage.kebabs++;
            int kebabs = GlobalVarStorage.kebabs;
            Debug.Log($"Kebabs: {kebabs}");
            kebabstext.text = $"Собрано кебабов: {kebabs}/{GlobalVarStorage.maxKebabs}";

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
                flyingpigs.SetActive(true);
            }
            if (other.gameObject.name == "kebab (7)")
            {
                neswip.SetActive(true);
            }

            if (other.gameObject.name == "kebab (1)") // swap hog and pig
            {
                Destroy(player_model);
                hog_player.SetActive(true);
                Destroy(GameObject.FindWithTag("followhog"));
                followpig.SetActive(true);
            }

            if (kebabs == GlobalVarStorage.maxKebabs)
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
            this.gameObject.SetActive(false);
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
                if(player_model != null)
                {
                    player_model.SetActive(true);
                }
                else
                {
                    hog_player.SetActive(true);
                }
                
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
    private GameObject getobj(string tag)
    {
        return GameObject.FindWithTag(tag);
    }
}
