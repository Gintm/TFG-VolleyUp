using DefaultNamespace;
using UnityEngine;

public class DependenciesInjection : MonoBehaviour
{
    PlayQuizController playQuizController;
    [SerializeField] PlayerDataScriptableObject gameData;
    [SerializeField] TextAsset JSONFile;
    RoundRepo roundRepo;

    void Awake()
    {
        playQuizController = GetComponent<PlayQuizController>();
        roundRepo = new OneQuestionOneAnswerRepo();
        roundRepo.LoadData( JSONFile );
        playQuizController.Inject( roundRepo, gameData );
    }
}
