
GUIManager = {};

local m_uiManager = nil;

function GUIManager.init()
    m_uiManager = FUIManager.getInstance();
end

function GUIManager.pushPanel(uiName)
    local function loaded(gameObj)
    end
    m_uiManager:pushPanel(uiName, loaded);
end

function GUIManager.popPanel()
    m_uiManager:popPanel();
end

function GUIManager.pushDialog(uiName)
    m_uiManager:pushDialog();
end

function GUIManager.popDialog()
    m_uiManager:popDialog();
end
