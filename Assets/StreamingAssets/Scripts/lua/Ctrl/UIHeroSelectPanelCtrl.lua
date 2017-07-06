
UIHeroSelectPanelCtrl = {};

function UIHeroSelectPanelCtrl.hero_onClick(idx)
    log(idx);
end

function UIHeroSelectPanelCtrl.start_onClick()
    local battleInst = GBattleManager.getInstance():createBattle(1);
    battleInst:init();
    battleInst:loadUI();
    battleInst:initUI();
    battleInst:enter();
    battleInst:start();
    GUIManager.pushPanel("UILoadBattlePanel");
end
