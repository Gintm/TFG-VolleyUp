using System;
using System.Net.Http;
using DefaultNamespace;
using Persistence;
using UnityEngine;

public interface RoundRepo 
{
    public void LoadData( TextAsset file );
    public abstract Round OneRound();
}

public class OneQuestionOneAnswerRepo : MonoBehaviour, RoundRepo
{
    TextAsset JSONFile;

    public void LoadData(TextAsset file)
    {
        JSONFile = file;
    }

    public Round OneRound()
    {
        return LoadFromJson.OneRound( JSONFile.text );
    }
}

//public class QaRoundRepo : MonoBehaviour, RoundRepo
//{
//    [SerializeField] string JSONtext;
    
//    public Round OneRound()
//    {
//        return LoadFromJson.OneRound(JSONtext);
//    }
//}

//public class TheNewIncredibleRoundRepo : RoundRepo
//{
//    public Round OneRound()
//    {
//        throw new NotImplementedException();
//    }
//}