using System.Collections.Generic;
using UnityEngine.Rendering;

namespace UnityEngine.Experimental.Rendering
{
    public static class RTHandles
    {
        static RTHandleSystem s_DefaultInstance = new RTHandleSystem();


        public static int maxWidth { get { return s_DefaultInstance.GetMaxWidth(); } }
        public static int maxHeight { get { return s_DefaultInstance.GetMaxHeight(); } }

        public static RTHandleSystem.RTHandle AllocFromDefault(
            Vector2 scaleFactor,
            FilterMode filterMode,
            RenderTextureFormat colorFormat,
            bool sRGB,
            string name)
        {
            return XRGraphics.enabled ? s_DefaultInstance.AllocFromDefault(scaleFactor, filterMode, colorFormat, sRGB, name) :
                s_DefaultInstance.Alloc(scaleFactor: scaleFactor, filterMode: filterMode, colorFormat: colorFormat, sRGB: sRGB, name: name);
        }
        public static RTHandleSystem.RTHandle AllocFromDefault(
            Vector2 scaleFactor,
            DepthBits depthBufferBits,
            FilterMode filterMode,
            RenderTextureFormat colorFormat,
            bool sRGB,
            bool enableRandomWrite,
            string name)
        {
            return XRGraphics.enabled ? s_DefaultInstance.AllocFromDefault(scaleFactor, depthBufferBits, filterMode, colorFormat, sRGB, enableRandomWrite, name) :
                s_DefaultInstance.Alloc(scaleFactor: scaleFactor, depthBufferBits: depthBufferBits, filterMode: filterMode, colorFormat: colorFormat, sRGB: sRGB, enableRandomWrite: enableRandomWrite, name: name);
        }
        public static RTHandleSystem.RTHandle AllocFromDefault(
            Vector2 scaleFactor,
            DepthBits depthBufferBits,
            FilterMode filterMode,
            RenderTextureFormat colorFormat,
            string name)
        {
            return XRGraphics.enabled ? s_DefaultInstance.AllocFromDefault(scaleFactor, depthBufferBits, filterMode, colorFormat, name) :
                s_DefaultInstance.Alloc(scaleFactor: scaleFactor, depthBufferBits: depthBufferBits, filterMode: filterMode, colorFormat: colorFormat, name: name);
        }
        public static RTHandleSystem.RTHandle AllocFromDefault(
            Vector2 scaleFactor,
            bool bindTextureMS,
            bool enableMSAA,
            DepthBits depthBufferBits,
            FilterMode filterMode,
            RenderTextureFormat colorFormat,
            string name)
        {
            return XRGraphics.enabled ? s_DefaultInstance.AllocFromDefault(scaleFactor, bindTextureMS, enableMSAA, depthBufferBits, filterMode, colorFormat, name) :
                s_DefaultInstance.Alloc(scaleFactor: scaleFactor, bindTextureMS: bindTextureMS, enableMSAA: enableMSAA, depthBufferBits: depthBufferBits, filterMode: filterMode, colorFormat: colorFormat, name: name);
        }

        public static RTHandleSystem.RTHandle AllocFromDefault(
            Vector2 scaleFactor,
            bool bindTextureMS,
            bool enableMSAA,
            FilterMode filterMode,
            RenderTextureFormat colorFormat,
            bool sRGB,
            string name)
        {
            return XRGraphics.enabled ? s_DefaultInstance.AllocFromDefault(scaleFactor, bindTextureMS, enableMSAA, filterMode, colorFormat, sRGB, name) :
                s_DefaultInstance.Alloc(scaleFactor: scaleFactor, bindTextureMS: bindTextureMS, enableMSAA: enableMSAA, filterMode: filterMode, colorFormat: colorFormat, sRGB: sRGB, name: name);
        }
        public static RTHandleSystem.RTHandle AllocFromDefault(
            Vector2 scaleFactor,
            FilterMode filterMode,
            RenderTextureFormat colorFormat,
            bool sRGB,
            bool enableRandomWrite,
            bool useMipMap,
            string name)
        {
            return XRGraphics.enabled ? s_DefaultInstance.AllocFromDefault(scaleFactor, filterMode, colorFormat, sRGB, enableRandomWrite, useMipMap, name) :
                 s_DefaultInstance.Alloc(scaleFactor: scaleFactor, filterMode: filterMode, colorFormat: colorFormat, sRGB: sRGB, enableRandomWrite: enableRandomWrite, useMipMap: useMipMap, name: name);
        }
        public static RTHandleSystem.RTHandle AllocFromDefault(
            Vector2 scaleFactor,
            FilterMode filterMode,
            RenderTextureFormat colorFormat,
            bool sRGB,
            bool enableRandomWrite,
            bool useMipMap,
            bool autoGenerateMips,
            string name)
        {
            return XRGraphics.enabled ? s_DefaultInstance.AllocFromDefault(scaleFactor, filterMode, colorFormat, sRGB, enableRandomWrite, useMipMap, autoGenerateMips, name) :
                s_DefaultInstance.Alloc(scaleFactor: scaleFactor, filterMode: filterMode, colorFormat: colorFormat, sRGB: sRGB, enableRandomWrite: enableRandomWrite, useMipMap: useMipMap, autoGenerateMips: autoGenerateMips, name: name);
        }
        public static RTHandleSystem.RTHandle AllocFromDefault(
            Vector2 scaleFactor,
            FilterMode filterMode,
            RenderTextureFormat colorFormat,
            bool sRGB,
            bool enableRandomWrite,
            string name)
        {
            return XRGraphics.enabled ? s_DefaultInstance.AllocFromDefault(scaleFactor, filterMode, colorFormat, sRGB, enableRandomWrite, name) :
                s_DefaultInstance.Alloc(scaleFactor: scaleFactor, filterMode: filterMode, colorFormat: colorFormat, sRGB: sRGB, enableRandomWrite: enableRandomWrite, name: name);
        }
        public static RTHandleSystem.RTHandle AllocFromDefault(
            ScaleFunc scaleFunc,
            FilterMode filterMode,
            RenderTextureFormat colorFormat,
            bool sRGB,
            bool enableRandomWrite,
            string name)
        {
            return XRGraphics.enabled ? s_DefaultInstance.AllocFromDefault(scaleFunc, filterMode, colorFormat, sRGB, enableRandomWrite, name) :
                s_DefaultInstance.Alloc(scaleFunc: scaleFunc, filterMode: filterMode, colorFormat: colorFormat, sRGB: sRGB, enableRandomWrite: enableRandomWrite, name: name);
        }

        public static RTHandleSystem.RTHandle Alloc(
            int width,
            int height,
            int slices = 1,
            DepthBits depthBufferBits = DepthBits.None,
            RenderTextureFormat colorFormat = RenderTextureFormat.Default,
            FilterMode filterMode = FilterMode.Point,
            TextureWrapMode wrapMode = TextureWrapMode.Repeat,
            TextureDimension dimension = TextureDimension.Tex2D,
            bool sRGB = true,
            bool enableRandomWrite = false,
            bool useMipMap = false,
            bool autoGenerateMips = true,
            int anisoLevel = 1,
            float mipMapBias = 0,
            MSAASamples msaaSamples = MSAASamples.None,
            bool bindTextureMS = false,
            bool useDynamicScale = false,
            VRTextureUsage vrUsage = VRTextureUsage.None,
            RenderTextureMemoryless memoryless = RenderTextureMemoryless.None,
            string name = ""
            )
        {
            return s_DefaultInstance.Alloc(
                width,
                height,
                slices,
                depthBufferBits,
                colorFormat,
                filterMode,
                wrapMode,
                dimension,
                sRGB,
                enableRandomWrite,
                useMipMap,
                autoGenerateMips,
                anisoLevel,
                mipMapBias,
                msaaSamples,
                bindTextureMS,
                useDynamicScale,
                vrUsage,
                memoryless,
                name
                );
        }

        public static RTHandleSystem.RTHandle Alloc(
            Vector2 scaleFactor,
            int slices = 1,
            DepthBits depthBufferBits = DepthBits.None,
            RenderTextureFormat colorFormat = RenderTextureFormat.Default,
            FilterMode filterMode = FilterMode.Point,
            TextureWrapMode wrapMode = TextureWrapMode.Repeat,
            TextureDimension dimension = TextureDimension.Tex2D,
            bool sRGB = true,
            bool enableRandomWrite = false,
            bool useMipMap = false,
            bool autoGenerateMips = true,
            int anisoLevel = 1,
            float mipMapBias = 0,
            bool enableMSAA = false,
            bool bindTextureMS = false,
            bool useDynamicScale = false,
            VRTextureUsage vrUsage = VRTextureUsage.None,
            RenderTextureMemoryless memoryless = RenderTextureMemoryless.None,
            string name = ""
            )
        {
            return s_DefaultInstance.Alloc(
                scaleFactor,
                slices,
                depthBufferBits,
                colorFormat,
                filterMode,
                wrapMode,
                dimension,
                sRGB,
                enableRandomWrite,
                useMipMap,
                autoGenerateMips,
                anisoLevel,
                mipMapBias,
                enableMSAA,
                bindTextureMS,
                useDynamicScale,
                vrUsage,
                memoryless,
                name
                );
        }

        public static RTHandleSystem.RTHandle Alloc(
            ScaleFunc scaleFunc,
            int slices = 1,
            DepthBits depthBufferBits = DepthBits.None,
            RenderTextureFormat colorFormat = RenderTextureFormat.Default,
            FilterMode filterMode = FilterMode.Point,
            TextureWrapMode wrapMode = TextureWrapMode.Repeat,
            TextureDimension dimension = TextureDimension.Tex2D,
            bool sRGB = true,
            bool enableRandomWrite = false,
            bool useMipMap = false,
            bool autoGenerateMips = true,
            int anisoLevel = 1,
            float mipMapBias = 0,
            bool enableMSAA = false,
            bool bindTextureMS = false,
            bool useDynamicScale = false,
            VRTextureUsage vrUsage = VRTextureUsage.None,
            RenderTextureMemoryless memoryless = RenderTextureMemoryless.None,
            string name = ""
            )
        {
            return s_DefaultInstance.Alloc(
                scaleFunc,
                slices,
                depthBufferBits,
                colorFormat,
                filterMode,
                wrapMode,
                dimension,
                sRGB,
                enableRandomWrite,
                useMipMap,
                autoGenerateMips,
                anisoLevel,
                mipMapBias,
                enableMSAA,
                bindTextureMS,
                useDynamicScale,
                vrUsage,
                memoryless,
                name
                );
        }

        public static void Initialize(
            int width,
            int height,
            bool scaledRTsupportsMSAA,
            MSAASamples scaledRTMSAASamples
            )
        {
            s_DefaultInstance.Initialize(
                width,
                height,
                scaledRTsupportsMSAA,
                scaledRTMSAASamples
                );
        }

        public static void Release(RTHandleSystem.RTHandle rth)
        {
            s_DefaultInstance.Release(rth);
        }

        public static void ResetReferenceSize(
            int width,
            int height,
            MSAASamples msaaSamples
            )
        {
            s_DefaultInstance.ResetReferenceSize(
                width,
                height,
                msaaSamples
                );
        }

        public static void SetReferenceSize(
            int width,
            int height,
            MSAASamples msaaSamples
            )
        {
            s_DefaultInstance.SetReferenceSize(
                width,
                height,
                msaaSamples
                );
        }
    }
}
