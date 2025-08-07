

-- 加载框架
require("framework.init")
-- 加载全局定义
LuaLoader.loadScript("globalDefine")



local obj = UE.GameObject.Find("Canvas")
log("obj----",obj.name)


local tab = getObjHolder(obj)
addBtnClick(tab._btnlogin,function(btn)
    log("btn----",btn.name)
    EventManager.emit("test","111","333")
end)

EventManager.on("test",function(arg1,arg2)
    log("testEvent",arg1,arg2)
end)

