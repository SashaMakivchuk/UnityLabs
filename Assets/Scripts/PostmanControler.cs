using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.InputSystem;


// NavMesh — це спеціалізована система в ігровому рушії Unity,
// призначена для автоматизації навігації та пошуку оптимальних шляхів
// для штучного інтелекту. Працює вона за принципом створення навігаційної сітки,
// яка накладається на геометрію вашої 3D-сцени та визначає, які саме
// ділянки поверхні є доступними для ходьби, а які - непрохідними перешкодами.
// Це дозволяє персонажу самостійно обчислювати найкоротший шлях до заданої цілі,
// обходячи кути, стіни або інші об'єкти, не потребуючи при цьому ручного прописування кожної точки маршруту.
// Використання цієї технології забезпечує реалістичну поведінку агентів,
// оскільки вони автоматично враховують межі доріг і перешкод, що є критично важливим
// для створення логічного та контрольованого переміщення у віртуальному середовищі.
public class PostmanControler : MonoBehaviour
{
    [Header("Financial Stats")]
    public float currentFunds = 11805;
    private const float pensionCost = 2361; 

    [Header("UI Elements")]
    public Text fundsText; 
    public GameObject completionPanel;

    [Header("Navigation")]
    public NavMeshAgent agent;

    void Start()
    {
        UpdateDisplay();
        completionPanel.SetActive(false);
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.CompareTag("House"))
                {
                    agent.SetDestination(hit.point);
                }
            }
        }
    }

    public void DeliverPension()
    {
        if (currentFunds >= pensionCost)
        {
            currentFunds -= pensionCost;
            UpdateDisplay();

            if (currentFunds < pensionCost)
            {
                completionPanel.SetActive(true);
            }
        }
    }

    void UpdateDisplay()
    {
        if (fundsText != null)
        {
            fundsText.text = "Funds: " + currentFunds.ToString() + " UAH";
        }
    }
}