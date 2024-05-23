// **************************************************************** //
//
//   Copyright (c) RimuruDev. All rights reserved.
//   For Project: "Murders Drones Endless Way".
//   Contact me: 
//          - Gmail:    rimuru.dev@gmail.com
//          - GitHub:   https://github.com/RimuruDev
//          - LinkedIn: https://www.linkedin.com/in/rimuru/
//          - GitHub Organizations: https://github.com/Rimuru-Dev
//
// **************************************************************** //

using UnityEngine;

namespace RimuruDev
{
    [SelectionBase]
    [DisallowMultipleComponent]
    [HelpURL("https://github.com/RimuruDev/AdaptiveSkyboxScaler")]
    public sealed class AdaptiveSkyboxScaler : MonoBehaviour
    {
        private static readonly int FrontTex = Shader.PropertyToID("_FrontTex");

        [SerializeField] private bool enableDebugLog = true;
        [SerializeField] private SpriteRenderer backgroundSpriteRenderer;

        private Camera mainCamera;
        private Material skyboxMaterial;
        private Texture2D skyboxTexture;
        private Sprite skyboxSprite;

        private void Awake()
        {
            CacheComponents();
            ValidateComponents();
            SetupBackground();
        }

        private void CacheComponents()
        {
            mainCamera = Camera.main;
            skyboxMaterial = RenderSettings.skybox;

            if (skyboxMaterial != null)
                skyboxTexture = skyboxMaterial.GetTexture(FrontTex) as Texture2D;
        }

        private void ValidateComponents()
        {
            if (backgroundSpriteRenderer == null)
                LogError("SpriteRenderer is not assigned.");

            if (mainCamera == null)
                LogError("Main Camera not found.");

            if (skyboxMaterial == null)
                LogError("No skybox material found in RenderSettings.");

            if (skyboxTexture == null)
                LogError("Skybox material does not have a texture named _FrontTex.");
        }

        private void SetupBackground()
        {
            if (backgroundSpriteRenderer == null || mainCamera == null || skyboxTexture == null)
                return;

            Rect spriteRect = new Rect(0, 0, skyboxTexture.width, skyboxTexture.height);

            skyboxSprite = Sprite.Create(skyboxTexture, spriteRect, new Vector2(0.5f, 0.5f), 100f);
            backgroundSpriteRenderer.sprite = skyboxSprite;
            backgroundSpriteRenderer.sortingOrder = -999;

            ScaleBackground();
        }

        private void LateUpdate() =>
            ScaleBackground();

        private void ScaleBackground()
        {
            if (mainCamera == null || backgroundSpriteRenderer.sprite == null)
                return;

            var targetHeight = mainCamera.orthographicSize * 2;
            var targetWidth = targetHeight * Screen.width / Screen.height;

            Vector2 backgroundSize = backgroundSpriteRenderer.sprite.bounds.size;

            var widthRatio = targetWidth / backgroundSize.x;
            var heightRatio = targetHeight / backgroundSize.y;
            var targetScale = Mathf.Max(widthRatio, heightRatio);

            backgroundSpriteRenderer.transform.localScale = Vector3.one * targetScale;
        }

        private void LogError(string message)
        {
            if (!enableDebugLog)
                return;

            Debug.LogError(message, gameObject);
        }
    }
}