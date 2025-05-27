---资源管理器
local resManager = {
    cache = {},  -- 资源缓存
}

resManager.load = function (path, callback,abName)
    local asset = resManager.cache[path]
    
end


_G.resManager = resManager