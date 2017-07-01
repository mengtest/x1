
GUIManager = {};

local m_guilist = nil;
local m_guiRoot = "GUI"
local m_canvas = nil;

function GUIManager.init()
    m_guilist = {};
    m_canvas = LuaHelper.getCanvas();
end

function GUIManager.pushUI(uiName, isDialog)
    local guiInfo = {};
    local oldInfo = m_guilist[#m_guilist];

    guiInfo.uiName = uiName;
    guiInfo.isDialog = isDialog;
    guiInfo.prefab = LuaHelper.loadGameObject(m_guiRoot .. '/' .. uiName);
    guiInfo.gameObject = LuaHelper.createGameObject(guiInfo.prefab, m_canvas.transform);

    GUIManager.bind_listener(uiName, guiInfo.gameObject.transform);


    table.insert(m_guilist, guiInfo);
end

function GUIManager.popUI()
    local index = #m_guilist;
    local guiInfo = m_guilist[index];
    log("销毁界面 " .. guiInfo.gameObject.name);
    GameObject.Destroy(guiInfo.gameObject);
    table.remove(m_guilist, index);
end

-- 注册界面上的点击事件回调
function GUIManager.bind_listener(uiName, trans)
    local childCount = trans.childCount;
    for i = 0, childCount - 1 do
        local child = trans:GetChild(i);
        GUIManager.bind_listener(uiName, child); -- 递归
    end

    local btn = trans:GetComponent("Button");
    if (btn ~= nil) then
        local luacode =
            'local onClick = ' .. uiName .. 'Ctrl.' .. btn.name .. '_onClick;'
            .. 'if (onClick ~= nil) then '
            .. '    onClick();'
            .. 'end\n'
            .. 'log("' .. uiName .. 'Ctrl.' .. btn.name .. '_onClick");'
        ; -- 注册点击事件
        local listener = load(luacode);
        btn.onClick:AddListener(listener);
    end
end
