
require "luaLoader"
-- 加载一些必须的模块
LuaLoader.loadScript("utils.loger")
LuaLoader.loadScript("utils.utils")

LuaLoader.loadScript("function")
LuaLoader.loadScript("globalDefine")

DLG("main----")

local obj = UE.GameObject.Find("Canvas")
DLG("obj----",obj.name)


local tab = getObjHolder(obj)
addBtnClick(tab._btnlogin,function(btn)
    DLG("btn----",btn.name)
end)

