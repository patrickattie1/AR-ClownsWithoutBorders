/*==============================================================================
Copyright (c) 2017 PTC Inc. All Rights Reserved.

Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using UnityEngine.Video;
using Vuforia;

/// <summary>
///     A custom handler that implements the ITrackableEventHandler interface.
/// </summary>
public class DefaultTrackableEventHandler : MonoBehaviour, ITrackableEventHandler
{
    #region PRIVATE_MEMBER_VARIABLES

    protected TrackableBehaviour mTrackableBehaviour;

	public AudioSource asource;
	public AudioClip aClip;

	public VideoPlayer vPlayer;

	public static bool targetDetected = false;

    #endregion // PRIVATE_MEMBER_VARIABLES

    #region UNTIY_MONOBEHAVIOUR_METHODS

    protected virtual void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
    }

    #endregion // UNTIY_MONOBEHAVIOUR_METHODS

    #region PUBLIC_METHODS

    /// <summary>
    ///     Implementation of the ITrackableEventHandler function called when the
    ///     tracking state changes.
    /// </summary>
    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
            OnTrackingFound();

			if ((mTrackableBehaviour.TrackableName == "CATALOGUE_EXPO") ||
				(mTrackableBehaviour.TrackableName == "11-EcoleCommunaleFortMercredi") ||
				(mTrackableBehaviour.TrackableName == "CSFTestImage1") ||
				(mTrackableBehaviour.TrackableName == "13-Damien") ||
				(mTrackableBehaviour.TrackableName == "12-CampFortuneStadeSylvioCator") ||
				(mTrackableBehaviour.TrackableName == "14-AtelieEcritureEcoleMunicipalePortailLeogane") ||
				(mTrackableBehaviour.TrackableName == "15-EcoleMunicipaleStMartin") ||
				(mTrackableBehaviour.TrackableName == "News1_Page1") ||
				(mTrackableBehaviour.TrackableName == "News1_Page2") ||
				(mTrackableBehaviour.TrackableName == "News1_Page3") ||
				(mTrackableBehaviour.TrackableName == "News1_Page4") ||
				(mTrackableBehaviour.TrackableName == "News2_Page1") ||
				(mTrackableBehaviour.TrackableName == "21-EcoleCommunaleFortMercrediFouleEbahie") ||
				(mTrackableBehaviour.TrackableName == "22-EcoleMunicipalePortailLeoganeCoursEcole") ||
				(mTrackableBehaviour.TrackableName == "16-EcoleMunicipalePortailLeogane") ||
				(mTrackableBehaviour.TrackableName == "23-ChampDeMars2") ||
				(mTrackableBehaviour.TrackableName == "17-ReminiscenceTheatrale") ||
				(mTrackableBehaviour.TrackableName == "18-ChampDeMars") ||
				(mTrackableBehaviour.TrackableName == "19-EcoleDevasteeJesusDePrague") ||
				(mTrackableBehaviour.TrackableName == "24-EcoleMunicipaleDumarsaisEstime") ||
				(mTrackableBehaviour.TrackableName == "00-Affiche82018") ||
				(mTrackableBehaviour.TrackableName == "0-CatalogueExpoReprocessed1"))

			{
				if (mTrackableBehaviour.TrackableName == "22-EcoleMunicipalePortailLeoganeCoursEcole") 
				{
					asource.loop = true;
					asource.Play();
				} 
				else 
				{
					asource.PlayOneShot (aClip);
				}

				//Handheld.PlayFullScreenMovie (vPlayer.clip.name, Color.black, FullScreenMovieControlMode.CancelOnInput, FullScreenMovieScalingMode.Fill);
				vPlayer.Play ();
			}
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NOT_FOUND)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
            OnTrackingLost();

			if ((mTrackableBehaviour.TrackableName == "CATALOGUE_EXPO") ||
				(mTrackableBehaviour.TrackableName == "11-EcoleCommunaleFortMercredi") ||
				(mTrackableBehaviour.TrackableName == "CSFTestImage1") ||
				(mTrackableBehaviour.TrackableName == "13-Damien") ||
				(mTrackableBehaviour.TrackableName == "12-CampFortuneStadeSylvioCator") ||
				(mTrackableBehaviour.TrackableName == "14-AtelieEcritureEcoleMunicipalePortailLeogane") ||
				(mTrackableBehaviour.TrackableName == "15-EcoleMunicipaleStMartin") ||
				(mTrackableBehaviour.TrackableName == "News1_Page1") ||
				(mTrackableBehaviour.TrackableName == "News1_Page2") ||
				(mTrackableBehaviour.TrackableName == "News1_Page3") ||
				(mTrackableBehaviour.TrackableName == "News1_Page4") ||
				(mTrackableBehaviour.TrackableName == "News2_Page1") ||
				(mTrackableBehaviour.TrackableName == "21-EcoleCommunaleFortMercrediFouleEbahie") ||
				(mTrackableBehaviour.TrackableName == "22-EcoleMunicipalePortailLeoganeCoursEcole") ||
				(mTrackableBehaviour.TrackableName == "16-EcoleMunicipalePortailLeogane") ||
				(mTrackableBehaviour.TrackableName == "23-ChampDeMars2") ||
				(mTrackableBehaviour.TrackableName == "17-ReminiscenceTheatrale") ||
				(mTrackableBehaviour.TrackableName == "18-ChampDeMars") ||
				(mTrackableBehaviour.TrackableName == "19-EcoleDevasteeJesusDePrague") ||
				(mTrackableBehaviour.TrackableName == "24-EcoleMunicipaleDumarsaisEstime") ||
				(mTrackableBehaviour.TrackableName == "00-Affiche82018") ||
				(mTrackableBehaviour.TrackableName == "0-CatalogueExpoReprocessed1"))
			{
				asource.loop = false;
				asource.Stop ();
				vPlayer.Stop ();
			}
        }
        else
        {
            // For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
            // Vuforia is starting, but tracking has not been lost or found yet
            // Call OnTrackingLost() to hide the augmentations
            OnTrackingLost();
        }
    }

    #endregion // PUBLIC_METHODS

    #region PRIVATE_METHODS

	//Called when any of the image target is tracked
    protected virtual void OnTrackingFound()
    {
		//Target detected
		targetDetected = true;

        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

        // Enable rendering:
        foreach (var component in rendererComponents)
            component.enabled = true;

        // Enable colliders:
        foreach (var component in colliderComponents)
            component.enabled = true;

        // Enable canvas':
        foreach (var component in canvasComponents)
            component.enabled = true;
    }


    protected virtual void OnTrackingLost()
    {
		//Target detected
		targetDetected = false;

        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

        // Disable rendering:
        foreach (var component in rendererComponents)
            component.enabled = false;

        // Disable colliders:
        foreach (var component in colliderComponents)
            component.enabled = false;

        // Disable canvas':
        foreach (var component in canvasComponents)
            component.enabled = false;
    }

    #endregion // PRIVATE_METHODS
}
