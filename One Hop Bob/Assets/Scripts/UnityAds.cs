﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;
using UnityEngine.Advertisements;

public class UnityAds : MonoBehaviour
{
    public string placementId = "video";

    public void ShowAd()
    {
        StartCoroutine(ShowAdWhenReady());
    }

    private IEnumerator ShowAdWhenReady()
    {
        while (!Monetization.IsReady(placementId))
        {
            yield return new WaitForSeconds(0.25f);
        }

        ShowAdPlacementContent ad = null;
        ad = Monetization.GetPlacementContent(placementId) as ShowAdPlacementContent;

        if (ad != null)
        {
            ad.Show();
        }
    }

        string gameId = "3116483";
    bool testMode = true;

    void Start()
    {
        Monetization.Initialize(gameId, testMode);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
