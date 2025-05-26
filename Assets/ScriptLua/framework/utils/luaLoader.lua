
-- 脚本加载器
local luaLoader = {
    loaded = {}
}

---加载脚本
---@param name string 脚本名称
---@return table|nil 返回加载的脚本对象，如果加载失败则返回nil
luaLoader.loadScript = function(name)
    local obj = require(name)
    luaLoader.loaded[name] = obj
    return obj
end

---卸载脚本
---@param name string 脚本名称
luaLoader.unloadScript = function(name)
    if luaLoader.loaded[name] then
        luaLoader.loaded[name] = nil
        package.loaded[name] = nil
    end
end

---卸载所有脚本
luaLoader.unLoadAll = function()
    for k, v in pairs(luaLoader.loaded) do
        luaLoader.unloadScript(k)
    end
end

---重新加载所有脚本
luaLoader.reloadAll = function()
   local p = clone(luaLoader.loaded)
    for k,v in pairs(luaLoader.loaded) do
        if v then
            package.loaded[k] = nil
            luaLoader.loaded[k] = false
        end
    end
    luaLoader.loaded = {}
    for k,v in pairs(p) do
        luaLoader.loadScript(k)
    end

end

_G.LuaLoader = luaLoader