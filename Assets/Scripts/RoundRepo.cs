using System;
using System.Net.Http;
using DefaultNamespace;
using Persistence;
using UnityEngine;

public interface RoundRepo 
{
    public abstract Round OneRound();
}

public class ProductionRoundRepo : MonoBehaviour, RoundRepo
{
    [SerializeField] TextAsset JSONFile;
    
    public Round OneRound()
    {
        return LoadFromJson.OneRound(JSONFile.text);
    }
}

public class QaRoundRepo : MonoBehaviour, RoundRepo
{
    [SerializeField] string JSONtext;
    
    public Round OneRound()
    {
        return LoadFromJson.OneRound(JSONtext);
    }
}

public class TheNewIncredibleRoundRepo : RoundRepo
{
    public Round OneRound()
    {
        throw new NotImplementedException();
    }
}