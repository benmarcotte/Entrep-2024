using Firebase.Database;
using Firebase.Extensions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    private string scaleID;
    private DatabaseReference dbReference;
    public GameObject ScalePrefab;
    long tick = 0;

    // Start is called before the first frame update
    void Start()
    {
        int n = 0;
        dbReference = FirebaseDatabase.DefaultInstance.RootReference;
        FirebaseDatabase.DefaultInstance
      .GetReference("scales")
      .GetValueAsync().ContinueWithOnMainThread(task => {
          if (task.IsFaulted)
          {
              // Handle the error...
          }
          else if (task.IsCompleted)
          {
              DataSnapshot snapshot = task.Result;
              foreach (var i in (Dictionary<string, object>)snapshot.Value)
              {
                  n++;
                  var tempScale = Instantiate(ScalePrefab, gameObject.transform);
                  tempScale.GetComponent<MonoScale>().id = n;
                  tempScale.GetComponent<MonoScale>().uuid = i.Key;
                  foreach (var v in (Dictionary<string, object>)i.Value)
                  {
                      tempScale.GetComponent<MonoScale>().weight.text = v.Value.ToString();
                  }
              }
          }
      });
            FirebaseDatabase.DefaultInstance
      .GetReference("scales")
      .ValueChanged += HandleValueChanged;
    }


    void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }

        var snapshot = args.Snapshot;
        var scales = GetComponentsInChildren<MonoScale>();
        foreach (var sc in scales)
        {
            Debug.Log(snapshot.Child(sc.uuid).Children.Last().Value.ToString());
            sc.weight.text = snapshot.Child(sc.uuid).Children.Last().Value.ToString();
        }
    }

    private void CreateScale(string id, float weight)
    {
        Scale newScale = new Scale(id, weight);
        string json = JsonUtility.ToJson(newScale);

        dbReference.Child("scales").Child(id).SetRawJsonValueAsync(json);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        tick++;
        if (tick % 100 == 0)
        {
            UpdateScales();
        }
    }

    void UpdateScales()
    {
        DataSnapshot snapshot;

        FirebaseDatabase.DefaultInstance
        .GetReference("scales")
        .GetValueAsync().ContinueWithOnMainThread(task => {
          if (task.IsFaulted)
          {
          }
          else if (task.IsCompleted)
          {

            }
        });

    }
}

