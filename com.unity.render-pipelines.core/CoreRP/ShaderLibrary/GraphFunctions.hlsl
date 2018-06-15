#ifndef UNITY_GRAPHFUNCTIONS_INCLUDED
#define UNITY_GRAPHFUNCTIONS_INCLUDED

// ----------------------------------------------------------------------------
// Included in generated graph shaders
// ----------------------------------------------------------------------------

struct Gradient
{
    int type;
    int colorsLength;
    int alphasLength;
    float4 colors[8];
    float2 alphas[8];
};

#ifndef SHADERGRAPH_SAMPLE_SCENE_DEPTH
    #define SHADERGRAPH_SAMPLE_SCENE_DEPTH(uv) shadergraph_SampleSceneDepth(uv);
#endif

#ifndef SHADERGRAPH_SAMPLE_SCENE_COLOR
    #define SHADERGRAPH_SAMPLE_SCENE_COLOR(uv) shadergraph_SampleSceneColor(uv);
#endif

#ifndef SHADERGRAPH_SAMPLE_BAKED_GI
    #define SHADERGRAPH_SAMPLE_BAKED_GI(normal) shadergraph_SampleBakedGI(normal);
#endif

#ifndef SHADERGRAPH_SAMPLE_SHADOWMASK
    #define SHADERGRAPH_SAMPLE_SHADOWMASK(positionWS, uv) shadergraph_SampleShadowmask(positionWS, uv);
#endif

float shadergraph_SampleSceneDepth(float2 uv)
{
    return 1;
}

float3 shadergraph_SampleSceneColor(float2 uv)
{
    return 0;
}

float shadergraph_SampleBakedGI(float3 normal)
{
    return 0;
}

float4 shadergraph_SampleShadowmask(float3 positionWS, float2 uv)
{
    return 0;
}

#endif // UNITY_GRAPHFUNCTIONS_INCLUDED
