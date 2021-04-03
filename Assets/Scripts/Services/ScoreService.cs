using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreService
{
    public float BestResult = 0;
    public float Result = 0;

    private IScorePrefs Prefs = new DefaultPrefs();

    public void Save()
    {
        Prefs.Save(this);
    }

    public void Init()
    {
        Prefs.Load(this);
    }
}



interface IScorePrefs
{
    void Load(ScoreService service);
    void Save(ScoreService service);

}
class DefaultPrefs : IScorePrefs
{
    public void Load(ScoreService service)
    {
        service.BestResult = PlayerPrefs.GetFloat("Best Result");
    }

    public void Save(ScoreService service)
    {
        PlayerPrefs.SetFloat("Best Result", service.BestResult);
    }
}
