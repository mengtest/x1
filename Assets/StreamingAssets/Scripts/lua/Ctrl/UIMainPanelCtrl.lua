
UIMainPanelCtrl = {};

function UIMainPanelCtrl.mode_onClick(idx)
    if (idx == 1) then
        GUIManager.pushPanel("UIHeroSelectPanel");
    elseif (idx == 2) then
        log("敬请期待");
    end
end
