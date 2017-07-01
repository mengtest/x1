
LResourceLoad = {};

local m_resRoot = nil;

function LResourceLoad.init()
    m_resRoot = "";
end

function LResourceLoad.loadTexture(resName)
    local resType = LuaHelper.GetType("UnityEngine.Texture");
    return LResourceLoad.load(resName, resType);
end

function LResourceLoad.loadText(resName)
    local resType = LuaHelper.GetType("UnityEngine.TextAsset");
    return LResourceLoad.load(resName, resType);
end

function LResourceLoad.loadAudio(resName)
    local resType = LuaHelper.GetType("UnityEngine.AudioClip");
    return LResourceLoad.load(resName, resType);
end

function LResourceLoad.loadFont(resName)
    local resType = LuaHelper.GetType("UnityEngine.Font");
    return LResourceLoad.load(resName, resType);
end

function LResourceLoad.loadMaterial(resName)
    local resType = LuaHelper.GetType("UnityEngine.Material");
    return LResourceLoad.load(resName, resType);
end

function LResourceLoad.loadPrefab(resName)
    local resType = LuaHelper.GetType("UnityEngine.GameObject");
    return LResourceLoad.load(resName, resType);
end

function LResourceLoad.load(resName, resType)
    return CS.UnityEngine.Resources.Load(resName, resType);
end
