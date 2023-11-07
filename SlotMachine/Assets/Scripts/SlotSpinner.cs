using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

// One script to rule them all
public class SlotSpinner : MonoBehaviour
{
    [SerializeField]
    private Button spinButton;
    
    [SerializeField]
    private TMP_InputField serverAddressInputField;

    [Serializable]
    private class SpinCellMapping
    {
#if UNITY_EDITOR
        [HideInInspector]
        public string name;
#endif
        
        [HideInInspector]
        public SpinEnum spinEnum;
        
        public Sprite sprite;
    }
    
    [SerializeField]
    private List<SpinCellMapping> spinCellMappings;
    
    [SerializeField]
    private List<Image> spinCells;

    private void Awake()
    {
#if UNITY_EDITOR
        // sanitize
        
        if (spinButton == null)
        {
            Debug.LogError("Spin button is not set");
        }
        
        if (spinCells.Count != 3)
        {
            Debug.LogError("Spin cells are not set");
        }
#endif
    }

    public async void Spin()
    {
        try
        {
            // do not create a new api instance every time, it's expensive!!
            // This is just for demonstration purposes.
            var api = new SlotApi(serverAddressInputField.text);
            
            var result = await api.SpinAsync();
            Debug.Log(result);

            if (result is not SpinResult spinResult) return;
            if (spinResult.Spin1 is not SpinEnum r1) return;
            if (spinResult.Spin2 is not SpinEnum r2) return;
            if (spinResult.Spin3 is not SpinEnum r3) return;
            if (this == null) return;// we may have been destroyed while we were waiting for the result
            
            StartCoroutine(PerformSpinAnimation(r1, r2, r3));
        } catch (ApiException e)
        {
            Debug.LogError(e);
            // or crash gracefully :P
        }
    }

    private IEnumerator PerformSpinAnimation(SpinEnum r1, SpinEnum r2, SpinEnum r3)
    {
        // will obviously be stuck if paused!
        spinButton.enabled = false;
        
        // Total time it takes for the animation to run
        const float totalSpinTime = 3f;
        
        
        var start = Time.time;
        var normalizedTime = 0f;
        
        while (normalizedTime < 1f)
        {
            normalizedTime = Mathf.Clamp01((Time.time - start) / totalSpinTime);

            foreach (var spinCell in spinCells)
            {
                spinCell.sprite = spinCellMappings[Random.Range(0, spinCellMappings.Count)].sprite;
            }

            // not too fast or the players won't be able to see the animation
            yield return new WaitForSeconds(0.1f);
        }
        
        // Set the final result
        spinCells[0].sprite = spinCellMappings[(int) r1 - 1].sprite;
        spinCells[1].sprite = spinCellMappings[(int) r2 - 1].sprite;
        spinCells[2].sprite = spinCellMappings[(int) r3 - 1].sprite;
        
        spinButton.enabled = true;
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        // Really cheap, easy, and computationally inefficient way to make an (enum => T) mapping in unity.
        // Could be improved with a custom editor.
        if (Application.isPlaying) return;
        if (spinCellMappings == null) spinCellMappings = new List<SpinCellMapping>();
        
        var old = spinCellMappings;
        spinCellMappings = Enum.GetValues(typeof(SpinEnum))
            .Cast<SpinEnum>()
            .Select((x) =>
            {
                var mappingName = Enum.GetName(typeof(SpinEnum), x);
                var mapping = old.FirstOrDefault((y) => y.name == mappingName) ?? new SpinCellMapping();

                mapping.spinEnum = x;
                mapping.name = mappingName;
                return mapping;
            })
            .ToList();
    }
#endif
}
