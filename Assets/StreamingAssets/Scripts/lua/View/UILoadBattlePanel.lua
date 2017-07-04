
UILoadBattlePanel = {}

local transform = nil;
local gameObject = nil;

function UILoadBattlePanel.init()
    transform = UILoadBattlePanel.transform;   -- 从FLuaBehaviour中传来的值
    gameObject = UILoadBattlePanel.gameObject; -- 从FLuaBehaviour中传来的值
end

function UILoadBattlePanel.Start()
    local seq = CS.x1.Framework.FSequence();
    local battle = GBattleManager.getInstance():getBattle();
    seq:addAction(CS.x1.Game.GLoadBattle(battle));
    gameObject:runAction(seq);

end