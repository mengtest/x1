
UILoadingCtrl = {};

function UILoadingCtrl.Button_onClick()
    GUIManager.pushUI("UIDialog");
end

function UILoadingCtrl.BtnClose_onClick()
    GUIManager.popUI();
end
