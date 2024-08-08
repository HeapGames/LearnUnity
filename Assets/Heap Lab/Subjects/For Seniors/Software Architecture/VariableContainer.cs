using UnityEngine;

public class VariableContainer : BaseSingleton<VariableContainer>
{
    // Sahnede oyuna özgü objeleri tutmak için kullanılacak.
    public GameObject Player { get; set; }
    public GameObject Enemy { get; set; }
    public GameObject CollectibleItem { get; set; }

    protected override void Awake()
    {
        base.Awake();
        // Diğer başlangıç ayarları
    }
}
