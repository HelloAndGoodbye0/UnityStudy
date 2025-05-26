

-- 加载框架
require("framework.init")
-- 加载全局定义
LuaLoader.loadScript("globalDefine")



local obj = UE.GameObject.Find("Canvas")
log("obj----",obj.name)


local tab = getObjHolder(obj)
addBtnClick(tab._btnlogin,function(btn)
    log("btn----",btn.name)
    EventManager.emit("test")
end)

EventManager.on("test",function(...)
    log("test----",data)
end)

