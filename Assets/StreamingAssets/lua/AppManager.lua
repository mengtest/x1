
require("Common.lua");
require("AppConst.lua");
require("GUIManager.lua");
require("View/UILoading.lua");
require("Ctrl/UILoadingCtrl.lua");
require("Ctrl/UIDialogCtrl.lua")
require("View/UIMainPanel.lua")
require("Ctrl/UIMainPanelCtrl.lua")

AppManager = {};

function AppManager.init()
    GUIManager.init();
end

function AppManager.startup()
    GUIManager.pushUI("UIMainPanel");
end

