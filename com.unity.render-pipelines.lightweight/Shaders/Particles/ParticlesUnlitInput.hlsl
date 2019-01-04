#ifndef LIGHTWEIGHT_PARTICLES_UNLIT_INPUT_INCLUDED
#define LIGHTWEIGHT_PARTICLES_UNLIT_INPUT_INCLUDED

#include "Packages/com.unity.render-pipelines.lightweight/ShaderLibrary/Particles.hlsl"

CBUFFER_START(UnityPerMaterial)
float4 _SoftParticleFadeParams;
float4 _CameraFadeParams;
float4 _BaseMap_ST;
half4 _BaseColor;
half4 _EmissionColor;

#if defined (_COLORADDSUBDIFF_ON)
    half4 _BaseColorAddSubDiff;
#endif

half _Cutoff;

#if defined (_DISTORTION_ON)
half _DistortionStrengthScaled;
half _DistortionBlend;
#endif

CBUFFER_END

#define SOFT_PARTICLE_NEAR_FADE _SoftParticleFadeParams.x
#define SOFT_PARTICLE_INV_FADE_DISTANCE _SoftParticleFadeParams.y

#define CAMERA_NEAR_FADE _CameraFadeParams.x
#define CAMERA_INV_FADE_DISTANCE _CameraFadeParams.y

half4 SampleAlbedo(float2 uv, float3 blendUv, half4 color, float4 particleColor, float4 projectedPosition, TEXTURE2D_ARGS(albedoMap, sampler_albedoMap))
{
    half4 albedo = BlendTexture(TEXTURE2D_PARAM(albedoMap, sampler_albedoMap), uv, blendUv) * color;

    // No distortion Support
    half4 colorAddSubDiff = half4(0, 0, 0, 0);
#if defined (_COLORADDSUBDIFF_ON)
    colorAddSubDiff = _BaseColorAddSubDiff;
#endif
    albedo = MixParticleColor(albedo, particleColor, colorAddSubDiff);
    
    AlphaDiscard(albedo.a, _Cutoff);
    
 #if defined(SOFTPARTICLES_ON)
     ALBEDO_MUL *= SoftParticles(SOFT_PARTICLE_NEAR_FADE, SOFT_PARTICLE_INV_FADE_DISTANCE, projectedPosition);
 #endif
 
 #if defined(_FADING_ON)
     ALBEDO_MUL *= CameraFade(CAMERA_NEAR_FADE, CAMERA_INV_FADE_DISTANCE, projectedPosition);
 #endif

    return albedo;
}

#endif // LIGHTWEIGHT_PARTICLES_PBR_INCLUDED
