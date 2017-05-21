
GUIManager = {};

local m_guilist = nil;
local m_guiRoot = "GUI"
local m_canvas = nil;

function GUIManager.init()
    m_guilist = {};
    m_canvas = LuaHelper.GetCanvas();
end

function GUIManager.pushUI(uiName, isDialog)
    local guiInfo = {};
    local oldInfo = m_guilist[#m_guilist];

    guiInfo.uiName = uiName;
    guiInfo.isDialog = isDialog;
    guiInfo.prefab = LuaHelper.LoadGameObject(m_guiRoot .. '/' .. uiName);
    guiInfo.gameObject = LuaHelper.CreateGameObject(guiInfo.prefab, m_canvas.transform);

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

function GUIManager.bind_listener(uiName, trans)
    local childCount = trans.childCount;
    for i = 0, childCount - 1 do
        local child = trans:GetChild(i);
        GUIManager.bind_listener(uiName, child);
    end

    local btn = trans:GetComponent("Button");
    if (btn ~= nil) then
        local luacode =
            'local call = ' .. uiName .. 'Ctrl.' .. btn.name .. '_onClick;'
            .. 'if (call ~= nil) then '
            .. 'call();'
            .. 'end'
        ;
        local listener = load(luacode);
        btn.onClick:AddListener(listener)
        log("注册事件" ..uiName.. '.' .. btn.name);
    end
end

function GUIManager.btn_on_click()
    log("牛逼")
end