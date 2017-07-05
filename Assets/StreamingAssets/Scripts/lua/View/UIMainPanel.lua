
UIMainPanel = {};

local transform = nil;
local gameObject = nil;

function UIMainPanel.init()
    transform = UIMainPanel.transform;   -- 从FLuaBehaviour中传来的值
    gameObject = UIMainPanel.gameObject; -- 从FLuaBehaviour中传来的值
end

function UIMainPanel.Awake()
end

function UIMainPanel.OnEnable()
end

function UIMainPanel.OnDisable()
end

function UIMainPanel.Start()
end

function UIMainPanel.Update()
end

function UIMainPanel.FixedUpdate()
end

function UIMainPanel.OnDestroy()
end
