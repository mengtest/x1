
require("Common.lua");
require("AppConst.lua");
require("GUIManager.lua");
require("View/UILoading.lua");
require("Ctrl/UILoadingCtrl.lua");
require("Ctrl/UIDialogCtrl.lua")

AppManager = {};

function AppManager.init()
    GUIManager.init();
end

function AppManager.startup()
    GUIManager.pushUI("UILoading");
end

