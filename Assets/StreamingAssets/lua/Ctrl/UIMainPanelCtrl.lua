
UIMainPanelCtrl = {};

function UIMainPanelCtrl.mode1_onClick()
    local battleInst = GBattleManager.getInstance():createBattle(1);
    battleInst:init();
    battleInst:loadUI();
    battleInst:initUI();
    battleInst:enter();
    battleInst:start();
    GUIManager.pushPanel("UILoadBattlePanel");
end

function UIMainPanelCtrl.mode2_onClick()
end