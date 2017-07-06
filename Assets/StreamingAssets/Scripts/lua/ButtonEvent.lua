
ButtonEvent = {}

function ButtonEvent.onClick(gameObj, uiName)
    local btnName = gameObj.name;
    local ctrlName = uiName .. 'Ctrl';
    local func, idx = string.match(btnName, '(.+)_(%d+)');
    if (func == nil) then
        local funcName = btnName .. '_onClick';
        local ctrl = _G[ctrlName];
        local callback = ctrl[funcName];
        log(ctrlName .. '.' .. funcName);
        callback();
    else
        local funcName = func .. '_onClick';
        local ctrl = _G[ctrlName];
        local callback = ctrl[funcName];
        log(ctrlName .. '.' .. funcName);
        callback(idx);
    end
end

function ButtonEvent.onPress(gameObj, isPressed)

end