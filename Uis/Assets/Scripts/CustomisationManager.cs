using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomisationManager : MonoBehaviour
{ 
    enum AppeareanceDetail
    {
        HAIR_MODEL,
        BEARD_MODEL,
        TUSK_MODEL,
        HAIR_COLOR,
        SKIN_COLOR


    }
    [SerializeField] private GameObject[] hairModels;
    [SerializeField] private Transform hairAnchor;
    private GameObject activeHair;
    private int hairIndex=0;
    Vector3 offset = new Vector3(- 0.181700006f, -0.0529999994f, 0.00600000005f);
    public void HairModelUp()
    {
        if (hairIndex<hairModels.Length-1)
        {
            hairIndex++;
        } else
        {
            hairIndex = 0;
        }
        ApplyModification(AppeareanceDetail.HAIR_MODEL, hairIndex);
    }
    public void HairModelDown()
    {
        if (hairIndex >0)
        {
            hairIndex--;
        }
        else
        {
            hairIndex= hairModels.Length - 1;
        }
        ApplyModification(AppeareanceDetail.HAIR_MODEL, hairIndex);

    }

     void ApplyModification(AppeareanceDetail detail, int id)
    {
        switch (detail)
        {
            case AppeareanceDetail.HAIR_MODEL:
                if(activeHair!=null)
                {
                    GameObject.Destroy(activeHair);

                    
                }
                activeHair = GameObject.Instantiate(hairModels[id]);
               activeHair.transform.SetParent(hairAnchor);
                
              
               activeHair.transform.ResetTransform();
                break;

        }
    }
}
