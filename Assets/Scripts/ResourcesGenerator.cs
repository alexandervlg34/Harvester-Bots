using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesGenerator : MonoBehaviour
{
    [SerializeField] private List<GameObject> _resourcePrefabs;
    [SerializeField] private float _minDistanceBetweenResources = 2f;

    [SerializeField] private Score _score;

    private float _minXPosition = -20f, _maxXPosition = 20f;
    private float _yPosition = 1f;
    private float _minZPosition = -20f, _maxZPosition = 20f;

    private void Start()
    {
        if (_resourcePrefabs.Count == 0)
        {
            return;
        }

        StartCoroutine(GenerateResource());
    }

    private IEnumerator GenerateResource()
    {
        while (true)
        {
            float x = Random.Range(_minXPosition, _maxXPosition);
            float y = _yPosition;
            float z = Random.Range(_minZPosition, _maxZPosition);

            Vector3 randomPosition = new Vector3(x, y, z);

            if (IsPositionFarEnough(randomPosition) == false)
            {
                yield return null;
                continue;
            }

            int randomIndex = Random.Range(0, _resourcePrefabs.Count);
            GameObject resource = _resourcePrefabs[randomIndex];
            Quaternion resourceRotation = resource.transform.rotation;

            GameObject newResource = Instantiate(resource, randomPosition, resourceRotation);

            if (newResource.gameObject.TryGetComponent(out GoldenCoin goldenCoin))
            {
                goldenCoin.GoldDelivered += _score.UpdateGoldScore;
            }

            if (newResource.gameObject.TryGetComponent(out SilverCoin silverCoin))
            {
                silverCoin.SilverDelivered += _score.UpdateSilverScore;
            }

            yield return new WaitForSeconds(3f);
        }
    }

    private bool IsPositionFarEnough(Vector3 position)
    {
        Collider[] colliders = Physics.OverlapSphere(position, _minDistanceBetweenResources);

        foreach (Collider col in colliders)
        {
            if (col.TryGetComponent(out Resource resource))
            {
                return false;
            }

            if (col.TryGetComponent(out Unit unit))
            {
                return false;
            }
        }
        return true;
    }

    public void Destroy(Resource resource)
    {
        resource.gameObject.SetActive(false);

        if (resource.gameObject.TryGetComponent(out GoldenCoin goldenCoin))
        {
            goldenCoin.GoldDelivered -= _score.UpdateGoldScore;
        }

        if (resource.gameObject.TryGetComponent(out SilverCoin silverCoin))
        {
            silverCoin.SilverDelivered -= _score.UpdateSilverScore;
        }
    }
}
