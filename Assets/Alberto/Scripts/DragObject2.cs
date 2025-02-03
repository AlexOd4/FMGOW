using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class DragObject2 : MonoBehaviour
{
    private Camera mainCamera;
    private bool isDragging = false;
    private bool isShootable;
    private Vector3 offset;

    [SerializeField] private int trajectoryPoints = 30; // Puntos de la trayectoria
    [SerializeField] private float timeStep = 0.1f; // Intervalo de tiempo entre puntos
    [SerializeField] private Transform OGPos; // Posición original

    [SerializeField] private GameObject mainGo; // gameobject principal
    [SerializeField] private Rigidbody mainRb; // Rigidbody principal

    [SerializeField] private LineRenderer lineRenderer; // LineRenderer para la trayectoria

    [SerializeField] private GameObject PivotGo;

    public float shootForce; // Fuerza del disparo

    private float distance;
    private Rigidbody rb;
    private Vector3 shootDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;

        // Configurar el LineRenderer
        if (lineRenderer == null)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }

        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.positionCount = 0; // Inicialmente no se dibuja la trayectoria
    }

    void OnMouseDown()
    {
        isDragging = true;

        // Calcular el offset entre el ratón y el objeto
        Vector3 mouseWorldPosition = GetMouseWorldPosition();
        offset = transform.position - mouseWorldPosition;
    }

    void OnMouseUp()
    {
        isDragging = false;


        if (isShootable)
        {
            mainRb.isKinematic = false;
            mainRb.AddForce(shootDirection.normalized * distance * shootForce, ForceMode.Impulse);

            transform.position = OGPos.position;
        }
        else
        {
            transform.DOMove(OGPos.position, 1f)
                .SetEase(Ease.OutElastic, amplitude: 5f, period: 0.5f);
        }

        // Limpiar la trayectoria
        lineRenderer.positionCount = 0;
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, OGPos.position);

        shootDirection = PivotGo.transform.position - transform.position;

        if (isDragging)
        {
            Vector3 mouseWorldPosition = GetMouseWorldPosition();
            transform.position = mouseWorldPosition + offset;

            CheckIfInBottomZone();

            if (isShootable)
            {
                DrawTrajectory(); // Dibujar la trayectoria solo si es disparable
            }
            else
            {
                lineRenderer.positionCount = 0; // Borrar la trayectoria si no es disparable
            }
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = mainCamera.WorldToScreenPoint(transform.position).z; // Profundidad
        return mainCamera.ScreenToWorldPoint(mouseScreenPosition);
    }

    void CheckIfInBottomZone()
    {
        Vector3 screenPosition = mainCamera.WorldToScreenPoint(transform.position);
        float bottomThreshold = Screen.height * 0.1f;

        isShootable = screenPosition.y <= bottomThreshold;
    }

    void DrawTrajectory()
    {
        Vector3[] points = new Vector3[trajectoryPoints];
        Vector3 startPosition = transform.position;
        Vector3 initialVelocity = shootDirection.normalized * shootForce * distance;

        for (int i = 0; i < trajectoryPoints; i++)
        {
            float time = i * timeStep;

            Vector3 position = startPosition
                + initialVelocity * time
                + 0.5f * Physics.gravity * time * time;

            points[i] = position;

            if (position.y < -0.644177794)
            {
                break;
            }
        }

        // Asignar los puntos al LineRenderer
        lineRenderer.positionCount = points.Length;
        lineRenderer.SetPositions(points);
    }
}
