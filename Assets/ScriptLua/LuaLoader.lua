
-- 脚本加载器
local LuaLoader = {
    loaded = {}
}

-- 加载脚本[name]]
LuaLoader.loadScript = function(name)
    local obj = require(name)
    LuaLoader.loaded[name] = obj
    return obj
end

-- 卸载脚本[name]]
LuaLoader.unloadScript = function(name)
    if LuaLoader.loaded[name] then
        LuaLoader.loaded[name] = nil
        package.loaded[name] = nil
    end
end

--[
--卸载所有脚本
--]
LuaLoader.unLoadAll = function()
    for k, v in pairs(LuaLoader.loaded) do
        LuaLoader.unloadScript(k)
    end
end

--重新加载所有脚本
LuaLoader.reloadAll = function()
   local p = clone(LuaLoader.loaded)
    for k,v in pairs(LuaLoader.loaded) do
        if v then
            package.loaded[k] = nil
            LuaLoader.loaded[k] = false
        end
    end
    LuaLoader.loaded = {}
    for k,v in pairs(p) do
        LuaLoader.loadScript(k)
    end

end

_G.LuaLoader = LuaLoader