
LBundleLoad = {};

local m_resRoot = nil;

function LBundleLoad.init()
    m_resRoot = "";
end

function LBundleLoad.loadTexture(resName)
    local resType = LuaHelper.GetType("UnityEngine.Texture");
    return LBundleLoad.load(resName, resType);
end

function LBundleLoad.loadText(resName)
    local resType = LuaHelper.GetType("UnityEngine.TextAsset");
    return LBundleLoad.load(resName, resType);
end

function LBundleLoad.loadAudio(resName)
    local resType = LuaHelper.GetType("UnityEngine.AudioClip");
    return LBundleLoad.load(resName, resType);
end

function LBundleLoad.loadFont(resName)
    local resType = LuaHelper.GetType("UnityEngine.Font");
    return LBundleLoad.load(resName, resType);
end

function LBundleLoad.loadMaterial(resName)
    local resType = LuaHelper.GetType("UnityEngine.Material");
    return LBundleLoad.load(resName, resType);
end

function LBundleLoad.loadPrefab(resName)
    local resType = LuaHelper.GetType("UnityEngine.GameObject");
    return LBundleLoad.load(resName, resType);
end

function LBundleLoad.load(resName, resType)
    return CS.UnityEngine.Resources.Load(resName, resType);
end
